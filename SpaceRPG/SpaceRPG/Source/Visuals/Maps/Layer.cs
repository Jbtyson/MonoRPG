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

using SpaceRPG.Source.Gameplay;

namespace SpaceRPG.Source.Visuals.Maps
{
    /// <summary>
    /// Layer represents one layer of a map
    /// </summary>
    public class Layer
    {
        private List<Tile> _underlayTiles, _overlayTiles;
        private string _state;
        
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
        public string SolidTiles, OverlayTiles;
        public Image Image;

        public Vector2 TileDimensions, LayerDimensions;

        public Layer()
        {
            Image = new Image();
            _overlayTiles = new List<Tile>();
            _underlayTiles = new List<Tile>();
            SolidTiles = String.Empty;
            OverlayTiles = String.Empty;
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
                        _state = "Passive";
                        position.X += tileDimensions.X;
                        if (!s.Contains("x"))
                        {
                            // Create a new tile and add it to the list
                            Tile t = new Tile();
                            string str = s.Replace("[", String.Empty);
                            t.Value1 = int.Parse(str.Substring(0, str.IndexOf(':')));
                            t.Value2 = int.Parse(str.Substring(str.IndexOf(':') + 1));
                            if (SolidTiles.Contains("[" + t.Value1.ToString() + ":" + t.Value2.ToString() + "]"))
                                _state = "Solid";
                            t.LoadContent(_state, position, new Rectangle(t.Value1 * (int)tileDimensions.X, t.Value2 * (int)tileDimensions.Y,
                                (int)tileDimensions.X, (int)tileDimensions.Y));

                            if (OverlayTiles.Contains("[" + t.Value1.ToString() + ":" + t.Value2.ToString() + "]"))
                                _overlayTiles.Add(t);
                            else
                                _underlayTiles.Add(t);
                        }
                    }
                }
            }
        }

        public void UnloadContent()
        {
            Image.UnloadContent();
        }

        public void Update(GameTime gameTime, ref Player player)
        {
            foreach (Tile tile in _underlayTiles)
                tile.Update(gameTime, ref player);

            foreach (Tile tile in _overlayTiles)
                tile.Update(gameTime, ref player);
        }

        public void Draw(SpriteBatch spriteBatch, string drawType)
        {
            List<Tile> tiles;
            if (drawType == "Underlay")
                tiles = _underlayTiles;
            else
                tiles = _overlayTiles;
            
            
            foreach (Tile tile in tiles)
            {
                Image.Position = tile.Position;
                Image.SourceRect = tile.SourceRect;
                Image.Draw(spriteBatch);
            }
        }

        /// <summary>
        /// Converts the tilemap into a two dimensional Tile array
        /// </summary>
        /// <returns>2D Tile array</returns>
        public Tile[,] GetTileArray2D()
        {
            Tile[,] data = new Tile[(int)LayerDimensions.X, (int)LayerDimensions.Y];
            int x = 0; int y = 0;
            foreach (Tile t in _underlayTiles)
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
