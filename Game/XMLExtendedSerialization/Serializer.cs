//#define SAVEDEBUGINFO
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Linq;
using System.Reflection;
using Microsoft.Xna.Framework;
using System.Collections;

namespace XMLExtendedSerialization
{
    public class Serializer
    {
#if SAVEDEBUGINFO
        private XDocument _document;
        private int _recursionDepth = 0;
        private List<string> _refListContent;
#endif
        private Dictionary<Type, Func<object, string>> _converters;

        private Dictionary<object, string> _refList;

        private Dictionary<object, IXMLCustomSerializer> _customSerializers;

        /// <summary>
        /// Список из всех сериализованных reference-type объектов.
        /// Ключ - ссылка на объект, значение - hash-код объекта.
        /// </summary>
        public Dictionary<object, string> RefList
        {
            get { return _refList; }
            set { _refList = value; }
        }

        private void InitializeConverters()
        {
            _converters = new Dictionary<Type, Func<object, string>>();

            //Default types
            _converters.Add(typeof(string), x => (string)x);
            _converters.Add(typeof(bool), DefaultConverters.BoolToString);
            _converters.Add(typeof(byte), DefaultConverters.ByteToString);
            _converters.Add(typeof(char), DefaultConverters.CharToString);
            _converters.Add(typeof(decimal), DefaultConverters.DecimalToString);
            _converters.Add(typeof(double), DefaultConverters.DoubleToString);
            _converters.Add(typeof(float), DefaultConverters.FloatToString);
            _converters.Add(typeof(int), DefaultConverters.IntToString);
            _converters.Add(typeof(long), DefaultConverters.LongToString);
            _converters.Add(typeof(sbyte), DefaultConverters.SByteToString);
            _converters.Add(typeof(short), DefaultConverters.ShortToString);
            _converters.Add(typeof(uint), DefaultConverters.UIntToString);
            _converters.Add(typeof(ulong), DefaultConverters.ULongToString);
            _converters.Add(typeof(ushort), DefaultConverters.UShortToString);

            _converters.Add(typeof(Color), DefaultConverters.ColorToString);
            _converters.Add(typeof(Vector2), DefaultConverters.Vector2ToString);
            _converters.Add(typeof(Vector3), DefaultConverters.Vector3ToString);
            _converters.Add(typeof(Vector4), DefaultConverters.Vector4ToString);
        }

        internal Serializer()
        {
            _refList = new Dictionary<object, string>(Settings.DefaultRefListSize);
            _customSerializers = new Dictionary<object, IXMLCustomSerializer>();

            InitializeConverters();

#if SAVEDEBUGINFO
            _document = new XDocument();
            _document.Add(new XElement("Root"));
            _refListContent = new List<string>(Settings.DefaultRefListSize);
#endif
        }

        internal Serializer(List<IXMLCustomSerializer> customSerializers)
            : this()
        {
            foreach (var serializer in customSerializers)
                _customSerializers.Add(serializer.TargetType, serializer);
        }

        public static void SerializeMetadata(XElement root, object rootObject)
        {
            if (rootObject.GetType().IsClass)
            {
                string metadata = rootObject.GetXMLMetadata();
                if (metadata != null)
                    root.Add(new XComment(metadata.ToXMLComment()));
            }
        }

        public static void SerializeTypeName(XElement root, Type rootType)
        {
            root.Add(new XAttribute(Settings.TypeNameTag, rootType.FullName.ToXMLValue()));
        }

        public static void SerializeCustomSerializerName(XElement root, IXMLCustomSerializer serializer)
        {
            if (root != null)
                root.Add(new XAttribute(Settings.CustomSerializerNameTag, serializer.GetType().FullName.ToXMLValue()));
        }

        /// <summary>
        /// Проверяет наличие у поля атрибута XMLCustomConverterAttribute и добавляет его значение в словарь конвертеров.
        /// </summary>
        private void CheckCustomConverter(FieldInfo field)
        {
            Attribute[] attributes = Attribute.GetCustomAttributes(field);
            foreach (Attribute attribute in attributes)
            {
                if (attribute.GetType().SameType(typeof(XMLCustomConverterAttribute)))
                {
                    IXMLValueConverter converter = (attribute as XMLCustomConverterAttribute).Converter;
                    if (_converters.ContainsKey(converter.TargetType))
                        _converters.Remove(converter.TargetType);
                    _converters.Add(converter.TargetType, converter.ConvertBack);
                }
            }
        }

