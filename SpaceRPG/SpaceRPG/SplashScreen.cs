using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace SpaceRPG
{
    public class SplashScreen : GameScreen
    {
        [XmlElement("Image")]
        public Image image;

        public override void LoadContent()
        {
            base.LoadContent();
            image.LoadContent();
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
            image.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            image.Update(gameTime);

            if (InputManager.Instance.KeyPressed(Keys.Enter) && !ScreenManager.Instance.IsTransitioning)
                ScreenManager.Instance.ChangeScreens("TitleScreen");
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            image.Draw(spriteBatch);
        }
    }
}
