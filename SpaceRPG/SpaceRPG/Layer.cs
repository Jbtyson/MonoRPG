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
        public Image Image;
        List<Tile> tiles;

        public Layer()
        {
            Image = new Image();
            tiles = new List<Tile>();
        }

        public void LoadContent(Vector2 tileDimensions) 
        {
            Image.LoadContent();
            Vector2 position = -tileDimensions;

            foreach (string row in TMap.Row)
            {
                string[] split = row.Split(']');
                position.X = -tileDimensions.X;
                position.Y += tileDimensions.Y;
                foreach (string s in split)
                {
                    if (s != String.Empty)
                    {
                        position.X += tileDimensions.X;
                        tiles.Add(new Tile());

                        string str = s.Replace("[", String.Empty);
                        int val1 = int.Parse(str.Substring(0, str.IndexOf(':')));
                        int val2 = int.Parse(str.Substring(str.IndexOf(':') + 1));
                        tiles[tiles.Count - 1].LoadContent(position, new Rectangle(val1 * (int)tileDimensions.X, val2 * (int)tileDimensions.Y, 
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
            foreach (Tile tile in tiles)
            {
                Image.Position = tile.Position;
                Image.SourceRect = tile.SourceRect;
                Image.Draw(spriteBatch);
            }
        }
    }
}
