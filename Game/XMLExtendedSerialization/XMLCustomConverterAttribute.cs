using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XMLExtendedSerialization
{
    [AttributeUsage(AttributeTargets.Field)]
    public class XMLCustomConverterAttribute : Attribute
    {
        private IXMLValueConverter _converter;
        public IXMLValueConverter Converter
        {
            get { return _converter; }
        }

        public XMLCustomConverterAttribute(Type converterType)
        {
            if (typeof(IXMLValueConverter).IsAssignableFrom(converterType))
                _converter = (IXMLValueConverter)Activator.CreateInstance(converterType);
            else
                throw new ArgumentException("Converter must implement IXMLValueConverter interface.");
        }
    }
}
