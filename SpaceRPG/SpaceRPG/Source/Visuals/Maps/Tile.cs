// Tile.cs
// James Tyson
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceRPG.Source.Visuals.Maps
{
    /// <summary>
    /// Base class for tiles in our tile maps
    /// </summary>
    public class Tile
    {
        protected Vector2 _position;
        protected Point _gridLocation;
        protected Rectangle _sourceRect;
        protected int _value1, _value2;

        public int Value1
        {
            get { return _value1; }
            set { _value1 = value; }
        }

        public int Value2
        {
            get { return _value2; }
            set { _value2 = value; }
        }

        public Rectangle SourceRect
        {
            get { return _sourceRect; }
        }

        public Vector2 Position
        {
            get { return _position; }
        }

        public Point GridLocation
        {
            get { return _gridLocation; }
            set { _gridLocation = value; }
        }

        public virtual void LoadContent(Vector2 position, Rectangle sourceRect)
        {
            this._position = position;
            this._sourceRect = sourceRect;
        }

        public virtual void UnloadContent()
        {

        }

        public virtual void Update(GameTime gameTime)
        {
            
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {

        }
    }
}
