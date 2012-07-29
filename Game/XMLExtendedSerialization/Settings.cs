using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XMLExtendedSerialization
{
    /// <summary>
    /// Содержит настройки (константы) для сериализатора и десериализатора.
    /// </summary>
    internal static class Settings
    {
        /// <summary>
        /// Значение корневого тега XML-документа по умолчанию.
        /// </summary>
        internal const string DefaultRootName = "Object";

        /// <summary>
        /// Размер словаря ссылок по умолчанию.
        /// </summary>
        internal const int DefaultRefListSize = 32;

        internal const string TypeNameTag = "Type-";
        internal const string LengthTag = "Length-";
        internal const string IndexTag = "Index-";

        internal const string ArrayElementTag = "Element";

        internal const string DictionaryItemTag = "Item";
        internal const string DictionaryKeyTag = "Key";
        internal const string DictionaryValueTag = "Value";

        internal const string EnumValueAttribute = "value__";

        /// <summary>
        /// Содержит настройки работы сериализатора/десериализатора в режиме отладки.
        /// </summary>
        internal static class Debug
        {
            /// <summary>
            /// Максимальная глубина рекурсии сериализатора до вызова исключения.
            /// </summary>
            internal const int MaxRecursionDepth = 3000;
        }
    }
}
