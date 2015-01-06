﻿using System;
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
    public class Layer
    {
        public class TileMap 
        {
            [XmlElement("Row")]
            public List<string> Row;
        }

        Vector2 tileDimensions;
        List<List<Vector2>> tileMap;

        [XmlElement("TileMap")]
        public TileMap TileLayout;
        public Image Image;

        public Layer()
        {
            tileDimensions = new Vector2();
            tileMap = new List<List<Vector2>>();
        }

        public void Initialize(ContentManager content, Vector2 tileDimensions) 
        {
            this.tileDimensions = tileDimensions;

            foreach(string row in TileLayout.Row) 
            {
                string[] split = row.Split(']');
                List<Vector2> tempTileMap = new List<Vector2>();
                foreach(string s in split) 
                {
                    int val1 = -1; int val2 = -1;
                    if(s != String.Empty && !s.Contains('x'))
                    {
                        string str = s.Replace("[", String.Empty);
                        val1 = int.Parse(str.Substring(0, str.IndexOf(':')));
                        val2 = int.Parse(str.Substring(str.IndexOf(':')+1));
                    }
                    else
                        tempTileMap.Add(new Vector2(val1, val2));

                    tempTileMap.Add(new Vector2(val1, val2));
                }
                tileMap.Add(tempTileMap);
            }

            Image.Initialize(content);
        }

        public void Draw(SpriteBatch spriteBatch) 
        {
            for(int i = 0; i < tileMap.Count; i++)
            {
                for(int j = 0; j < tileMap[i].Count; j++)
                {
                    if(tileMap[i][j] != -Vector2.One) 
                    {
                        Image.Position = new Vector2(j * tileDimensions.X, i * tileDimensions.Y);
                        Image.SourceRect = new Rectangle((int)(tileMap[i][j].X * tileDimensions.X), (int)(tileMap[i][j].Y * tileDimensions.Y),
                            (int)tileDimensions.X, (int)tileDimensions.Y);
                        Image.Draw(spriteBatch);
                    }
                }
            }
        }
    }
}