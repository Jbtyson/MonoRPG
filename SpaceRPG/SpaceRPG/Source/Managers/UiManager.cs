using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using SpaceRPG.Source.Overlays;

namespace SpaceRPG.Source.Managers
{
    public class UiManager
    {
        [XmlElement("UiPanel")]
        public List<UiPanel> Panels;
        public List<Rectangle> HitBoxes;

        public UiManager()
        {
            Panels = new List<UiPanel>();
            HitBoxes = new List<Rectangle>();
        }

        public void LoadContent()
        {
            foreach (UiPanel p in Panels)
            {
                p.LoadContent();
                HitBoxes.Add(p.Hitbox);
            }
        }

        public void UnloadContent()
        {
            foreach (UiPanel p in Panels)
                p.UnloadContent();
        }

        public void Update(GameTime gameTime)
        {
            foreach (UiPanel p in Panels)
                p.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (UiPanel p in Panels)
                p.Draw(spriteBatch);
        }

        public bool IsMouseOnUi()
        {
            Point m = InputManager.Instance.MousePosition;
            foreach (Rectangle r in HitBoxes)
            {
                if (r.Contains(m))
                    return true;
            }
            return false;
        }

        public void LoadPanel(string path)
        {
            XmlManager<UiPanel> panelLoader = new XmlManager<UiPanel>();
            UiPanel panel = panelLoader.Load(path);
            panel.LoadContent();
            Panels.Add(panel);
        }
    }
}
