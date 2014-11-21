// Layer.cs
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
    /// Layer represents one layer of a map
    /// </summary>
    public class Layer
    {
        private List<Tile> _tiles;
        
        /// <summary>
        /// TileMap is a grid of tiles to represent the world
        /// </summary>
        public class TileMap
        {
            [XmlElement("Row")]
            public List<string> Row;

            /// <summary>
            /// Default constructor
            /// </summary>
            public TileMap()
            {
                Row = new List<string>();
            }
        }

        [XmlElement("TileMap")]
        public TileMap TMap;
        public Image Image;

        public Layer()
        {
            Image = new Image();
            _tiles = new List<Tile>();
        }

        public void LoadContent(Vector2 tileDimensions) 
        {
            Image.LoadContent();
            Vector2 position = -tileDimensions;

            foreach (string row in TMap.Row)
            {
                // Get the tiles
                string[] split = row.Split(']');
                position.X = -tileDimensions.X;
                position.Y += tileDimensions.Y;

                // Loop through all of the tiles and load their content from the tile sheet based on val1 and val2
                foreach (string s in split)
                {
                    if (s != String.Empty)
                    {
                        position.X += tileDimensions.X;
                        _tiles.Add(new Tile());

                        string str = s.Replace("[", String.Empty);
                        int val1 = int.Parse(str.Substring(0, str.IndexOf(':')));
                        int val2 = int.Parse(str.Substring(str.IndexOf(':') + 1));
                        _tiles[_tiles.Count - 1].LoadContent(position, new Rectangle(val1 * (int)tileDimensions.X, val2 * (int)tileDimensions.Y, 
                            (int)tileDimensions.X, (int)tileDimensions.Y));

                    }
                }
            }
        }

        public void UnloadContent()
        {
            Image.UnloadContent();
        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Tile tile in _tiles)
            {
                Image.Position = tile.Position;
                Image.SourceRect = tile.SourceRect;
                Image.Draw(spriteBatch);
            }
        }
    }
}
