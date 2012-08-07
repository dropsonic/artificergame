using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Linq;
using System.Reflection;

namespace XMLExtendedSerialization
{
    public class XMLSerializerEx
    {
        private const string SerializeErrorMessage = "Cannot serialize object.";
        private const string DeserializeErrorMessage = "Cannot deserialize object.";

        private List<IXMLCustomSerializer> _customSerializers;

        public XMLSerializerEx() { }

        /// <summary>
        /// Создаёт новый объект XML-сериализатора.
        /// </summary>
        /// <param name="customSerializers">Custom-сериализаторы для указанных типов</param>
        public XMLSerializerEx(List<IXMLCustomSerializer> customSerializers)
        {
            _customSerializers = customSerializers;
        }

        #region Сериализация
        /// <summary>
        /// Сериализует объект в виде XML-документа.
        /// </summary>
        /// <param name="obj">Объект для сериализации.</param>
        /// <param name="stream">Поток, в который будет сохранён XML-документ.</param>
        /// <param name="rootName">Имя корневого тега XML-документа.</param>
        public void Serialize(object obj, Stream stream, string rootName = Settings.DefaultRootName)
        {
            try
            {
                Serializer serializer = _customSerializers == null ? new Serializer() : new Serializer(_customSerializers);
                XDocument document = serializer.Serialize(obj, rootName);
                document.Save(stream);
            }
            catch (Exception ex)
            {
                throw new SerializerException(SerializeErrorMessage, ex);
            }
        }

        /// <summary>
        /// Сериализует объект в виде XML-документа.
        /// </summary>
        /// <param name="obj">Объект для сериализации.</param>
        /// <param name="metadata">Метаданные для сохранения в XML-документ.</param>
        /// <param name="stream">Поток, в который будет сохранён XML-документ.</param>
        /// <param name="rootName">Имя корневого тега XML-документа.</param>
        public void Serialize(object obj, string metadata, Stream stream, string rootName = Settings.DefaultRootName)
        {
            try
            {
                Serializer serializer = _customSerializers == null ? new Serializer() : new Serializer(_customSerializers);
                XDocument document = serializer.Serialize(obj, metadata, rootName);
                document.Save(stream);
            }
            catch (Exception ex)
            {
                throw new SerializerException(SerializeErrorMessage, ex);
            }
        }

        /// <summary>
        /// Сериализует объект в виде XML-документа.
        /// </summary>
        /// <param name="obj">Объект для сериализации.</param>
        /// <param name="rootName">Имя корневого тега XML-документа.</param>
        /// <returns>XML-документ.</returns>
        public XDocument Serialize(object obj, string rootName = Settings.DefaultRootName)
        {
            try
            {
                Serializer serializer = _customSerializers == null ? new Serializer() : new Serializer(_customSerializers);
                return serializer.Serialize(obj, rootName);
            }
            catch (Exception ex)
            {
                throw new SerializerException(SerializeErrorMessage, ex);
            }
        }

        /// <summary>
        /// Сериализует объект в виде XML-документа.
        /// </summary>
        /// <param name="obj">Объект для сериализации.</param>
        /// <param name="metadata">Метаданные для сохранения в XML-документ.</param>
        /// <param name="rootName">Имя корневого тега XML-документа.</param>
        /// <returns>XML-документ.</returns>
        public XDocument Serialize(object obj, string metadata, string rootName = Settings.DefaultRootName)
        {
            try
            {
                Serializer serializer = _customSerializers == null ? new Serializer() : new Serializer(_customSerializers);
                return serializer.Serialize(obj, metadata, rootName);
            }
            catch (Exception ex)
            {
                throw new SerializerException(SerializeErrorMessage, ex);
            }
        }
        #endregion

        #region Десериализация
        public object Deserialize(Stream stream)
        {
            try
            {
                XDocument doc = XDocument.Load(stream);
                Deserializer deserializer = new Deserializer(doc);
                return deserializer.Deserialize();
            }
            catch (Exception ex)
            {
                throw new SerializerException(DeserializeErrorMessage, ex);
            }
        }

        public object Deserialize(Stream stream, out string metadata)
        {
            try
            {
                XDocument doc = XDocument.Load(stream);
                Deserializer deserializer = new Deserializer(doc);
                object result = deserializer.Deserialize(out metadata);
                return result;
            }
            catch (Exception ex)
            {
                throw new SerializerException(DeserializeErrorMessage, ex);
            }
        }

        public object Deserialize(XDocument doc)
        {
            try
            {
                Deserializer deserializer = new Deserializer(doc);
                return deserializer.Deserialize();
            }
            catch (Exception ex)
            {
                throw new SerializerException(DeserializeErrorMessage, ex);
            }
        }
        #endregion
    }
}
