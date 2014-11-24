// Ally.cs
// James Tyson
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpaceRPG
{
    public class Ally : GameObject
    {
        public Stats Stats;
        public bool IsActive;
        public bool IsPlayerControlled;
        [XmlIgnore]
        public ICombat Target;

        public override void LoadContent()
        {
            base.LoadContent();
            Image.LoadContent();
            Image.Position = this.Position;
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
            Image.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            // Set the image to active for now, we will set to false at the end of the update loop if necessary
            Image.IsActive = true;

            // Allow for player control, if player controlled
            if (IsPlayerControlled)
            {
                // Vertical movement
                if (InputManager.Instance.KeyDown(Keys.Down))
                {
                    Velocity.Y = MoveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    Image.SpriteSheetEffect.CurrentFrame.Y = 0;
                }
                else if (InputManager.Instance.KeyDown(Keys.Up))
                {
                    Velocity.Y = -MoveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    Image.SpriteSheetEffect.CurrentFrame.Y = 3;
                }
                else
                    Velocity.Y = 0;

                //  Horizontal movement
                if (InputManager.Instance.KeyDown(Keys.Right))
                {
                    Velocity.X = MoveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    Image.SpriteSheetEffect.CurrentFrame.Y = 2;
                }
                else if (InputManager.Instance.KeyDown(Keys.Left))
                {
                    Velocity.X = -MoveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    Image.SpriteSheetEffect.CurrentFrame.Y = 1;
                }
                else
                    Velocity.X = 0;
            }

            // Set the image.isActive to false if the player is standing still so that the correct sprite is displayed
            if (Velocity.X == 0 && Velocity.Y == 0)
                Image.IsActive = false;

            // Update our image
            Image.Update(gameTime);

            // Update our position in the world
            Image.Position += Velocity;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            Image.Draw(spriteBatch);
        }
    }
}

