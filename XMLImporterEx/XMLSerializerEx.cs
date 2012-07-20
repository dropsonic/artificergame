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
            Deserializer deserializer = new Deserializer(stream);
            return deserializer.Deserialize();
        }
    }
}
