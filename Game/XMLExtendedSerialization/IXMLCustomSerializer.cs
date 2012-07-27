using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace XMLExtendedSerialization
{
    /// <summary>
    /// Интерфейс для классов, реализующих свой алгоритм сериализации объектов определённого типа.
    /// </summary>
    public interface IXMLCustomSerializer
    {
        Type TargetType { get; }
        XElement Serialize(object obj, string fieldName);
        object Deserialize(XElement element);
    }
}
