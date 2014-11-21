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

namespace SpaceRPG
{
    /// <summary>
    /// Map represents a ...map
    /// </summary>
    public class Map
    {
        [XmlElement("Layer")]
        public List<Layer> Layers;
        public Vector2 TileDimensions;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public Map()
        {
            Layers = new List<Layer>();
            TileDimensions = Vector2.Zero;
        }

        public void LoadContent()
        {
            foreach (Layer l in Layers)
            {
                l.LoadContent(TileDimensions);
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
            foreach (Layer l in Layers)
            {
                l.Update(gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Layer l in Layers)
            {
                l.Draw(spriteBatch);
            }
        }
    }
}
