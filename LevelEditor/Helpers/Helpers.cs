using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FarseerPhysics.Dynamics;
using Microsoft.Xna.Framework;
using System.IO;

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

        public static string GetParent(string path, int nesting)
        {
            return nesting == 0 ? path : GetParent(Directory.GetParent(path).ToString(), --nesting);
        }

  
    }
}
