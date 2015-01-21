// UiManager.cs
// James Tyson
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
        private List<UiPanel> _panels;
        private List<Rectangle> _hitBoxes;

        #region Accessors
        [XmlElement("UiPanel")]
        public List<UiPanel> Panels
        {
            get { return _panels; }
            set { _panels = value; }
        }
        public List<Rectangle> HitBoxes
        {
            get { return _hitBoxes; }
            set { _hitBoxes = value; }
        }
        #endregion

        /// <summary>
        /// Default constructor
        /// </summary>
        public UiManager()
        {
            _panels = new List<UiPanel>();
            _hitBoxes = new List<Rectangle>();
        }

        public void LoadContent()
        {
            foreach (UiPanel p in _panels)
            {
                p.LoadContent();
                p.Visible = false;
                _hitBoxes.Add(p.Hitbox);
            }
        }

        public void UnloadContent()
        {
            foreach (UiPanel p in _panels)
                p.UnloadContent();
        }

        public void Update(GameTime gameTime)
        {
            foreach (UiPanel p in _panels)
                p.Update(gameTime);
            if (gameTime.TotalGameTime.Seconds > 5)
                _panels[0].Visible = true;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (UiPanel p in _panels)
                p.Draw(spriteBatch);
        }

        /// <summary>
        /// Returns true if the mouse if over the UI
        /// </summary>
        /// <returns>True if mouse is over the UI</returns>
        public bool IsMouseOnUi()
        {
            Point m = InputManager.Instance.MousePosition;
            foreach (Rectangle r in _hitBoxes)
            {
                if (r.Contains(m))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Loads a panel from a specified string path and adds it to the list
        /// </summary>
        /// <param name="path">Path to load the panel from</param>
        public void LoadPanel(string path)
        {
            XmlManager<UiPanel> panelLoader = new XmlManager<UiPanel>();
            UiPanel panel = panelLoader.Load(path);
            panel.LoadContent();
            _panels.Add(panel);
        }
    }
}
