using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace XMLExtendedSerialization
{
    public static class SerializerHelpers
    {
        public static void SerializeMetadata(XElement root, object rootObject)
        {
            if (rootObject.GetType().IsClass)
            {
                string metadata = rootObject.GetXMLMetadata();
                if (metadata != null)
                    root.Add(new XComment(metadata.ToXMLComment()));
            }
        }

        public static void SerializeTypeName(XElement root, Type rootType)
        {
            root.Add(new XAttribute(Settings.TypeNameTag, rootType.FullName.ToXMLValue()));
        }
    }
}
