using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Reflection;
using System.IO;
using Microsoft.Xna.Framework;
using System.Collections;

namespace XMLExtendedSerialization
{
    internal class Deserializer
    {
        private XDocument _doc;
        private Assembly[] _assemblies;
        private Dictionary<Type, Func<string, object>> _converters;

        /// <summary>
        /// Список из всех десериализованных reference-type объектов.
        /// Ключ - hash-код объекта, значение - ссылка на объект.
        /// </summary>
        private Dictionary<string, object> _refList;

        internal Deserializer(XDocument doc)
        {
            _doc = doc;
            _refList = new Dictionary<string, object>(32);

            InitializeConverters();
            _assemblies = AppDomain.CurrentDomain.GetAssemblies();
        }

        private void InitializeConverters()
        {
            _converters = new Dictionary<Type, Func<string, object>>();

            //Default types
            _converters.Add(typeof(string), x => x);
            _converters.Add(typeof(bool), DefaultConverters.StringToBool);
            _converters.Add(typeof(byte), DefaultConverters.StringToByte);
            _converters.Add(typeof(char), DefaultConverters.StringToChar);
            _converters.Add(typeof(decimal), DefaultConverters.StringToDecimal);
            _converters.Add(typeof(double), DefaultConverters.StringToDouble);
            _converters.Add(typeof(float), DefaultConverters.StringToFloat);
            _converters.Add(typeof(int), DefaultConverters.StringToInt);
            _converters.Add(typeof(long), DefaultConverters.StringToLong);
            _converters.Add(typeof(sbyte), DefaultConverters.StringToSByte);
            _converters.Add(typeof(short), DefaultConverters.StringToShort);
            _converters.Add(typeof(uint), DefaultConverters.StringToUInt);
            _converters.Add(typeof(ulong), DefaultConverters.StringToULong);
            _converters.Add(typeof(ushort), DefaultConverters.StringToUShort);

            _converters.Add(typeof(Color), DefaultConverters.StringToColor);
            _converters.Add(typeof(Vector2), DefaultConverters.StringToVector2);
            _converters.Add(typeof(Vector3), DefaultConverters.StringToVector3);
            _converters.Add(typeof(Vector4), DefaultConverters.StringToVector4);
        }

        /// <summary>
        /// Находит тип по его имени в указанных сборках.
        /// </summary>
        private Type GetTypeByName(string typeName, Assembly[] assemblies)
        {
            foreach (var assembly in assemblies)
            {
                Type result = assembly.GetType(typeName);
                if (result != null)
                    return result;
            }

            throw new NullReferenceException("Type not found.");
        }

        private object CreateInstance(Type type)
        {
            if (type.IsAbstract)
                if (type.IsSealed) //на уровне IL static class является abstract sealed class
                    throw new MemberAccessException(String.Format("Cannot create instance of the static type {0}.", type.Name));
                else
                    throw new MemberAccessException(String.Format("Cannot create instance of the abstract type {0}.", type.Name));
            try
            {
                //return Activator.CreateInstance(type);
                //Получаем любой по видимости конструктор без параметров
                ConstructorInfo constructor = type.GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[0], null);
                return constructor.Invoke(null); //и вызываем его
            }
            catch (Exception ex)
            {
                throw new MissingMethodException(String.Format("Cannot create instance of the type {0}.", type.Name), ex);
            }
        }

        /// <summary>
        /// Проверяет наличие у поля атрибута XMLCustomConverterAttribute и добавляет его значение в словарь конвертеров.
        /// </summary>
        private void CheckCustomConverter(FieldInfo field)
        {
            Attribute[] attributes = Attribute.GetCustomAttributes(field);
            foreach (Attribute attribute in attributes)
            {
                if (attribute.GetType().SameType(typeof(XMLCustomConverterAttribute)))
                {
                    IXMLValueConverter converter = (attribute as XMLCustomConverterAttribute).Converter;

                    //Кто придумает, как проверять конвертеры на соответствие и лишний раз не удалять/добавлять одинаковые, может взять с полки пирожок.
                    if (_converters.ContainsKey(converter.TargetType))
                        _converters.Remove(converter.TargetType);

                    _converters.Add(converter.TargetType, converter.Convert);
                }
            }
        }

        /// <summary>
        /// Считывает метаданные из XML-элемента и записывает их в объект.
        /// </summary>
        /// <param name="root">XML-элемент для чтения.</param>
        /// <param name="rootObject">Объект, в который необходимо записать метаданные.</param>
        private void DeserializeMetadata(XElement root, object rootObject)
        {
            Type rootType = rootObject.GetType();
            if (rootType.IsClass && root.FirstNode is XComment)
                rootObject.SetXMLMetadata((root.FirstNode as XComment).Value.FromXMLComment());
        }

        private string DeserializeTypeName(XElement root)
        {
            return root.Attribute("Type-").Value.FromXMLValue();
        }

        /// <summary>
        /// Рекурсивно десериализует объект.
        /// </summary>
        private object DeserializeObject(XElement root)
        {
            string typeName = DeserializeTypeName(root);
            Type rootType = GetTypeByName(typeName, _assemblies);

            //Если это массив, то десериализуем его в отдельном методе
            if (rootType.IsArray)
                return DeserializeArray(root, rootType);

