// Map.cs
// James Tyson
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using SpaceRPG.Source.Gameplay.Overworld;

namespace SpaceRPG.Source.Visuals.Maps
{
    /// <summary>
    /// Map is the base class for Isometric and Orthogonal tile maps
    /// </summary>
    public class Map
    {
        public Vector2 TileDimensions, MapDimensions;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public Map()
        {
            TileDimensions = Vector2.Zero;
        }

        public virtual void LoadContent()
        {
            
        }

        public virtual void UnloadContent()
        {
            
        }

        public virtual void Update(GameTime gameTime)
        {
            
        }

        public virtual void Draw(SpriteBatch spriteBatch, string drawType)
        {
            
        }
    }
}
