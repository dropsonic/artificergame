using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Graphics;
using Microsoft.Xna.Framework.Content.Pipeline.Processors;
using Microsoft.Xna.Framework.Graphics;

namespace XMLImporterEx
{
    [ContentImporter(".xml", DisplayName = "XML Content - Extended Importer")]
    public class XMLImporterEx : ContentImporter<object>
    {
        public override object Import(string filename, ContentImporterContext context)
        {
            using (Stream stream = File.OpenRead(filename))
            {
                try
                {
                    return XMLSerializerEx.Deserialize(stream);
                }
                catch (Exception ex)
                {
                    throw new InvalidContentException(ex.Message, ex);
                }
            }
        }
    }
}