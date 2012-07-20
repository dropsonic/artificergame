using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace XMLImporterEx
{
    public static class FieldInfoExtensions
    {
        /// <summary>
        /// Конвертирует имя поля в xml-корректное, заменяя недопустимые символы.
        /// </summary>
        public static string GetXMLName(this FieldInfo field)
        {
            string result = field.Name;
            result = result.Replace("<", "lt--");
            result = result.Replace(">", "--gt");
            return result;
        }

        /// <summary>
        /// Проверяет поле на присутствие атрибута заданного типа.
        public static bool HasAttribute(this FieldInfo field, Type attributeType)
        {
            Attribute[] attributes = Attribute.GetCustomAttributes(field);
            foreach (Attribute attribute in attributes)
            {
                if (attribute.GetType().SameType(attributeType))
                    return true;
            }

            return false;
        }
    }
}
