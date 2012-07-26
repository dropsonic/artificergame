using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XMLExtendedSerialization
{
    public static class TypeXMLExtensions
    {
        /// <summary>
        /// Проверяет два типа из разных сборок на соответствие.
        /// </summary>
        public static bool SameType(this Type a, Type x)
        {
            return (a.FullName == x.FullName);
        }

        public static string GetXMLFullName(this Type x)
        {
            string result = x.FullName;
            result = result.Replace("<", "lt--");
            result = result.Replace(">", "--gt");
            result = result.Replace("`", "--gen--");
            result = result.Replace("[", "lb--");
            result = result.Replace("]", "--gb");
            result = result.Replace(",", "--cmm--");
            result = result.Replace(" ", "--spc--");
            result = result.Replace("=", "--eq--");
            return result;
        }
    }
}
