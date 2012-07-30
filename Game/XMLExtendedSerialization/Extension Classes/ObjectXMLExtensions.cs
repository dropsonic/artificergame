using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace XMLExtendedSerialization
{
    public static class ObjectXMLExtensions
    {
        /// <summary>
        /// Получает метаданные из объекта, если он их содержит.
        /// </summary>
        /// <param name="x"></param>
        /// <returns>Метаданные; null в случае, если метаданных нет.</returns>
        public static string GetXMLMetadata(this object x)
        {
            if (!x.GetType().IsClass)
                throw new InvalidOperationException("Cannot read metadata from value type.");

            AttributeCollection attributes = TypeDescriptor.GetAttributes(x);
            foreach (Attribute attribute in attributes)
            {
                if (attribute.GetType().SameType(typeof(XMLMetadataAttribute)))
                    return (attribute as XMLMetadataAttribute).Metadata;
            }

            return null;
        }

        /// <summary>
        /// Сохраняет метаданные в объект.
        /// </summary>
        public static void SetXMLMetadata(this object x, string metadata)
        {
            if (x.GetType().IsValueType)
                throw new InvalidOperationException("Cannot write metadata in value type.");

            TypeDescriptor.AddAttributes(x, new Attribute[] { new XMLMetadataAttribute(metadata) });
        }
    }
}
