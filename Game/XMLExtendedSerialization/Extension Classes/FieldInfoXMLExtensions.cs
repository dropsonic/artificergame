﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace XMLExtendedSerialization
{
    public static class FieldInfoXMLExtensions
    {
        /// <summary>
        /// Конвертирует имя поля в xml-корректное, заменяя недопустимые символы.
        /// </summary>
        public static string GetXMLName(this FieldInfo field)
        {
            string result = field.Name;
            //Преобразуем имя backing field к имени свойства
            if ((result.Length > 0) && (result[0] == '<'))
                result = result.Substring(1, result.IndexOf('>') - 1);
            //result = result.Replace("<", "lt--");
            //result = result.Replace(">", "--gt");
            return result;
        }

        /// <summary>
        /// Проверяет поле на присутствие атрибута заданного типа.
        /// </summary>
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
