using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceRPG.Source.Visuals.Maps.Isometric
{
    public class IsometricMap : Map
    {
        public CombatLayer CombatLayer;
        [XmlElement("IsometricLayer")]
        public List<IsometricLayer> Layers;
        public Vector2 TileOffset;

        public IsometricMap()
            : base()
        {
            Layers = new List<IsometricLayer>();
        }

        public override void LoadContent()
        {
            base.LoadContent();

            if (CombatLayer != null)
                CombatLayer.LoadContent(TileDimensions, TileOffset, MapDimensions);

            foreach (IsometricLayer l in Layers)
            {
                l.LoadContent(TileDimensions, TileOffset, MapDimensions);
            }
        }

        public override void UnloadContent()
        {
            base.UnloadContent();

            foreach (IsometricLayer l in Layers)
                l.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            foreach (IsometricLayer l in Layers)
                l.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch, string drawType)
        {
            base.Draw(spriteBatch, drawType);

            foreach (IsometricLayer l in Layers)
                l.Draw(spriteBatch, drawType);
        }
    }
}
