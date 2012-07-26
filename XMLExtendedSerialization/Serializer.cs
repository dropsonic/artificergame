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

        /// <summary>
        /// Рекурсивно сериализует объект.
        /// </summary>
        private XElement SerializeObject(string name, object rootObject)
        {
            XElement element = new XElement(name);

            if (rootObject == null)
                return null;

            Type rootType = rootObject.GetType();
            //Если объект - массив, сериализуем его в отдельном методе
            if (rootType.IsArray)
                return SerializeArray(name, (Array)rootObject);
            //Если объект - generic, сериализуем его в отдельном методе
            //if (rootType.IsGenericType)
            //    return SerializeGenericObject(name, rootObject);

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
            Type rootType = rootObject.GetType();
            //IList array = (rootObject as IList);
            foreach (object x in rootObject)
                element.Add(SerializeObject("Element", x));

            return element;
        }

        //private XElement SerializeGenericObject(string name, object rootObject)
        //{
        //    XElement element = new XElement(name);
        //    Type rootType = rootObject.GetType();

        //    return element;
        //    throw new NotImplementedException();
        //}

        public void Serialize(object rootObject)
        {
            Serialize(rootObject, false);
        }

        public void Serialize(object rootObject, string metaData)
        {
            Serialize(rootObject, true, metaData);
        }

        private void Serialize(object rootObject, bool addMetaData, string metaData = "")
        {
            XDocument doc = new XDocument();
            if (addMetaData)
                doc.Add(new XComment(metaData.ToXMLComment()));
            Type rootType = rootObject.GetType();
            string typeName = rootType.GetXMLFullName();
            doc.Add(SerializeObject(typeName, rootObject));
            doc.Save(_stream);
        }
    }
}
