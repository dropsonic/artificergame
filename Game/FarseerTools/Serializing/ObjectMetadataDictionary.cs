using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace FarseerTools
{
    public class ObjectMetadataDictionaryAttribute : Attribute
    {
        private Dictionary<string, object> _dictionary;

        public Dictionary<string, object> Dictionary
        {
            get { return _dictionary; }
            set { _dictionary = value; }
        }

        public ObjectMetadataDictionaryAttribute()
        {
            _dictionary = new Dictionary<string, object>();   
        }
    }

    public static class ObjectMetadataDictionaryExtensions
    {
        /// <summary>
        /// Получает словарь метаданных объекта, доступных по ключу.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static Dictionary<string, object> GetMetadataDictionary(this object x)
        {
            if (x.GetType().IsValueType)
                throw new InvalidOperationException("Cannot write metadata in value type.");

            //Перебираем все атрибуты и ищем среди них ObjectMetadataDictionaryAttribute
            AttributeCollection attributes = TypeDescriptor.GetAttributes(x);
            foreach (Attribute attribute in attributes)
            {
                if (attribute.GetType() == typeof(ObjectMetadataDictionaryAttribute))
                    return (attribute as ObjectMetadataDictionaryAttribute).Dictionary;
            }

            //Если такого атрибута ещё нет, то добавляем его
            ObjectMetadataDictionaryAttribute newAttribute = new ObjectMetadataDictionaryAttribute();
            TypeDescriptor.AddAttributes(x, new Attribute[] { newAttribute });
            return newAttribute.Dictionary;
        }

        /// <summary>
        /// Устанавливает для объекта словарь метаданных, доступных по ключу.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="dictionary"></param>
        public static void SetMetadataDictionary(this object x, Dictionary<string, object> dictionary)
        {
            if (x.GetType().IsValueType)
                throw new InvalidOperationException("Cannot write metadata in value type.");

            TypeDescriptor.AddAttributes(x, new Attribute[] { new ObjectMetadataDictionaryAttribute() { Dictionary = dictionary } });
        }
    }
}
