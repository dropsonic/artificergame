using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XMLImporterEx
{
    /// <summary>
    /// Интерфейс для классов-конвертеров величин в string и обратно для сохранения в качестве value xml-тэгов.
    /// </summary>
    public interface IXMLValueConverter
    {
        Type TargetType { get; }
        object Convert(string value);
        string ConvertBack(object value);
    }
}
