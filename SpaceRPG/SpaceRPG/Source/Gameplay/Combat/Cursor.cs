// Cursor.cs
// James Tyson

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using SpaceRPG.Source.Managers;
using SpaceRPG.Source.Visuals;

namespace SpaceRPG.Source.Gameplay.Combat
{
    public class Cursor : GameObject
    {
        public Cursor()
        {
            Image = new Image();
            Velocity = Vector2.Zero;
        }

        public override void LoadContent()
        {
            Image.LoadContent();
            Image.Position = new Vector2((int)InputManager.Instance.MousePosition.X / 32, (int)InputManager.Instance.MousePosition.Y / 32);
            Image.SpriteSheetEffect.SwitchFrame = 500;
            Image.SpriteSheetEffect.AmountOfFrames = new Vector2(2, 1);
        }

        public override void UnloadContent()
        {

        }

        public override void Update(GameTime gameTime)
        {
            Image.Position = new Vector2(((int)InputManager.Instance.MousePosition.X / 32) * 32, ((int)InputManager.Instance.MousePosition.Y / 16) * 16);
            Image.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Image.Draw(spriteBatch);
        }
    }
}
