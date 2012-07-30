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
    public class Texture2DXMLSerializer : IXMLCustomSerializer
    {
        private const string TextureFileExtension = ".png";

        private const string FileNameTag = "FileName";
        private const string MetadataFileNameTag = "MetadataFileName";
        private const string TextureMetadataTag = "TextureMetadata";

        public Type TargetType
        {
            get { return typeof(Texture2D); }
        }

        public XElement Serialize(object obj, string fieldName)
        {
            XElement root = new XElement(fieldName);
            Texture2D rootObject = (Texture2D)obj;

            //Если метаданных в словаре нет, то просто сохраняем файл текстуры
            string fileName = root.Name + TextureFileExtension;
            if (obj.GetMetadataDictionary().Count == 0)
            {
                using (Stream stream = File.Create(fileName))
                {
                    rootObject.SaveAsPng(stream, rootObject.Width, rootObject.Height);
                }

                root.Add(new XAttribute(FileNameTag, fileName.ToXMLValue()));
            }
            //Иначе сохраняем все метаданные текстуры как элемент тега
            else
            {
                var metaDict = rootObject.GetMetadataDictionary();
                XDocument doc = XMLSerializerEx.Serialize(metaDict, TextureMetadataTag);
                root.Add(doc.Root); 
            }

            //Записываем метаданные объекта
            SerializerHelpers.SerializeMetadata(root, rootObject);
            
            return root;
        }

        public object Deserialize(XElement element)
        {
            object root;
            throw new NotImplementedException();
            //TODO: написать десериализацию
            return root;
        }
    }
}
