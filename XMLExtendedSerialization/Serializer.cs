//#define SAVEDEBUGINFO
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Linq;
using System.Reflection;
using Microsoft.Xna.Framework;
using System.Collections;

namespace XMLExtendedSerialization
{
    internal class Serializer
    {
#if SAVEDEBUGINFO
        private XDocument _document;
        private int _recursionDepth = 0;
        private List<string> _refListContent;
#endif
        private Stream _stream;
        private Dictionary<Type, Func<object, string>> _converters;

        /// <summary>
        /// Список из всех сериализованных reference-type объектов.
        /// Ключ - ссылка на объект, значение - hash-код объекта.
        /// </summary>
        private Dictionary<object, string> _refList;

        private void InitializeConverters()
        {
            _converters = new Dictionary<Type, Func<object, string>>();

            //Default types
            _converters.Add(typeof(string), x => (string)x);
            _converters.Add(typeof(bool), DefaultConverters.BoolToString);
            _converters.Add(typeof(byte), DefaultConverters.ByteToString);
            _converters.Add(typeof(char), DefaultConverters.CharToString);
            _converters.Add(typeof(decimal), DefaultConverters.DecimalToString);
            _converters.Add(typeof(double), DefaultConverters.DoubleToString);
            _converters.Add(typeof(float), DefaultConverters.FloatToString);
            _converters.Add(typeof(int), DefaultConverters.IntToString);
            _converters.Add(typeof(long), DefaultConverters.LongToString);
            _converters.Add(typeof(sbyte), DefaultConverters.SByteToString);
            _converters.Add(typeof(short), DefaultConverters.ShortToString);
            _converters.Add(typeof(uint), DefaultConverters.UIntToString);
            _converters.Add(typeof(ulong), DefaultConverters.ULongToString);
            _converters.Add(typeof(ushort), DefaultConverters.UShortToString);

            _converters.Add(typeof(Color), DefaultConverters.ColorToString);
            _converters.Add(typeof(Vector2), DefaultConverters.Vector2ToString);
            _converters.Add(typeof(Vector3), DefaultConverters.Vector3ToString);
            _converters.Add(typeof(Vector4), DefaultConverters.Vector4ToString);
        }

