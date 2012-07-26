using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XMLExtendedSerialization
{
    public class XMLMetadataAttribute : Attribute
    {
        private string _metadata;

        public XMLMetadataAttribute(string metadata)
        {
            _metadata = metadata;
        }

        public string Metadata
        {
            get { return _metadata; }
        }
    }
}
