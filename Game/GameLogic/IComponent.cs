using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;

namespace GameLogic
{
    public interface IComponent
    {
        void Initialize();
        void LoadContent(ContentManager content);
    }
}
