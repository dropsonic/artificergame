using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Linq;
using System.Reflection;

namespace XMLImporterEx
{
    public static class XMLSerializerEx
    {
        public static void Serialize(object obj, Stream stream)
        {
            Serializer serializer = new Serializer(stream);
            serializer.Serialize(obj);
        }

        public static object Deserialize(Stream stream)
        {
            XDocument doc = XDocument.Load(stream);
            Deserializer deserializer = new Deserializer(doc);
            return deserializer.Deserialize();
        }

        public static object Deserialize(XDocument doc)
        {
            Deserializer deserializer = new Deserializer(doc);
            return deserializer.Deserialize();
        }
    }
}
