// ICombat.cs
// James Tyson
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceRPG
{
    public interface ICombat
    {
        void Draw(SpriteBatch spriteBatch);

        void Update(GameTime gameTime);

        void LoadContent();

        void UnloadContent();
    }
}