            if (rootType == typeof(string))
                return root.Value.FromXMLValue();

            //Создаём корневой объект. Для класса создаём новый объект данного типа, для структуры получаем пустой экземпляр.
            object rootObject = rootType.IsClass ? CreateInstance(rootType) : System.Runtime.Serialization.FormatterServices.GetUninitializedObject(rootType);

            //Если reference-type, то добавляем объект в список
            if (!rootType.IsValueType)
            {
                //Если в списке ссылок на объекты этого объекта ещё нет, то добавляем его
                if (!_refList.ContainsValue(rootObject))
                    _refList.Add(_refList.Count.ToString(), rootObject);
            }
            
            DeserializeMetadata(root, rootObject);

            FieldInfo[] fields = rootType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public); //получаем список полей, включая автоматически созданные для свойств
            //PropertyInfo[] properties = rootType.GetProperties(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public); //получаем списк свойств

            foreach (var field in fields)
            {
                //Проверяем на отсутствие атрибута XMLDoNotSerialize
                if (!field.HasAttribute(typeof(XMLDoNotSerializeAttribute)))
                {
                    CheckCustomConverter(field);

                    //Считываем значение элемента/атрибута с именем данного свойства
                    string value;
                    XName xname = XName.Get(field.GetXMLName());
                    XElement element = root.Element(xname);

                    
                    Type fieldType;

                    if (element == null)
                    {
                        fieldType = field.FieldType;
                        XAttribute attribute = root.Attribute(xname);
                        if (attribute == null)
                            //throw new MissingMemberException(rootType.Name, field.Name);
                            value = null;
                        else
                            value = attribute.Value;
                    }
                    else
                    {
                        fieldType = GetTypeByName(DeserializeTypeName(element), _assemblies);
                        //Если это Enum, то он сохраняет своё значение как int в атрибут "value__"
                        if (fieldType.IsEnum)
                        {
                            value = element.Attribute("value__").Value;
                            fieldType = typeof(int);
                        }
                        else
                            value = element.Value;
                    }

                    //Конвертируем значение
                    object fieldValue;
                    if (value == null)
                        fieldValue = null;
                    else
                    {
                        Func<string, object> converter;
                        if (_converters.TryGetValue(fieldType, out converter)) //если есть такой конвертер
                            fieldValue = converter(value.FromXMLValue()); //то это простой тип данных
                        else
                        {
                            if (element != null)
                                fieldValue = DeserializeObject(element); //если конвертера нет, то это сложный составной класс - рекурсивно десериализуем его
                            else
                            {
                                //Если элемента нет, но есть атрибут с непустым значением, то это ссылка либо неизвестное поле
                                object refObject;
                                //Если значение элемента - hash-код, и объект с таким hash-кодом есть в списке десериализованных объектов
                                if (_refList.TryGetValue(value.FromXMLValue(), out refObject))
                                    //то это ссылка
                                    fieldValue = refObject;
                                else
                                    throw new System.Xml.XmlException(String.Format("Element {0} not found.", field.Name));
                            }
                        }
                    }

                    field.SetValue(rootObject, fieldValue);
                }
            }

            return rootObject;
        }

        /// <summary>
        /// Десериализует массив из элементов.
        /// </summary>
        /// <param name="root">XML-элемент с данными о массиве.</param>
        /// <param name="rootType">Тип массива.</param>
        /// <returns>Массив элементов.</returns>
        private object DeserializeArray(XElement root, Type rootType)
        {
            var elements = root.Elements("Element");
            Type arrayElementType = rootType.GetElementType();
            Array rootObject = Array.CreateInstance(arrayElementType, elements.Count());
            //Если reference-type, то добавляем объект в список
            if (!rootType.IsValueType)
            {
                //Если в списке ссылок на объекты этого объекта ещё нет, то добавляем его
                if (!_refList.ContainsValue(rootObject))
                    _refList.Add(_refList.Count.ToString(), rootObject);
            }
            DeserializeMetadata(root, rootObject);
            int i = 0;
            foreach (XElement element in elements)
                rootObject.SetValue(DeserializeObject(element), i++);

            return rootObject;
        }

        private object DeserializeDictionary(XElement root, Type rootType)
        {
            var elements = root.Elements("Item");
            IDictionary rootObject = (IDictionary)CreateInstance(rootType);
            DeserializeMetadata(root, rootObject);
            Type[] genericParams = rootType.GetGenericParameterConstraints();
            foreach (XElement element in elements)
            {
                
            }
            
            throw new NotImplementedException();
        }

        public object Deserialize()
        {
            string s;
            return Deserialize(false, out s);
        }

        public object Deserialize(out string metadata)
        {
            return Deserialize(true, out metadata);
        }

        private object Deserialize(bool readMetadata, out string metadata)
        {
            //Читаем метаданные
            if (readMetadata && _doc.FirstNode is XComment)
            {
                metadata = (_doc.FirstNode as XComment).Value.FromXMLComment();
            }
            else
                metadata = String.Empty;

            //Имя типа для инстанциации - имя корневого тега файла
            //string typeFullName = DeserializeTypeName(_doc.Root);
            //Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies(); //получаем все сборки, которые есть в solution'е
            //Type rootType = GetTypeByName(typeFullName, assemblies); //получаем тип по имени

            return DeserializeObject(_doc.Root);
        }
    }
}
