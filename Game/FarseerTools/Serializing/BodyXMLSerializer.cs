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
    public class BodyXMLSerializer : IXMLCustomSerializer
    {
        public Type TargetType
        {
            get { return typeof(Body); }
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
            Serializer.SerializeTypeName(root, typeof(Body));

            Body body = (Body)rootObject;

            root.Add(
                new XAttribute("BodyType", DefaultConverters.IntToString((int)body.BodyType)),
                new XAttribute("Active", DefaultConverters.BoolToString(body.Enabled)),
                new XAttribute("AllowSleep", DefaultConverters.BoolToString(body.SleepingAllowed)),
                new XAttribute("Angle", DefaultConverters.FloatToString(body.Rotation)),
                new XAttribute("AngularDamping", DefaultConverters.FloatToString(body.AngularDamping)),
                new XAttribute("AngularVelocity", DefaultConverters.FloatToString(body.AngularVelocity)),
                new XAttribute("Awake", DefaultConverters.BoolToString(body.Awake)),
                new XAttribute("Bullet", DefaultConverters.BoolToString(body.IsBullet)),
                new XAttribute("FixedRotation", DefaultConverters.BoolToString(body.FixedRotation)),
                new XAttribute("LinearDamping", DefaultConverters.FloatToString(body.LinearDamping)),
                new XAttribute("LinearVelocity", DefaultConverters.Vector2ToString(body.LinearVelocity)),
                new XAttribute("Position", DefaultConverters.Vector2ToString(body.Position)),
                serializer.SerializeObject("World", SerializerHelpers.GetFieldValue(body, "World")));

            XElement fixtures = new XElement("Fixtures");
            for (int i = 0; i < body.FixtureList.Count; i++)
                fixtures.Add(serializer.SerializeObject("Fixture", body.FixtureList[i]));

            root.Add(fixtures);
            return root;
        }

        public object Deserialize(XElement root, Deserializer deserializer)
        {
            object crObject = deserializer.GetCRObject(root);
            if (crObject != null)
                return crObject;

            World world = (World)deserializer.DeserializeObject(root.Element("World"));
            Body body = new Body(world);
            deserializer.DeserializeMetadata(root, body);
            deserializer.AddToCRList(root, body);

            body.BodyType = (BodyType)DefaultConverters.StringToInt(root.Attribute("BodyType").Value);
            body.Enabled = (bool)DefaultConverters.StringToBool(root.Attribute("Active").Value);
            body.SleepingAllowed = (bool)DefaultConverters.StringToBool(root.Attribute("AllowSleep").Value);
            body.Rotation = (float)DefaultConverters.StringToFloat(root.Attribute("Angle").Value);
            body.AngularDamping = (float)DefaultConverters.StringToFloat(root.Attribute("AngularDamping").Value);
            body.AngularVelocity = (float)DefaultConverters.StringToFloat(root.Attribute("AngularVelocity").Value);
            body.Awake = (bool)DefaultConverters.StringToBool(root.Attribute("Awake").Value);
            body.IsBullet = (bool)DefaultConverters.StringToBool(root.Attribute("Bullet").Value);
            body.FixedRotation = (bool)DefaultConverters.StringToBool(root.Attribute("FixedRotation").Value);
            body.LinearDamping = (float)DefaultConverters.StringToFloat(root.Attribute("LinearDamping").Value);
            body.LinearVelocity = (Vector2)DefaultConverters.StringToVector2(root.Attribute("LinearVelocity").Value);
            body.Position = (Vector2)DefaultConverters.StringToVector2(root.Attribute("Position").Value);

            var fixturesElement = root.Element("Fixtures");
            var fixtureElements = fixturesElement.Elements("Fixture");
            foreach (XElement fixtureElement in fixtureElements)
            {
                Fixture fixture = (Fixture)deserializer.DeserializeObject(fixtureElement);
                body.FixtureList.Add(fixture);
            }

            return body;
        }
    }
}
