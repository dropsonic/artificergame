using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XMLExtendedSerialization;
using Microsoft.Xna.Framework.Graphics;
using System.Xml.Linq;
using System.IO;

namespace FarseerTools
{
    public class RenderTarget2DXMLSerializer : IXMLCustomSerializer
    {
        private const string TextureFileExtension = ".png";

        private const string FileNameTag = "FileName";
        private const string MetadataFileNameTag = "MetadataFileName";
        private const string TextureMetadataTag = "TextureMetadata";

        public Type TargetType
        {
            get { return typeof(RenderTarget2D); }
        }

        public XElement Serialize(string name, object rootObject, Serializer serializer)
        {
            Texture2D rootTexture = (Texture2D)rootObject;
            var metaDict = rootObject.GetMetadataDictionary();
            if (metaDict.Count == 0)
                return null;

            XElement root = new XElement(name);

            //Обрабатываем кольцевые ссылки
            if (serializer.CheckCircularReferences(root, rootObject))
                return root;

            //Сохраняем файл текстуры
            Texture2D texture = (Texture2D)metaDict[ShapeParametersKeys.Texture];

            if (!Directory.Exists(TextureSerializerSettings.FilePath))
                Directory.CreateDirectory(TextureSerializerSettings.FilePath);

            string fileName = TextureSerializerSettings.FilePath + texture.Name + TextureFileExtension;
            if (!File.Exists(fileName))
            {
                using (Stream stream = File.Create(fileName))
                {
                    texture.SaveAsPng(stream, rootTexture.Width, rootTexture.Height);
                }
            }
            root.Add(new XAttribute(FileNameTag, fileName.ToXMLValue()));
            //Сохраняем все метаданные текстуры как элемент тега
            root.Add(serializer.SerializeObject(TextureMetadataTag, metaDict));

            //Записываем метаданные объекта
            Serializer.SerializeMetadata(root, rootObject);
            
            return root;
        }

        public object Deserialize(XElement element, Deserializer deserializer)
        {
            object root;

            root = deserializer.DeserializeObject(element);

            return root;
        }
    }
}
