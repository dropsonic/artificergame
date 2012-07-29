using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XMLExtendedSerialization
{
    public static class StringXMLExtensions
    {
        /// <summary>
        /// Получает корректное с точки зрения XML имя элемента из полного имени типа.
        /// </summary>
        public static string GetFullNameFromXML(this string x)
        {
            string result = x;
            result = result.Replace("lt--", "<");
            result = result.Replace("--gt", ">");
            result = result.Replace("--gen--", "`");
            result = result.Replace("lb--", "[");
            result = result.Replace("--gb", "]");
            result = result.Replace("--cmm--", ",");
            result = result.Replace("--spc--", " ");
            result = result.Replace("--eq--", "=");
            return result;
        }

        /// <summary>
        /// Получает корректное с точки зрения XML значение.
        /// </summary>
        public static string ToXMLValue(this string x)
        {
            string result = x;
            result = result.Replace("<", "&lt;");
            result = result.Replace(">", "&gt;");
            result = result.Replace("&", "&amp;");
            result = result.Replace("\'", "&apos;");
            result = result.Replace("\"", "&quot;");
            return result;
        }

        /// <summary>
        /// Конвертирует корректное с точки зрения XML значение в обычную форму.
        /// </summary>
        public static string FromXMLValue(this string x)
        {
            string result = x;
            result = result.Replace("&lt;", "<");
            result = result.Replace("&gt;", ">");
            result = result.Replace("&amp;", "&");
            result = result.Replace("&apos;", "\'");
            result = result.Replace("&quot;", "\"");
            return result;
        }

        public static string ToXMLComment(this string x)
        {
            string result = x;
            result = result.Replace("--", "\\-\\-");
            return result;
        }

        public static string FromXMLComment(this string x)
        {
            string result = x;
            result = result.Replace("\\-\\-", "--");
            return result;
        }
    }
}
