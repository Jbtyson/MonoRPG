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
        public Vector2 TileDimensions, LayerDimensions;

        public Layer()
        {
            Image = new Image();
            _tiles = new List<Tile>();
            TileDimensions = Vector2.Zero;
            LayerDimensions = Vector2.Zero;
        }

        public void LoadContent(Vector2 tileDimensions) 
        {
            if(Image.Path != String.Empty)
                Image.LoadContent();
            Vector2 position = -tileDimensions;

            // Save the dimensions of the layer
            LayerDimensions.Y = TMap.Row.Count;
            LayerDimensions.X = TMap.Row[0].Split('[').Length-1;

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
                        // Create a new tile and add it to the list
                        Tile t = new Tile();
                        string str = s.Replace("[", String.Empty);
                        t.Value1 = int.Parse(str.Substring(0, str.IndexOf(':')));
                        t.Value2 = int.Parse(str.Substring(str.IndexOf(':') + 1));
                        t.LoadContent(position, new Rectangle(t.Value1 * (int)tileDimensions.X, t.Value2 * (int)tileDimensions.Y, 
                            (int)tileDimensions.X, (int)tileDimensions.Y));
                        _tiles.Add(t);

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

        public Tile[,] GetTileArray2D()
        {
            Tile[,] data = new Tile[(int)LayerDimensions.X, (int)LayerDimensions.Y];
            int x = 0; int y = 0;
            foreach (Tile t in _tiles)
            {
                data[x,y] = t;
                x++;
                if (x > LayerDimensions.X - 1)
                {
                    x = 0;
                    y++;
                }
            }
            return data;
        }
    }
}
