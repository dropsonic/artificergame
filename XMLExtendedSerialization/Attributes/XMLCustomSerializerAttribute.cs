using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XMLExtendedSerialization
{
    [AttributeUsage(AttributeTargets.Field)]
    public class XMLCustomSerializerAttribute : Attribute
    {
        private IXMLCustomSerializer _serializer;
        public IXMLCustomSerializer Serializer
        {
            get { return _serializer; }
        }

        public XMLCustomSerializerAttribute(Type serializerType)
        {
            //if (typeof(IXMLCustomSerializer).IsAssignableFrom(serializerType))
            if (typeof(IXMLCustomSerializer).IsAssignableFrom(serializerType))
                _serializer = (IXMLCustomSerializer)Activator.CreateInstance(serializerType);
            else
                throw new ArgumentException("Serializer must implement IXMLCustomSerializer interface.");
        }
    }
}
