using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FarseerPhysics.Dynamics;
using Microsoft.Xna.Framework;
using System.IO;
using GameLogic;

namespace LevelEditor.Helpers
{
    public class CommonHelpers
    {
        public static Body FindBody(Vector2 point,World world)
        {
            Fixture foundFixture = world.TestPoint(point);
            if (foundFixture != null)
            {
                return foundFixture.Body;
            }
            else
            {
                return null;
            }
        }

        public static GameObjectPart FindGameObjectPart(Vector2 point, GameLevel gameLevel)
        {
            return FindGameObjectPart(gameLevel, FindBody(point, gameLevel.World));
        }
        public static GameObjectPart FindGameObjectPart(GameLevel gameLevel, Body body)
        {
            foreach (GameObject go in gameLevel)
                foreach (GameObjectPart gop in go)
                    if (gop.Body == body)
                        return gop;
            return null;
        }
        public static GameObjectPart FindGameObjectPart(Vector2 point, GameObject gameObject)
        {
            return FindGameObjectPart(gameObject, FindBody(point, gameObject.World));
        }
        public static GameObjectPart FindGameObjectPart(GameObject gameObject, Body body)
        {
            foreach (GameObjectPart gop in gameObject)
                if (gop.Body == body)
                    return gop;
            return null;
        }

        public static GameObject FindGameObject(Vector2 point, GameLevel gameLevel)
        {
            return FindGameObject(gameLevel, FindBody(point, gameLevel.World));
        }
        public static GameObject FindGameObject(GameLevel gameLevel, Body body)
        {
            foreach (GameObject go in gameLevel)
                foreach (GameObjectPart gop in go)
                    if (gop.Body == body)
                        return go;
            return null;
        }

        public static Vector2 CalculateLocalPoint(Vector2 position, Body body)
        {
            return Vector2.Transform(position - body.Position, Matrix.CreateRotationZ(-body.Rotation));
        }

        public static string GetParent(string path, int nesting)
        {
            return nesting == 0 ? path : GetParent(Directory.GetParent(path).ToString(), --nesting);
        }

  
    }
}
