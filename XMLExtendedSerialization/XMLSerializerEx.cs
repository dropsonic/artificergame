using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Linq;
using System.Reflection;

namespace XMLExtendedSerialization
{
    public static class XMLSerializerEx
    {
        /// <summary>
        /// Сериализует объект в виде XML-документа.
        /// </summary>
        /// <param name="obj">Объект для сериализации.</param>
        /// <param name="stream">Поток, в который будет сохранён XML-документ.</param>
        /// <param name="rootName">Имя корневого тега XML-документа.</param>
        public static void Serialize(object obj, Stream stream, string rootName = "Object")
        {
            Serializer serializer = new Serializer(stream);
            serializer.Serialize(obj, rootName);
        }

        /// <summary>
        /// Сериализует объект в виде XML-документа.
        /// </summary>
        /// <param name="obj">Объект для сериализации.</param>
        /// <param name="metadata">Метаданные для сохранения в XML-документ.</param>
        /// <param name="stream">Поток, в который будет сохранён XML-документ.</param>
        /// <param name="rootName">Имя корневого тега XML-документа.</param>
        public static void Serialize(object obj, string metadata, Stream stream, string rootName = "Object")
        {
            Serializer serializer = new Serializer(stream);
            serializer.Serialize(obj, metadata, rootName);
        }

        public static object Deserialize(Stream stream)
        {
            XDocument doc = XDocument.Load(stream);
            Deserializer deserializer = new Deserializer(doc);
            return deserializer.Deserialize();
        }

        public static object Deserialize(Stream stream, out string metadata)
        {
            XDocument doc = XDocument.Load(stream);
            Deserializer deserializer = new Deserializer(doc);
            object result = deserializer.Deserialize(out metadata);
            return result;
        }

        public static object Deserialize(XDocument doc)
        {
            Deserializer deserializer = new Deserializer(doc);
            return deserializer.Deserialize();
        }
    }
}
