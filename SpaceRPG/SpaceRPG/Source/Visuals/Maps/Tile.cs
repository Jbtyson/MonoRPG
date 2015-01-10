// Tile.cs
// James Tyson
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using SpaceRPG.Source.Gameplay.Overworld;

namespace SpaceRPG.Source.Visuals.Maps
{
    /// <summary>
    /// Tile represents a single square on the grid
    /// </summary>
    public class Tile
    {
        private Vector2 _position;
        private Rectangle _sourceRect;
        private string _state;
        public int Value1, Value2;

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
            if (_state == "Solid")
            {
                // Get the rects
                Rectangle tileRect = new Rectangle((int)Position.X, (int)Position.Y, 
                    _sourceRect.Width, _sourceRect.Height);
                Rectangle playerRect = new Rectangle((int)player.Image.Position.X, (int)player.Image.Position.Y,
                    player.Image.SourceRect.Width, player.Image.SourceRect.Height);

                // Check for intersection
                // This needs to be fixed to prevent jumping around if you change directions while intersecting
                if (playerRect.Intersects(tileRect))
                {
                    if (player.Velocity.X < 0)
                        player.Image.Position.X = tileRect.Right;
                    else if (player.Velocity.X > 0)
                        player.Image.Position.X = tileRect.Left - player.Image.SourceRect.Width;
                    else if (player.Velocity.Y < 0)
                        player.Image.Position.Y = tileRect.Bottom;
                    else if (player.Velocity.Y > 0)
                        player.Image.Position.Y = tileRect.Top - player.Image.SourceRect.Height;

                    player.Velocity = Vector2.Zero;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {

        }
    }
}
