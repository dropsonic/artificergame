using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Reflection;
using System.IO;
using Microsoft.Xna.Framework;

namespace XMLImporterEx
{
    internal class Deserializer
    {
        private Stream _stream;
        private Dictionary<Type, Func<string, object>> _converters;

        internal Deserializer(Stream stream)
        {
            _stream = stream;

            InitializeConverters();
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

        public object Deserialize()
        {
            XDocument doc = XDocument.Load(_stream);
            //Имя типа для инстанциации - имя корневого тега файла
            string typeName = doc.Root.Name.LocalName;
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies(); //получаем все сборки, которые есть в solution'е
            Type rootType = GetTypeByName(typeName, assemblies); //получаем тип по имени

            return DeserializeObject(doc.Root, rootType);
        }

        /// <summary>
        /// Рекурсивно десериализует объект.
        /// </summary>
        private object DeserializeObject(XElement root, Type rootType)
        {
            //Создаём корневой объект. Для класса создаём новый объект данного типа, для структуры получаем пустой экземпляр.
            object rootObject = rootType.IsClass ? CreateInstance(rootType) : System.Runtime.Serialization.FormatterServices.GetUninitializedObject(rootType);

            FieldInfo[] fields = rootType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public); //получаем список полей, включая автоматически созданные для свойств
            //PropertyInfo[] properties = rootType.GetProperties(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public); //получаем списк свойств

            foreach (var field in fields)
            {
                //Проверяем на отсутствие атрибута XMLDoNotSerialize
                if (!field.HasAttribute(typeof(XMLDoNotSerializeAttribute)))
                {
                    CheckCustomConverter(field);

                    Type fieldType = field.FieldType;

                    //Считываем значение элемента/атрибута с именем данного свойства
                    string value;
                    XName xname = XName.Get(field.GetXMLName());
                    XElement element = root.Element(xname);
                    if (element == null)
                    {
                        XAttribute attribute = root.Attribute(xname);
                        if (attribute == null)
                            //throw new MissingMemberException(rootType.Name, field.Name);
                            value = null;
                        else
                            value = attribute.Value;
                    }
                    else
                    {
                        //Если это Enum, то он сохраняет своё значение как int в атрибут "__value"
                        if (fieldType.IsEnum)
                        {
                            value = element.FirstAttribute.Value;
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
                            fieldValue = converter(value); //то это простой тип данных
                        else
                        {
                            if (element != null)
                            {
                                fieldValue = DeserializeObject(element, fieldType); //если конвертера нет, то это сложный составной класс - рекурсивно десериализуем его
                            }
                            else
                                throw new System.Xml.XmlException(String.Format("Element {0} not found.", field.Name));
                        }
                    }

                    field.SetValue(rootObject, fieldValue);
                }
            }

            return rootObject;
        }
    }
}
