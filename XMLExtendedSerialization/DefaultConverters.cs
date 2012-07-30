using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using System.Globalization;

namespace XMLExtendedSerialization
{
    public static class DefaultConverters
    {
        public static readonly CultureInfo DefaultCulture = CultureInfo.CreateSpecificCulture("en-US");
        public static readonly char[] Splitters = new char[] { ' ', ',' };
        public static readonly char DefaultSplitter = Splitters[0];

        #region Convert (string to type)
        public static object StringToBool(string x)
        {
            return bool.Parse(x);
        }

        public static object StringToByte(string x)
        {
            return byte.Parse(x, DefaultCulture);
        }

        public static object StringToChar(string x)
        {
            return char.Parse(x);
        }

        public static object StringToDecimal(string x)
        {
            return decimal.Parse(x, DefaultCulture);
        }

        public static object StringToDouble(string x)
        {
            return double.Parse(x, DefaultCulture);
        }

        public static object StringToFloat(string x)
        {
            return float.Parse(x, DefaultCulture);
        }

        public static object StringToInt(string x)
        {
            return int.Parse(x, DefaultCulture);
        }

        public static object StringToLong(string x)
        {
            return long.Parse(x, DefaultCulture);
        }

        public static object StringToSByte(string x)
        {
            return sbyte.Parse(x, DefaultCulture);
        }

        public static object StringToShort(string x)
        {
            return short.Parse(x, DefaultCulture);
        }

        public static object StringToUInt(string x)
        {
            return uint.Parse(x, DefaultCulture);
        }

        public static object StringToULong(string x)
        {
            return ulong.Parse(x, DefaultCulture);
        }

        public static object StringToUShort(string x)
        {
            return ushort.Parse(x, DefaultCulture);
        }

        public static object StringToColor(string x)
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

        public static object StringToVector2(string x)
        {
            string[] coords = x.Split(Splitters, StringSplitOptions.RemoveEmptyEntries);
            return new Vector2((float)StringToFloat(coords[0]), (float)StringToFloat(coords[1]));
        }

        public static object StringToVector3(string x)
        {
            string[] coords = x.Split(Splitters, StringSplitOptions.RemoveEmptyEntries);
            return new Vector3((float)StringToFloat(coords[0]), (float)StringToFloat(coords[1]), (float)StringToFloat(coords[2]));
        }

        public static object StringToVector4(string x)
        {
            string[] coords = x.Split(Splitters, StringSplitOptions.RemoveEmptyEntries);
            return new Vector4((float)StringToFloat(coords[0]), (float)StringToFloat(coords[1]), (float)StringToFloat(coords[2]), (float)StringToFloat(coords[3]));
        }
        #endregion

        #region Convert back (type to string)
        public static string BoolToString(object x)
        {
            return ((bool)x).ToString(DefaultCulture);
        }

        public static string ByteToString(object x)
        {
            return ((byte)x).ToString(DefaultCulture);
        }

        public static string CharToString(object x)
        {
            return ((char)x).ToString(DefaultCulture);
        }

        public static string DecimalToString(object x)
        {
            return ((decimal)x).ToString(DefaultCulture);
        }

        public static string DoubleToString(object x)
        {
            return ((double)x).ToString(DefaultCulture);
        }

        public static string FloatToString(object x)
        {
            return ((float)x).ToString(DefaultCulture);
        }

        public static string IntToString(object x)
        {
            return ((int)x).ToString(DefaultCulture);
        }

        public static string LongToString(object x)
        {
            return ((long)x).ToString(DefaultCulture);
        }

        public static string SByteToString(object x)
        {
            return ((sbyte)x).ToString(DefaultCulture);
        }

        public static string ShortToString(object x)
        {
            return ((short)x).ToString(DefaultCulture);
        }

        public static string UIntToString(object x)
        {
            return ((uint)x).ToString(DefaultCulture);
        }

        public static string ULongToString(object x)
        {
            return ((ulong)x).ToString(DefaultCulture);
        }

        public static string UShortToString(object x)
        {
            return ((ushort)x).ToString(DefaultCulture);
        }

        public static string ColorToString (object x)
        {
            Color color = (Color)x;
            return String.Format("{0} {1} {2} {3}", color.R, color.G, color.B, color.A);
        }

        public static string Vector2ToString(object x)
        {
            Vector2 vector = (Vector2)x;
            return String.Format(DefaultCulture, "{1}{0}{2}", DefaultSplitter, FloatToString(vector.X), FloatToString(vector.Y));
        }

        public static string Vector3ToString(object x)
        {
            Vector3 vector = (Vector3)x;
            return String.Format("{1}{0}{2}{0}{3}", DefaultSplitter, FloatToString(vector.X), FloatToString(vector.Y), FloatToString(vector.Z));
        }

        public static string Vector4ToString(object x)
        {
            Vector4 vector = (Vector4)x;
            return String.Format(DefaultCulture, "{1}{0}{2}{0}{3}{0}{4}", DefaultSplitter, FloatToString(vector.X), FloatToString(vector.Y), FloatToString(vector.Z), FloatToString(vector.W));
        }
        #endregion
    }
}
