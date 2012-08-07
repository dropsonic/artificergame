using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XMLExtendedSerialization;
using FarseerPhysics.Dynamics;
using System.Xml.Linq;
using System.Globalization;
using FarseerPhysics.Collision.Shapes;
using Microsoft.Xna.Framework;

namespace FarseerTools
{
    public class FixtureXMLSerializer : IXMLCustomSerializer
    {
        public Type TargetType
        {
            get { return typeof(Fixture); }
        }

        public XElement Serialize(string name, object rootObject, Serializer serializer)
        {
            XElement root = new XElement(name);

            //Обрабатываем кольцевые ссылки
            if (serializer.CheckCircularReferences(root, rootObject))
                return root;

            //Сериализуем метаданные
            Serializer.SerializeMetadata(root, rootObject);
            //Сериализуем имя типа
            Serializer.SerializeTypeName(root, typeof(Fixture));

            Fixture fixture = (Fixture)rootObject;

            root.Add(serializer.SerializeObject("Shape", fixture.Shape));
            root.Add(
                new XAttribute("CategoryBits", DefaultConverters.IntToString((int)fixture.CollisionCategories)),
                new XAttribute("MaskBits", DefaultConverters.IntToString((int)fixture.CollidesWith)),
                new XAttribute("GroupIndex", DefaultConverters.ShortToString(fixture.CollisionGroup)),
                new XAttribute("Friction", DefaultConverters.FloatToString(fixture.Friction)),
                new XAttribute("IsSensor", DefaultConverters.BoolToString(fixture.IsSensor)),
                new XAttribute("Restitution", DefaultConverters.FloatToString(fixture.Restitution)),
                serializer.SerializeObject("Body", fixture.Body));
            return root;
        }

        public object Deserialize(XElement root, Deserializer deserializer)
        {
            object crObject = deserializer.GetCRObject(root);
            if (crObject != null)
                return crObject;

            Body body = (Body)deserializer.DeserializeObject(root.Element("Body"));
            Shape shape = (Shape)deserializer.DeserializeObject(root.Element("Shape"));
            Fixture fixture = new Fixture(body, shape);
            deserializer.DeserializeMetadata(root, fixture);
            deserializer.AddToCRList(root, fixture);

            fixture.CollisionCategories = (Category)DefaultConverters.StringToInt(root.Attribute("CategoryBits").Value);
            fixture.CollidesWith = (Category)DefaultConverters.StringToInt(root.Attribute("MaskBits").Value);
            fixture.CollisionGroup = (short)DefaultConverters.StringToShort(root.Attribute("GroupIndex").Value);
            fixture.Friction = (float)DefaultConverters.StringToFloat(root.Attribute("Friction").Value);
            fixture.IsSensor = (bool)DefaultConverters.StringToBool(root.Attribute("IsSensor").Value);
            fixture.Restitution = (float)DefaultConverters.StringToFloat(root.Attribute("Restitution").Value);

            return fixture;
        }
    }
}
