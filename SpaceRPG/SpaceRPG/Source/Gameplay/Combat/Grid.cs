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
    class Grid
    {
        public CombatTile[,] Board;
        public Vector2 GridDimensions;

        public Grid()
        {
            Board = new CombatTile[0, 0];
            GridDimensions = Vector2.Zero;
        }

        public void LoadContent(Map _map)
        {
            Layer combatlayer = _map.Layers[1];
            GridDimensions = _map.TileDimensions;
            Board = new CombatTile[(int)GridDimensions.X, (int)GridDimensions.Y];


            //Initialize Board to default values
            for (int y = 0; y < GridDimensions.Y; y++)
            {
                for (int x = 0; x < (int)GridDimensions.X; x++)
                {
                    Board[x, y] = new CombatTile();
                }
            }

            //Fill the grid by setting every index in Board to a CombatTile.
            for (int y = 0; y < GridDimensions.Y; y++) 
            {

                //Individual CombatTile properties are specified by _map's TileMap
                string rowToSplit = combatlayer.TMap.Row[y];
                List<string> row = rowToSplit.Split('[').ToList();

                row.RemoveAt(0);

                for (int i = 0; i < row.Count; i++)
                {
                    row[i] = row[i].Remove(row[i].Length - 1);
                }
 
                for (int x = 0; x < row.Count; x++)
                {
                    Board[x, y].LoadContent(row[x]);
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
