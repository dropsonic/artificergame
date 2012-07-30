using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

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

        /// <summary>
        /// Возвращает коллекцию FieldInfo для всех полей типа, включая определённые в типах-предках.
        /// </summary>
        /// <param name="flags">Битовая маска, составленная из одного или нескольких объектов BindingFlags и указывающая, как ведется поиск,
        /// или
        /// 0, чтобы было возвращено значение null.</param>
        /// <returns>Коллекция FieldInfo с информацией о полях.</returns>
        public static IEnumerable<FieldInfo> GetFieldsIncludingBase(this Type t, BindingFlags flags)
        {
            if (t == null)
                return Enumerable.Empty<FieldInfo>();

            return t.GetFields(flags).Union(GetFieldsIncludingBase(t.BaseType, flags));
        }
    }
}
