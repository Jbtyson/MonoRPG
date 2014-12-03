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
        

        public Layer()
        {
            Image = new Image();
            _overlayTiles = new List<Tile>();
            _underlayTiles = new List<Tile>();
            SolidTiles = String.Empty;
            OverlayTiles = String.Empty;
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
                        _state = "Passive";
                        position.X += tileDimensions.X;
                        if (!s.Contains("x"))
                        {
                            Tile tile = new Tile();

                            string str = s.Replace("[", String.Empty);
                            int val1 = int.Parse(str.Substring(0, str.IndexOf(':')));
                            int val2 = int.Parse(str.Substring(str.IndexOf(':') + 1));

                            if (SolidTiles.Contains("[" + val1.ToString() + ":" + val2.ToString() + "]"))
                                _state = "Solid";

                            tile.LoadContent(_state, position, new Rectangle(val1 * (int)tileDimensions.X, val2 * (int)tileDimensions.Y,
                                (int)tileDimensions.X, (int)tileDimensions.Y));

                            if (OverlayTiles.Contains("[" + val1.ToString() + ":" + val2.ToString() + "]"))
                                _overlayTiles.Add(tile);
                            else
                                _underlayTiles.Add(tile);
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
    }
}