        /// <summary>
        /// Обрабатывает кольцевые ссылки.
        /// </summary>
        /// <param name="root">Корневой элемент, в который добавляется информация.</param>
        /// <param name="rootObject">Объект для сериализации.</param>
        /// <returns>true, если объект уже был в списке; false в случаях, если объект value-type или его ещё не было в списке (требуется обычная сериализация).</returns>
        public bool CheckCircularReferences(XElement root, object rootObject)
        {
            Type rootType = rootObject.GetType();

            //Если reference-type, то добавляем объект в список
            if (!rootType.IsValueType)
            {
                //Если в списке ссылок на объекты этого объекта ещё нет, то добавляем его
                string hashCode;
                if (_refList.TryGetValue(rootObject, out hashCode))
                {
                    root.Add(hashCode.ToXMLValue());
                    return true;
                }
                else
                {
#if SAVEDEBUGINFO
                    root.Add(new XComment(String.Format("_refList index: {0}, type: {1}", _refList.Count, rootType.FullName)));
                    _refListContent.Add(rootType.FullName);
#endif
                    hashCode = _refList.Count.ToString();
                    _refList.Add(rootObject, hashCode);
                    root.Add(new XAttribute(Settings.CRIndexAttributeName, hashCode.ToXMLValue()));
                }
            }

            return false;
        }

        /// <summary>
        /// Рекурсивно сериализует объект.
        /// </summary>
        public XElement SerializeObject(string name, object rootObject)
        {
#if SAVEDEBUGINFO
            _recursionDepth++;
            if (_recursionDepth > Settings.Debug.MaxRecursionDepth)
                throw new ApplicationException("DEBUG: Max recursion depth.");
#endif
            Type rootType = rootObject.GetType();
            XElement element;
            //Проверяем наличие custom-сериализатора для данного типа
            IXMLCustomSerializer serializer;
            if (_customSerializers.TryGetValue(rootType, out serializer))
            {
                element = serializer.Serialize(name, rootObject, this);
                SerializeCustomSerializerName(element, serializer); //сохраняем имя типа сериализатора
                return element;
            }

            if (rootObject == null)
                return new XElement(name, null);

            //Делегаты не сериализуем
            if (rootObject is Delegate)
                return null;

            //Указатели тоже не сериализуем
            if (rootObject is Pointer)
                return null;

            element = new XElement(name);

            //Обрабатывает кольцевые ссылки
            if (CheckCircularReferences(element, rootObject))
                return element; //если объект уже был в списке ссылок, то возвращаем его

            //Записываем информацию о типе
            SerializeTypeName(element, rootType);
            //Записываем метаданные
            SerializeMetadata(element, rootObject);

            if (rootObject is string)
            {
                element.Add(((string)rootObject).ToXMLValue());
                return element;
            }

            //Если объект - словарь, то сериализуем его в отдельном методе. В принципе, работает и без этого, но XML тогда не такой читаемый и больше по объему.
            if (rootObject is IDictionary)
            {
                SerializeDictionary(element, (IDictionary)rootObject);
                return element;
            }

            //Если объект - массив, сериализуем его в отдельном методе
            if (rootType.IsArray)
            {
                SerializeArray(element, (Array)rootObject);
                return element;
            }

            //Если объект - generic, сериализуем его в отдельном методе
            //if (rootType.IsGenericType)
            //    return SerializeGenericObject(name, rootObject);

            //Получаем все поля объекта
            IEnumerable<FieldInfo> fields = rootType.GetFieldsIncludingBase(Settings.DefaultFieldFlags);
            //PropertyInfo[] properties = rootType.GetProperties(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

            foreach (var field in fields)
            {
                //Проверяем на отсутствие атрибута XMLDoNotSerialize
                if (!field.HasAttribute(typeof(XMLDoNotSerializeAttribute)))
                {
                    //Проверяем наличие специального конвертера для данного типа
                    CheckCustomConverter(field);

                    Func<object, string> converter;
                    object fieldValue = field.GetValue(rootObject);
                    string xmlFieldName = field.GetXMLName();

                    if (fieldValue == null)
                    {
                        element.SetAttributeValue(xmlFieldName, fieldValue);
                        continue;
                    }

                    //Если конвертер для данного типа данных уже есть
                    if (_converters.TryGetValue(field.FieldType, out converter))
                        //то записываем значение поля как атрибут
                        element.SetAttributeValue(xmlFieldName, converter(fieldValue).ToXMLValue());
                    //Если конвертера для данного типа данных нет, то сериализуем его как сложный тип
                    else
                    {
                        XElement child = SerializeObject(xmlFieldName, fieldValue);
                        element.Add(child);
                    }
                }
            }
#if SAVEDEBUGINFO
            _document.Root.Add(element);
#endif
            return element;
        }

