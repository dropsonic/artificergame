using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XMLExtendedSerialization
{
    public class SerializerException : Exception
    {
        public SerializerException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
