﻿// Tile.cs
// James Tyson
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using SpaceRPG.Source.Gameplay.Overworld;

namespace SpaceRPG.Source.Visuals.Maps.Orthogonal
{
    /// <summary>
    /// Tile represents a single square on an orthogonal grid
    /// </summary>
    public class OrthogonalTile : Tile
    {
        private string _state;

        public OrthogonalTile() 
            : base()
        {

        }

        public void LoadContent(string state, Vector2 position, Rectangle sourceRect)
        {
            base.LoadContent(position, sourceRect);
            _state = state;
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
        }

        public void Update(GameTime gameTime, ref Player player)
        {
            base.Update(gameTime);

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

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
