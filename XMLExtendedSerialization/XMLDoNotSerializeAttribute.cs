using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XMLExtendedSerialization
{
    [AttributeUsage(AttributeTargets.Field)]
    public class XMLDoNotSerializeAttribute : Attribute
    {
    }
}
