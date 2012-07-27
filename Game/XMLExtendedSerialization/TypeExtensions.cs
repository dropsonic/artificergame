using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XMLExtendedSerialization
{
    public static class TypeExtensions
    {
        /// <summary>
        /// Проверяет два типа из разных сборок на соответствие.
        /// </summary>
        public static bool SameType(this Type a, Type x)
        {
            return (a.FullName == x.FullName);
        }
    }
}
