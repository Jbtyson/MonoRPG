// CombatLayer.cs
// James Tyson
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceRPG.Source.Visuals.Maps.Isometric
{
    /// <summary>
    /// Combat layer will sit on top of an isometric tile layer
    /// </summary>
    public class CombatLayer : IsometricLayer
    {
        public CombatLayer()
            : base()
        {

        }

        public override void LoadContent(Vector2 tileDimensions, Vector2 tileOffset, Vector2 mapDimensions)
        {
            //base.LoadContent();
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
