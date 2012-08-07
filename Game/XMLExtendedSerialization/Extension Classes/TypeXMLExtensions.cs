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

        /// <summary>
        /// Возвращает FieldInfo для поля с указанным именем, включая определённое в типах-предках.
        /// </summary>
        /// <returns>FieldInfo для поля; null, если поле с указанным именем не найдено.</returns>
        public static FieldInfo GetFieldIncludingBase(this Type t, string fieldName, BindingFlags flags)
        {
            if (t == null)
                return null;

            FieldInfo field = t.GetField(fieldName, flags);
            if (field == null)
                return GetFieldIncludingBase(t.BaseType, fieldName, flags);
            else
                return field;
        }

        /// <summary>
        /// Возвращает PropertyInfo для свойства с указанным именем, включая определённое в типах-предках.
        /// </summary>
        /// <returns>PropertyInfo для свойства; null, если свойство с указанным именем не найдено.</returns>
        public static PropertyInfo GetPropertyIncludingBase(this Type t, string propertyName, BindingFlags flags)
        {
            if (t == null)
                return null;

            PropertyInfo property = t.GetProperty(propertyName, flags);
            if (property == null)
                return GetPropertyIncludingBase(t.BaseType, propertyName, flags);
            else
                return property;
        }
    }
}
