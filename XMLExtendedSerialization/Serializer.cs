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
            _refList = new Dictionary<object, string>(32);

            InitializeConverters();
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
            root.Add(new XAttribute("Type-", rootType.FullName.ToXMLValue()));
        }

        /// <summary>
        /// Рекурсивно сериализует объект.
        /// </summary>
        private XElement SerializeObject(string name, object rootObject)
        {
            Type rootType = rootObject.GetType();

            //Если reference-type, то добавляем объект в список
            if (!rootType.IsValueType)
            {
                //Если в списке ссылок на объекты этого объекта ещё нет, то добавляем его
                if (!_refList.ContainsKey(rootObject))
                    _refList.Add(rootObject, _refList.Count.ToString());
            }

            XElement element = new XElement(name);

            if (rootObject == null)
                return null;

            if (rootObject is IDictionary)
                return SerializeDictionary(name, (IDictionary)rootObject);

            //Если объект - массив, сериализуем его в отдельном методе
            if (rootType.IsArray)
                return SerializeArray(name, (Array)rootObject);

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
            XElement element = new XElement(name);
            SerializeMetadata(element, rootObject);
            Type rootType = rootObject.GetType();
            SerializeTypeName(element, rootType);
            
            foreach (object item in rootObject)
                element.Add(SerializeObject("Element", item));

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
                XElement itemElement = new XElement("Item");
                itemElement.Add(SerializeObject("Key", item.Key));
                itemElement.Add(SerializeObject("Value", item.Value));
                element.Add(itemElement);
            }

            return element;
        }

        //private XElement SerializeGenericObject(string name, object rootObject)
        //{
        //    XElement element = new XElement(name);
        //    Type rootType = rootObject.GetType();

        //    return element;
        //    throw new NotImplementedException();
        //}

        public void Serialize(object rootObject, string rootName = "Object")
        {
            Serialize(rootObject, false, String.Empty, rootName);
        }

        public void Serialize(object rootObject, string metaData, string rootName = "Object")
        {
            Serialize(rootObject, true, metaData, rootName);
        }

        private void Serialize(object rootObject, bool addMetadata, string metadata, string rootName)
        {
            XDocument doc = new XDocument();
            if (addMetadata)
                doc.Add(new XComment(metadata.ToXMLComment()));
            doc.Add(SerializeObject(rootName, rootObject));
            doc.Save(_stream);
        }
    }
}
