// Map.cs
// James Tyson
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using SpaceRPG.Source.Gameplay.Overworld;

namespace SpaceRPG.Source.Visuals.Maps
{
    /// <summary>
    /// Map represents a ...map
    /// </summary>
    public class Map
    {
        [XmlElement("Layer")]
        public List<Layer> Layers;
        [XmlElement("CombatLayer")]
        public Layer CombatLayer;
        public Vector2 TileDimensions, TileOffset, MapDimensions;
        public Boolean IsIsometric;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public Map()
        {
            Layers = new List<Layer>();
            TileDimensions = Vector2.Zero;
            TileOffset = Vector2.Zero;
        }

        public void LoadContent()
        {
            if(CombatLayer != null)
                CombatLayer.LoadContent(TileDimensions, TileOffset, MapDimensions, IsIsometric);

            foreach (Layer l in Layers)
            {
                l.LoadContent(TileDimensions, TileOffset, MapDimensions, IsIsometric);
            }
        }

        public void UnloadContent()
        {
            foreach (Layer l in Layers)
            {
                l.UnloadContent();
            }
        }

        public void Update(GameTime gameTime)
        {
            // Do nothing for now
        }

        public void Update(GameTime gameTime, ref Player player)
        {
            foreach (Layer l in Layers)
            {
                l.Update(gameTime, ref player);
            }
        }

        public void Draw(SpriteBatch spriteBatch, string drawType)
        {
            foreach (Layer l in Layers)
            {
                l.Draw(spriteBatch, drawType);
            }
        }
    }
}
