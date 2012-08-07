using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace XMLExtendedSerialization
{
    public static class SerializerHelpers
    {
        private static FieldInfo GetField(object obj, string fieldName)
        {
            Type type = obj.GetType();
            FieldInfo field = type.GetFieldIncludingBase(fieldName, Settings.DefaultFieldFlags);
            if (field == null)
                throw new MissingFieldException(type.FullName, fieldName);

            return field;
        }

        /// <summary>
        /// Возвращает значение поля объекта.
        /// </summary>
        /// <param name="obj">Объект.</param>
        /// <param name="fieldName">Имя поля.</param>
        /// <returns>Значение поля.</returns>
        public static object GetFieldValue(object obj, string fieldName)
        {
            FieldInfo field = GetField(obj, fieldName);
            return field.GetValue(obj);
        }

        /// <summary>
        /// Устанавливает значение в поле объекта.
        /// </summary>
        /// <param name="obj">Объект.</param>
        /// <param name="fieldName">Имя поля.</param>
        /// <param name="value">Значение, которое необходимо установить.</param>
        public static void SetFieldValue(object obj, string fieldName, object value)
        {
            FieldInfo field = GetField(obj, fieldName);
            field.SetValue(obj, value);
        }

        private static PropertyInfo GetProperty(object obj, string propertyName)
        {
            Type type = obj.GetType();
            PropertyInfo property = type.GetPropertyIncludingBase(propertyName, Settings.DefaultFieldFlags);
            if (property == null)
                throw new MissingFieldException(type.FullName, propertyName);

            return property;
        }

        /// <summary>
        /// Возвращает значение свойства объекта.
        /// </summary>
        /// <param name="obj">Объект.</param>
        /// <param name="fieldName">Имя свойства.</param>
        /// <returns>Значение свойства.</returns>
        public static object GetPropertyValue(object obj, string propertyName)
        {
            PropertyInfo property = GetProperty(obj, propertyName);
            return property.GetValue(obj, null);
        }

        /// <summary>
        /// Устанавливает значение в свойство объекта.
        /// </summary>
        /// <param name="obj">Объект.</param>
        /// <param name="fieldName">Имя свойства.</param>
        /// <param name="value">Значение, которое необходимо установить.</param>
        public static void SetPropertyValue(object obj, string propertyName, object value)
        {
            PropertyInfo property = GetProperty(obj, propertyName);
            property.SetValue(obj, value, null);
        }
    }
}
