using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XMLExtendedSerialization
{
    public static class StringXMLExtensions
    {
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
    }
}
