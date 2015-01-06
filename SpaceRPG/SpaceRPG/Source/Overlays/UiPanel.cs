// UiPanel.cs
// James Tyson
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using SpaceRPG.Source.Visuals;

namespace SpaceRPG.Source.Overlays
{
    public class UiPanel
    {
        public Rectangle Hitbox;
        public Image Image;
        public int SelectedItem;
        [XmlElement("Button")]
        public List<Button> Buttons;

        public UiPanel()
        {
            Hitbox = Rectangle.Empty;
            Image = new Image();
            Buttons = new List<Button>();
        }

        public virtual void LoadContent()
        {
            Image.LoadContent();
            foreach (Button b in Buttons)
                b.LoadContent(Image.Position);

        }

        public virtual void UnloadContent()
        {
            Image.UnloadContent();
            foreach (Button b in Buttons)
                b.UnloadContent();
        }

        public virtual void Update(GameTime gameTime)
        {
            Image.Update(gameTime);
            foreach (Button b in Buttons)
                b.Update(gameTime);
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            Image.Draw(spriteBatch);
            foreach (Button b in Buttons)
                b.Draw(spriteBatch);
        }
    }
}
