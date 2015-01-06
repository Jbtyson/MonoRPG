using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace TilemapEditor
{
    public class Map
    {
        [XmlElement("Layer")]
        public List<Layer> Layer;
        public Vector2 TileDimensions;
        public bool Loaded = false;

        public Map()
        {
            Layer = new List<Layer>();
            TileDimensions = Vector2.Zero;
        }

        public void Initialize(ContentManager content)
        {
            foreach(Layer l in Layer)
                l.Initialize(content, TileDimensions);
            Loaded = true;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if(Loaded)
                foreach (Layer l in Layer)
                    l.Draw(spriteBatch);
        }
    }
}
