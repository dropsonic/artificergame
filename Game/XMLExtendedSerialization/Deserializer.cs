//#define SAVEDEBUGINFO
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
    public class Deserializer
    {
        private XDocument _doc;
        private Assembly[] _assemblies;
        private Dictionary<Type, Func<string, object>> _converters;
#if SAVEDEBUGINFO
        private List<string> _refListContent;
#endif

        private Dictionary<string, object> _refList;

        /// <summary>
        /// Список из всех десериализованных reference-type объектов.
        /// Ключ - hash-код объекта, значение - ссылка на объект.
        /// </summary>
        public Dictionary<string, object> RefList
        {
            get { return _refList; }
            set { _refList = value; }
        }

        internal Deserializer(XDocument doc)
        {
            _doc = doc;
            _refList = new Dictionary<string, object>(Settings.DefaultRefListSize);

#if SAVEDEBUGINFO
            _refListContent = new List<string>(Settings.DefaultRefListSize);
#endif

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
        public void DeserializeMetadata(XElement root, object rootObject)
        {
            Type rootType = rootObject.GetType();
            if (rootType.IsClass && root.FirstNode is XComment)
                rootObject.SetXMLMetadata((root.FirstNode as XComment).Value.FromXMLComment());
        }

        public string DeserializeTypeName(XElement root)
        {
            return root.Attribute(Settings.TypeNameTag).Value.FromXMLValue();
        }

        /// <summary>
        /// Возвращает новый экземпляр объекта (для класса - новый объект, созданный конструктором по умолчанию, для структуры - пустая структура).
        /// </summary>
        /// <param name="type">Тип объекта.</param>
        /// <returns></returns>
        public object GetEmptyObject(Type type)
        {
            return type.IsClass ? CreateInstance(type) : System.Runtime.Serialization.FormatterServices.GetUninitializedObject(type);
        }

        /// <summary>
        /// Возвращает объект из списка уже сериализованных объектов, если он там есть.
        /// </summary>
        /// <returns>Объект; null в случае, если подходящего объекта нет.</returns>
        public object GetCRObject(XElement root)
        {
            if (root.Attribute(Settings.TypeNameTag) == null)
            {
                string hashCode;
                object crObject;
                hashCode = root.Value.FromXMLValue();
                if (_refList.TryGetValue(hashCode, out crObject))
                    return crObject;
                else
                    throw new FormatException("Incorrect CR references structure.");
            }

            return null;
        }

        /// <summary>
        /// Получает значение хеш-кода кольцевой ссылки объекта.
        /// </summary>
        private string GetCRIndex(XElement root)
        {
            XAttribute crIndexAttribute = root.Attribute(Settings.CRIndexAttributeName);
            if (crIndexAttribute == null)
                throw new System.Xml.XmlException("CRIndex attribute not found.");

            return crIndexAttribute.Value.FromXMLValue();
        }

        /// <summary>
        /// Добавляет объект в список уже десериализованных объектов (для контроля кольцевых ссылок).
        /// </summary>
        public void AddToCRList(XElement root, object rootObject)
        {
            Type rootType = rootObject.GetType();

            //Если reference-type, то добавляем объект в список
            if (!rootType.IsValueType)
            {
                //Если в списке ссылок на объекты этого объекта ещё нет, то добавляем его
                string newHashCode = GetCRIndex(root);
                _refList.Add(newHashCode, rootObject);
#if SAVEDEBUGINFO
                _refListContent.Add(rootType.FullName);
#endif
            }
        }

        /// <summary>
        /// Рекурсивно десериализует объект.
        /// </summary>
        public object DeserializeObject(XElement root)
        {
            //Пытаемся получить объект из списка уже сериализованных объектов
            object rootObject = GetCRObject(root);
            if (rootObject != null)
                return rootObject;

            string typeName = DeserializeTypeName(root);
            Type rootType = GetTypeByName(typeName, _assemblies);

            //Проверяем наличие custom-сериализатора для данного типа
            XAttribute csAttribute = root.Attribute(Settings.CustomSerializerNameTag);
            //Если он есть
            if (csAttribute != null)
            {
                Type csType = GetTypeByName(csAttribute.Value.FromXMLValue(), _assemblies);
                IXMLCustomSerializer serializer = (IXMLCustomSerializer)CreateInstance(csType);
                rootObject = serializer.Deserialize(root, this);
            }

            else if (rootType == typeof(string))
                rootObject = root.Value.FromXMLValue();

            //Если это Enum, то он сохраняет своё значение как int в атрибут "value__"
            else if (rootType.IsEnum)
                rootObject = _converters[typeof(int)](root.Attribute(Settings.EnumValueAttributeName).Value);

            //Если это массив, то десериализуем его в отдельном методе
            else if (rootType.IsArray)
                rootObject = DeserializeArray(root, rootType);

            else if (rootType.GetInterface(typeof(IDictionary).Name) != null)
                rootObject = DeserializeDictionary(root, rootType);

            if (rootObject != null)
            {
                DeserializeMetadata(root, rootObject);
                return rootObject;
            }

            //Создаём корневой объект. Для класса создаём новый объект данного типа, для структуры получаем пустой экземпляр.
            rootObject = GetEmptyObject(rootType);

            //Добавляем объект в список кольцевых ссылок
            AddToCRList(root, rootObject);

            DeserializeMetadata(root, rootObject);

            IEnumerable<FieldInfo> fields = rootType.GetFieldsIncludingBase(Settings.DefaultFieldFlags); //получаем список полей, включая автоматически созданные для свойств
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
                    object fieldValue;

                    if (element == null)
                    {
                        fieldType = field.FieldType;
                        XAttribute attribute = root.Attribute(xname);
                        if (attribute == null)
                            fieldValue = null;
                        else
                        {
                            value = attribute.Value;
                            Func<string, object> converter;
                            if (_converters.TryGetValue(fieldType, out converter)) //если есть такой конвертер
                                fieldValue = converter(value.FromXMLValue()); //то это простой тип данных
                            else
                                throw new System.Xml.XmlException(String.Format("Converter for {0} not found.", fieldType));
                        }
                    }
                    else
                        fieldValue = DeserializeObject(element); //если конвертера нет, то это сложный составной класс - рекурсивно десериализуем его

                    //Если null, то ничего не присваиваем, чтобы не сбивать значения по умолчанию
                    if (fieldValue != null)
                        //Устанавливаем значение
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
            var elements = root.Elements(Settings.ArrayElementTag);
            Type arrayElementType = rootType.GetElementType();
            XAttribute lengthAttr = root.Attribute(Settings.LengthTag);
            Array rootObject = Array.CreateInstance(arrayElementType, int.Parse(lengthAttr.Value));
            //Если reference-type, то добавляем объект в список
            if (!rootType.IsValueType)
            {
                //Если в списке ссылок на объекты этого объекта ещё нет, то добавляем его
                if (!_refList.ContainsValue(rootObject))
                {
                    _refList.Add(GetCRIndex(root), rootObject);
#if SAVEDEBUGINFO
                    _refListContent.Add(rootType.FullName);
#endif
                }
            }
            DeserializeMetadata(root, rootObject);
            foreach (XElement element in elements)
            {
                //Считываем индекс элемента в массиве
                XAttribute indexAttr = element.Attribute(Settings.IndexTag);

                object item;

                string hashCode = element.Value.FromXMLValue();
                if (element.HasElements || !_refList.TryGetValue(hashCode, out item))
                    item = DeserializeObject(element);

                rootObject.SetValue(item, int.Parse(indexAttr.Value));
            }

            return rootObject;
        }

        /// <summary>
        /// Десериализует словарь типа "ключ-значение".
        /// </summary>
        /// <param name="root">XML-элемент с информацией о словаре.</param>
        /// <param name="rootType">Тип.</param>
        /// <returns>Объект словаря.</returns>
        private object DeserializeDictionary(XElement root, Type rootType)
        {
            var elements = root.Elements(Settings.DictionaryItemTag);
            IDictionary rootObject = (IDictionary)CreateInstance(rootType);

            if (!rootType.IsValueType)
            {
                //Если в списке ссылок на объекты этого объекта ещё нет, то добавляем его
                if (!_refList.ContainsValue(rootObject))
                {
                    _refList.Add(GetCRIndex(root), rootObject);
#if SAVEDEBUGINFO
                    _refListContent.Add(rootType.FullName);
#endif
                }
            }

            DeserializeMetadata(root, rootObject);
            foreach (XElement element in elements)
            {
                XElement keyElement = element.Element(Settings.DictionaryKeyTag);
                XElement valueElement = element.Element(Settings.DictionaryValueTag);

                string keyHashCode = keyElement.Value.FromXMLValue();
                object key;
                if (keyElement.HasElements || !_refList.TryGetValue(keyHashCode, out key))
                    key = DeserializeObject(keyElement);

                string valueHashCode = keyElement.Value.FromXMLValue();
                object value;
                if (keyElement.HasElements || !_refList.TryGetValue(keyHashCode, out value))
                    value = DeserializeObject(valueElement);

                rootObject.Add(key, value);
            }

            return rootObject;
        }

        internal object Deserialize()
        {
            string s;
            return Deserialize(false, out s);
        }

        internal object Deserialize(out string metadata)
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

#if SAVEDEBUGINFO
            try
            {
#endif
            return DeserializeObject(_doc.Root);
#if SAVEDEBUGINFO
            }
            catch (Exception ex)
            {
                WriteDebugInfo();
                throw ex;
            }
            finally
            {
                WriteDebugInfo();
            }
#endif
        }

#if SAVEDEBUGINFO
        private void WriteDebugInfo()
        {
            System.Diagnostics.Debug.WriteLine("");
            System.Diagnostics.Debug.WriteLine("D E S E R I A L I Z E R _refList content ({0} elements):", _refList.Count);
            foreach (string s in _refListContent)
                System.Diagnostics.Debug.WriteLine(s);
            System.Diagnostics.Debug.WriteLine("");
        }
#endif
    }
}