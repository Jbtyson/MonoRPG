﻿// Tile.cs
// James Tyson
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceRPG
{
    /// <summary>
    /// Tile represents a single square on the grid
    /// </summary>
    public class Tile
    {
        private Vector2 _position;
        private Rectangle _sourceRect;
        private string _state;

        public Rectangle SourceRect
        {
            get { return _sourceRect; }
        }

        public Vector2 Position
        {
            get { return _position; }
        }

        public void LoadContent(string state, Vector2 position, Rectangle sourceRect)
        {
            this._state = state;
            this._position = position;
            this._sourceRect = sourceRect;
        }

        public void UnloadContent()
        {

        }

        public void Update(GameTime gameTime, ref Player player)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {

        }
    }
}