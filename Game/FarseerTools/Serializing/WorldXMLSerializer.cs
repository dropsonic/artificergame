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
using FarseerPhysics.Dynamics.Joints;

namespace FarseerTools
{
    public class WorldXMLSerializer : IXMLCustomSerializer
    {
        private static readonly CultureInfo defaultCulture = DefaultConverters.DefaultCulture;

        public Type TargetType
        {
            get { return typeof(World); }
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
            Serializer.SerializeTypeName(root, typeof(World));

            //Сериализуем гравитацию
            World world = (World)rootObject;
            root.Add(
                new XAttribute("Gravity", DefaultConverters.Vector2ToString(world.Gravity)));

            //Сериализуем bodies
            XElement bodies = new XElement("Bodies");
            for (int i = 0; i < world.BodyList.Count; i++)
                bodies.Add(serializer.SerializeObject("Body", world.BodyList[i]));

            //Сериализуем joint'ы
            XElement joints = new XElement("Joints");
            foreach (Joint joint in world.JointList)
                joints.Add(serializer.SerializeObject("Joint", joint));

            root.Add(bodies);
            root.Add(joints);

            return root;
        }

        public object Deserialize(XElement root, Deserializer deserializer)
        {
            //Проверяем, был ли уже сериализован данный объект
            object crObject = deserializer.GetCRObject(root);
            if (crObject != null)
                return crObject;

            //Десериализуем гравитацию и создаём новый world
            Vector2 gravity = (Vector2)DefaultConverters.StringToVector2(root.Attribute("Gravity").Value);
            World world = new World(gravity);
            deserializer.DeserializeMetadata(root, world);
            //Добавляем world в список уже десериализованных объектов
            deserializer.AddToCRList(root, world);

            //Десериализуем bodies
            var bodiesElement = root.Element("Bodies");
            var bodyElements = bodiesElement.Elements("Body");
            foreach (XElement bodyElement in bodyElements)
            {
                Body body = (Body)deserializer.DeserializeObject(bodyElement);
                world.BodyList.Add(body);
            }

            //Десериализуем joint'ы
            var jointsElement = root.Element("Joints");
            var jointElements = jointsElement.Elements("Joint");
            foreach (XElement jointElement in jointElements)
            {
                Joint joint = (Joint)deserializer.DeserializeObject(jointElement);
                world.AddJoint(joint);
            }

            return world;
        }
    }
}
