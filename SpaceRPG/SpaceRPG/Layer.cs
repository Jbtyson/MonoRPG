﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceRPG
{
    public class Layer
    {
        public class TileMap
        {
            [XmlElement("Row")]
            public List<string> Row;
            public TileMap()
            {
                Row = new List<string>();
            }
        }
        [XmlElement("TileMap")]
        public TileMap TMap;
        List<Tile> tiles;

        public Layer()
        {

        }

        public void LoadContent(Vector2 tileDimensions) 
        {
            foreach (string row in TMap.Row)
            {
                string[] split = row.Split(']');
                foreach (string s in split)
                {
                    if (s != String.Empty)
                    {
                        string str = s.Replace("[", String.Empty);
                        int val1 = int.Parse(str.Substring(0, str.IndexOf(':')));
                        int val2 = int.Parse(str.Substring(str.IndexOf(':') + 1));
                    }
                }
            }
        }

        public void UnloadContent()
        {

        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {

        }
    }
}
