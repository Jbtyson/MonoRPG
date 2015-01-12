using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceRPG.Source.Visuals.Maps.Isometric
{
    public class IsometricTile : Tile
    {
        public IsometricTile() 
            : base()
        {

        }

        public override void LoadContent(Vector2 position, Rectangle sourceRect)
        {
            base.LoadContent(position, sourceRect);
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
