using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using System.Globalization;

namespace XMLExtendedSerialization
{
    internal static class DefaultConverters
    {
        private static readonly CultureInfo defaultCulture = CultureInfo.CreateSpecificCulture("en-US");
        private static readonly char[] splitters = new char[] { ' ', ',' };
        private static readonly char defaultSplitter = splitters[0];

        #region Convert (string to type)
        internal static object StringToBool(string x)
        {
            return bool.Parse(x);
        }

        internal static object StringToByte(string x)
        {
            return byte.Parse(x, defaultCulture);
        }

        internal static object StringToChar(string x)
        {
            return char.Parse(x);
        }

        internal static object StringToDecimal(string x)
        {
            return decimal.Parse(x, defaultCulture);
        }

        internal static object StringToDouble(string x)
        {
            return double.Parse(x, defaultCulture);
        }

        internal static object StringToFloat(string x)
        {
            return float.Parse(x, defaultCulture);
        }

        internal static object StringToInt(string x)
        {
            return int.Parse(x, defaultCulture);
        }

        internal static object StringToLong(string x)
        {
            return long.Parse(x, defaultCulture);
        }

        internal static object StringToSByte(string x)
        {
            return sbyte.Parse(x, defaultCulture);
        }

        internal static object StringToShort(string x)
        {
            return short.Parse(x, defaultCulture);
        }

        internal static object StringToUInt(string x)
        {
            return uint.Parse(x, defaultCulture);
        }

        internal static object StringToULong(string x)
        {
            return ulong.Parse(x, defaultCulture);
        }

        internal static object StringToUShort(string x)
        {
            return ushort.Parse(x, defaultCulture);
        }

        internal static object StringToColor(string x)
        {
            string[] coords = x.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            if (coords.Length < 3)
                throw new ArgumentException();

            int r = int.Parse(coords[0]);
            int g = int.Parse(coords[1]);
            int b = int.Parse(coords[2]);
            if (coords.Length > 3)
            {
                int a = int.Parse(coords[3]);
                return new Color(r, g, b, a);
            }
            else
                return new Color(r, g, b);
        }

        internal static object StringToVector2(string x)
        {
            string[] coords = x.Split(splitters, StringSplitOptions.RemoveEmptyEntries);
            return new Vector2((float)StringToFloat(coords[0]), (float)StringToFloat(coords[1]));
        }

        internal static object StringToVector3(string x)
        {
            string[] coords = x.Split(splitters, StringSplitOptions.RemoveEmptyEntries);
            return new Vector3((float)StringToFloat(coords[0]), (float)StringToFloat(coords[1]), (float)StringToFloat(coords[2]));
        }

        internal static object StringToVector4(string x)
        {
            string[] coords = x.Split(splitters, StringSplitOptions.RemoveEmptyEntries);
            return new Vector4((float)StringToFloat(coords[0]), (float)StringToFloat(coords[1]), (float)StringToFloat(coords[2]), (float)StringToFloat(coords[3]));
        }
        #endregion

        #region Convert back (type to string)
        internal static string BoolToString(object x)
        {
            return ((bool)x).ToString(defaultCulture);
        }

        internal static string ByteToString(object x)
        {
            return ((byte)x).ToString(defaultCulture);
        }

        internal static string CharToString(object x)
        {
            return ((char)x).ToString(defaultCulture);
        }

        internal static string DecimalToString(object x)
        {
            return ((decimal)x).ToString(defaultCulture);
        }

        internal static string DoubleToString(object x)
        {
            return ((double)x).ToString(defaultCulture);
        }

        internal static string FloatToString(object x)
        {
            return ((float)x).ToString(defaultCulture);
        }

        internal static string IntToString(object x)
        {
            return ((int)x).ToString(defaultCulture);
        }

        internal static string LongToString(object x)
        {
            return ((long)x).ToString(defaultCulture);
        }

        internal static string SByteToString(object x)
        {
            return ((sbyte)x).ToString(defaultCulture);
        }

        internal static string ShortToString(object x)
        {
            return ((short)x).ToString(defaultCulture);
        }

        internal static string UIntToString(object x)
        {
            return ((uint)x).ToString(defaultCulture);
        }

        internal static string ULongToString(object x)
        {
            return ((ulong)x).ToString(defaultCulture);
        }

        internal static string UShortToString(object x)
        {
            return ((ushort)x).ToString(defaultCulture);
        }

        internal static string ColorToString (object x)
        {
            Color color = (Color)x;
            return String.Format("{0} {1} {2} {3}", color.R, color.G, color.B, color.A);
        }

        internal static string Vector2ToString(object x)
        {
            Vector2 vector = (Vector2)x;
            return String.Format("{1}{0}{2}", defaultSplitter, vector.X, vector.Y);
        }

        internal static string Vector3ToString(object x)
        {
            Vector3 vector = (Vector3)x;
            return String.Format("{1}{0}{2}{0}{3}", defaultSplitter, vector.X, vector.Y, vector.Z);
        }

        internal static string Vector4ToString(object x)
        {
            Vector4 vector = (Vector4)x;
            return String.Format("{1}{0}{2}{0}{3}{0}{4}", defaultSplitter, vector.X, vector.Y, vector.Z, vector.W);
        }
        #endregion
    }
}
