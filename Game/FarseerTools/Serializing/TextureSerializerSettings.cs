using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FarseerTools
{
    public static class TextureSerializerSettings
    {
        /// <summary>
        /// Каталог, куда сохраняются текстуры.
        /// </summary>
        private const string _directory = @"\GameLevelTextures";

        public static string FilePath
        {
            get
            {
                //temp + dir + id
                return new StringBuilder(System.IO.Path.GetTempPath()).Append(_directory).Append(AppDomain.GetCurrentThreadId()).Append(@"\").ToString();
            }
        }
    }
}
