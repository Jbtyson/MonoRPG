// Enemy.cs
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
    public class Enemy : GameObject
    {
        public Stats Stats;
        public bool IsActive;
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

            // Set the image.isActive to false if the player is standing still so that the correct sprite is displayed
            //if (Velocity.X == 0 && Velocity.Y == 0)
                //Image.IsActive = false;

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