        /// <summary>
        /// Сериализует массив элементов.
        /// </summary>
        /// <param name="root">XML-элемент, в который необходимо записать данные.</param>
        /// <param name="rootObject">Массив для записи.</param>
        internal void SerializeArray(XElement root, Array rootObject)
        {
            Type rootType = rootObject.GetType();
            Type elementType = rootType.GetElementType();

#if SAVEDEBUGINFO
                if (_refList.ContainsKey(rootObject))
                    root.Add(new XComment(String.Format("_refList index: {0}, type: {1}", _refList[rootObject], rootType.FullName)));
#endif

            object defaultValue;
            if (elementType.IsValueType)
                defaultValue = System.Runtime.Serialization.FormatterServices.GetUninitializedObject(elementType);
            else
                defaultValue = null;

            root.Add(new XAttribute(Settings.LengthTag, rootObject.Length.ToString()));

            for (int i = 0; i < rootObject.Length; i++)
            {
                object item = rootObject.GetValue(i);
                if (!object.Equals(item, defaultValue))
                {
                    XElement xItem = SerializeObject(Settings.ArrayElementTag, item);
                    xItem.Add(new XAttribute(Settings.IndexTag, i));
                    root.Add(xItem);
                }
            }
        }

        /// <summary>
        /// Сериализует словарь типа "ключ-значение".
        /// </summary>
        /// <param name="root">XML-элемент, в который необходимо записать информацию о словаре.</param>
        /// <param name="rootObject">Словарь для записи.</param>
        /// <returns>XML-элемент с данными о словаре.</returns>
        internal void SerializeDictionary(XElement root, IDictionary rootObject)
        {
#if SAVEDEBUGINFO
                if (_refList.ContainsKey(rootObject))
                    root.Add(new XComment(String.Format("_refList index: {0}, type: {1}", _refList[rootObject], rootObject.GetType().FullName)));
#endif

            foreach (DictionaryEntry item in rootObject)
            {
                XElement itemElement = new XElement(Settings.DictionaryItemTag);
                itemElement.Add(SerializeObject(Settings.DictionaryKeyTag, item.Key));
                itemElement.Add(SerializeObject(Settings.DictionaryValueTag, item.Value));
                root.Add(itemElement);
            }
        }

        internal XDocument Serialize(object rootObject, string rootName = Settings.DefaultRootName)
        {
            return Serialize(rootObject, false, String.Empty, rootName);
        }

        internal XDocument Serialize(object rootObject, string metadata, string rootName = Settings.DefaultRootName)
        {
            return Serialize(rootObject, true, metadata, rootName);
        }

        internal XDocument Serialize(object rootObject, bool addMetadata, string metadata, string rootName)
        {
            XDocument document = new XDocument();
#if SAVEDEBUGINFO
            try
            {
#endif
            if (addMetadata)
                document.Add(new XComment(metadata.ToXMLComment()));
            document.Add(SerializeObject(rootName.GetFullNameFromXML(), rootObject));
#if SAVEDEBUGINFO
            }
            finally
            {
                using (Stream debugStream = File.Create("XML debug info.xml"))
                {
                    _document.Save(debugStream);
                }

                System.Diagnostics.Debug.WriteLine("");
                System.Diagnostics.Debug.WriteLine("S E R I A L I Z E R _refList content ({0} elements):", _refList.Count);
                foreach (string s in _refListContent)
                    System.Diagnostics.Debug.WriteLine(s);
                System.Diagnostics.Debug.WriteLine("");
                //throw ex;
            }
#endif
            return document;
        }
    }
}