        internal Serializer(Stream stream)
        {
            _stream = stream;
            _refList = new Dictionary<object, string>(Settings.DefaultRefListSize);

            InitializeConverters();

#if SAVEDEBUGINFO
            _document = new XDocument();
            _document.Add(new XElement("Root"));
            _refListContent = new List<string>(Settings.DefaultRefListSize);
#endif
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
                    if (_converters.ContainsKey(converter.TargetType))
                        _converters.Remove(converter.TargetType);
                    _converters.Add(converter.TargetType, converter.ConvertBack);
                }
            }
        }

        private IXMLCustomSerializer GetCustomSerializer(FieldInfo field)
        {
            Attribute[] attributes = Attribute.GetCustomAttributes(field);
            foreach (Attribute attribute in attributes)
            {
                if (attribute.GetType().SameType(typeof(XMLCustomSerializerAttribute)))
                    return (attribute as XMLCustomSerializerAttribute).Serializer;
            }

            return null;
        }

        private void SerializeMetadata(XElement root, object rootObject)
        {
            if (rootObject.GetType().IsClass)
            {
                string metadata = rootObject.GetXMLMetadata();
                if (metadata != null)
                    root.Add(new XComment(metadata.ToXMLComment()));
            }
        }

        private void SerializeTypeName(XElement root, Type rootType)
        {
            root.Add(new XAttribute(Settings.TypeNameTag, rootType.FullName.ToXMLValue()));
        }

        /// <summary>
        /// Рекурсивно сериализует объект.
        /// </summary>
        private XElement SerializeObject(string name, object rootObject)
        {
#if SAVEDEBUGINFO
            _recursionDepth++;
            if (_recursionDepth > Settings.Debug.MaxRecursionDepth)
                throw new ApplicationException("DEBUG: Max recursion depth.");
#endif

            if (rootObject == null)
                return new XElement(name, null);

            Type rootType = rootObject.GetType();

            //Делегаты не сериализуем
            if (rootObject is Delegate)
                return null;

            XElement element = new XElement(name);

            //***CIRCULAR REFERENCES***
            //Если reference-type, то добавляем объект в список
            if (!rootType.IsValueType)
            {
                //Если в списке ссылок на объекты этого объекта ещё нет, то добавляем его
                if (!_refList.ContainsKey(rootObject))
                {
#if SAVEDEBUGINFO
                    element.Add(new XComment(String.Format("_refList index: {0}, type: {1}", _refList.Count, rootType.FullName)));
                    _refListContent.Add(rootType.FullName);
#endif
                    _refList.Add(rootObject, _refList.Count.ToString());
                }
            }
            //*************************

            //Если объект - словарь, то сериализуем его в отдельном методе. В принципе, работает и без этого, но XML тогда не такой читаемый и больше по объему.
            if (rootObject is IDictionary)
            {
#if SAVEDEBUGINFO
                XElement dictElement = SerializeDictionary(name, (IDictionary)rootObject);
                if (_refList.ContainsKey(rootObject))
                    dictElement.Add(new XComment(String.Format("_refList index: {0}, type: {1}", _refList[rootObject], rootType.FullName)));
                return dictElement;
#endif
                return SerializeDictionary(name, (IDictionary)rootObject);
            }

            //Если объект - массив, сериализуем его в отдельном методе
            if (rootType.IsArray)
            {
#if SAVEDEBUGINFO
                XElement arrayElement = SerializeArray(name, (Array)rootObject);
                if (_refList.ContainsKey(rootObject))
                    arrayElement.Add(new XComment(String.Format("_refList index: {0}, type: {1}", _refList[rootObject], rootType.FullName)));
                return arrayElement;
#endif
                return SerializeArray(name, (Array)rootObject);
            }

            SerializeTypeName(element, rootType);

            if (rootObject is string)
            {
                element.Add(((string)rootObject).ToXMLValue());
                return element;
            }

            //Если объект - generic, сериализуем его в отдельном методе
            //if (rootType.IsGenericType)
            //    return SerializeGenericObject(name, rootObject);

            //Записываем метаданные
            SerializeMetadata(element, rootObject);

            //Получаем все поля объекта
            FieldInfo[] fields = rootType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            //PropertyInfo[] properties = rootType.GetProperties(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

            foreach (var field in fields)
            {
                //Проверяем на отсутствие атрибута XMLDoNotSerialize
                if (!field.HasAttribute(typeof(XMLDoNotSerializeAttribute)))
                {
                    //Проверяем наличие специального конвертера для данного типа
                    CheckCustomConverter(field);

                    Func<object, string> converter;
                    object fieldValue = field.GetValue(rootObject);
                    string xmlFieldName = field.GetXMLName();

                    if (fieldValue == null)
                    {
                        element.SetAttributeValue(xmlFieldName, fieldValue);
                        continue;
                    }

                    //***CIRCULAR REFERENCES***
                    if (!field.FieldType.IsValueType)
                    {
                        //Получаем данные о ссылке на объект
                        string hashCode;
                        if (_refList.TryGetValue(fieldValue, out hashCode))
                        {
                            //Если объект уже был сериализован, то записываем только ссылку на него
                            element.SetAttributeValue(xmlFieldName, hashCode.ToXMLValue());
                            continue;
                        }
                    }
                    //*************************

                    //Если конвертер для данного типа данных уже есть
                    if (_converters.TryGetValue(field.FieldType, out converter))
                        //то записываем значение поля как атрибут
                        element.SetAttributeValue(xmlFieldName, converter(fieldValue).ToXMLValue());
                    //Если конвертера для данного типа данных нет
                    else
                    {
                        //то проверяем наличие custom-сериализатора для данного типа
                        XElement child;

                        //Если он есть
                        if (field.HasAttribute(typeof(XMLCustomSerializerAttribute)))
                        {
                            IXMLCustomSerializer serializer = GetCustomSerializer(field);
                            child = serializer.Serialize(fieldValue, xmlFieldName);
                        }
                        else
                        {
                            // иначе рекурсивно сериализуем значение поля
                            child = SerializeObject(xmlFieldName, fieldValue);
                        }

                        element.Add(child);
                    }
                }
            }
#if SAVEDEBUGINFO
            _document.Root.Add(element);
#endif
            return element;
        }

        /// <summary>
        /// Сериализует массив элементов.
        /// </summary>
        /// <param name="name">Имя XML-элемента.</param>
        /// <param name="rootObject">Массив для записи.</param>
        /// <returns>XML-элемент с данными о массиве.</returns>
        private XElement SerializeArray(string name, Array rootObject)
        {
            Type rootType = rootObject.GetType();
            Type elementType = rootType.GetElementType();
            object defaultValue;
            if (elementType.IsValueType)
                defaultValue = System.Runtime.Serialization.FormatterServices.GetUninitializedObject(elementType);
            else
                defaultValue = null;

            XElement element = new XElement(name);
            SerializeMetadata(element, rootObject);
            SerializeTypeName(element, rootType);
            element.Add(new XAttribute(Settings.LengthTag, rootObject.Length.ToString()));

            for (int i = 0; i < rootObject.Length; i++)
            {
                object item = rootObject.GetValue(i);
                if (!object.Equals(item, defaultValue))
                {
                    XElement xItem = SerializeObject(Settings.ArrayElementTag, item);
                    xItem.Add(new XAttribute(Settings.IndexTag, i));
                    element.Add(xItem);
                }
            }

            return element;
        }

        private XElement SerializeDictionary(string name, IDictionary rootObject)
        {
            XElement element = new XElement(name);
            SerializeMetadata(element, rootObject);
            Type rootType = rootObject.GetType();
            SerializeTypeName(element, rootType);

            foreach (DictionaryEntry item in rootObject)
            {
                XElement itemElement = new XElement(Settings.DictionaryItemTag);
                itemElement.Add(SerializeObject(Settings.DictionaryKeyTag, item.Key));
                itemElement.Add(SerializeObject(Settings.DictionaryValueTag, item.Value));
                element.Add(itemElement);
            }

            return element;
        }

        public void Serialize(object rootObject, string rootName = Settings.DefaultRootName)
        {
            Serialize(rootObject, false, String.Empty, rootName);
        }

        public void Serialize(object rootObject, string metaData, string rootName = Settings.DefaultRootName)
        {
            Serialize(rootObject, true, metaData, rootName);
        }

        private void Serialize(object rootObject, bool addMetadata, string metadata, string rootName)
        {
            XDocument doc = new XDocument();

#if SAVEDEBUGINFO
            try
            {
#endif
            if (addMetadata)
                doc.Add(new XComment(metadata.ToXMLComment()));
            doc.Add(SerializeObject(rootName, rootObject));
            doc.Save(_stream);
#if SAVEDEBUGINFO
            }
            finally
            {
                using (Stream debugStream = File.Create("XML debug info.xml"))
                {
                    _document.Save(debugStream);
                }

                System.Diagnostics.Debug.WriteLine("");
                System.Diagnostics.Debug.WriteLine("S E R I A L I Z E R _refList content ({0} elements):", _refList.Count);
                foreach (string s in _refListContent)
                    System.Diagnostics.Debug.WriteLine(s);
                System.Diagnostics.Debug.WriteLine("");
                //throw ex;
            }
#endif
        }
    }
}