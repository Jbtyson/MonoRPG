// CombatMap.cs
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
    /// CombatMap stores map data relevant to combat, such as tiles that are impassable, height of tiles, and so on (stored as CombatTiles).
    /// </summary>
    public class CombatMap
    {
        public CombatTile[,] Grid;
        public Vector2 TileDimensions, GridDimensions;

        public CombatMap()
        {
            Grid = new CombatTile[0, 0];
            TileDimensions = Vector2.Zero;
        }

        public void LoadContent(Layer combatLayer)
        {
            this.TileDimensions = combatLayer.TileDimensions;
            this.GridDimensions = combatLayer.LayerDimensions;
            Grid = new CombatTile[(int)GridDimensions.X, (int)GridDimensions.Y];
            Tile[,] tiles = combatLayer.GetTileArray2D();

            // Load the content for each combat tile and store it in the grid
            for (int y = 0; y < GridDimensions.Y; y++)
            {
                for (int x = 0; x < GridDimensions.X; x++)
                {
                    Grid[x, y] = new CombatTile();
                    Grid[x, y].LoadContent(tiles[x, y]);
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
