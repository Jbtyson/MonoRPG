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
using SpaceRPG.Source.Managers;

namespace SpaceRPG.Source.Overlays
{
    /// <summary>
    /// UiPanel acts as a block style container for ui controls
    /// </summary>
    public class UiPanel
    {
        private Rectangle _hitbox;
        private Image _image;
        private int _selectedItem;
        private List<Button> _buttons;
        private Vector2 _dimensions, _buttonDimensions, _buttonOffset, _buttonOrigin;
        private bool _visible;

        #region Accessors
        public Rectangle Hitbox
        {
            get { return _hitbox; }
            set { _hitbox = value; }
        }
        public Image Image
        {
            get { return _image; }
            set { _image = value; }
        }
        public int SelectedItem
        {
            get { return _selectedItem; }
            set { _selectedItem = value; }
        }
        [XmlElement("Button")]
        public List<Button> Buttons
        {
            get { return _buttons; }
            set { _buttons = value; }
        }
        public Vector2 Dimensions 
        {
            get { return _dimensions; }
            set { _dimensions = value; }
        }
        public Vector2 ButtonDimensions
        {
            get { return _buttonDimensions; }
            set { _buttonDimensions = value; }
        }
        public Vector2 ButtonOffset
        {
            get { return _buttonOffset; }
            set { _buttonOffset = value; }
        }
        public Vector2 ButtonOrigin
        {
            get { return _buttonOrigin; }
            set { _buttonOrigin = value; }
        }
        public bool Visible
        {
            get { return _visible; }
            set { _visible = value; }
        }
        #endregion

        /// <summary>
        /// Default constructor
        /// </summary>
        public UiPanel()
        {
            _hitbox = Rectangle.Empty;
            _image = new Image();
            _buttons = new List<Button>();
            _dimensions = Vector2.Zero;
            _buttonDimensions = Vector2.Zero;
            _buttonOffset = Vector2.Zero;
            _buttonOrigin = Vector2.Zero;
        }

        public virtual void LoadContent()
        {
            _buttonOrigin += _image.Position;

            _image.LoadContent();
            int count = 0;
            // Add each button, starting at button origin and adding the number of buttons so far * the button offset
            foreach (Button b in _buttons)
                b.LoadContent(_buttonOrigin + (count++ * _buttonOffset), HandleButtonClick);

        }

        public virtual void UnloadContent()
        {
            _image.UnloadContent();
            foreach (Button b in _buttons)
                b.UnloadContent();
        }

        public virtual void Update(GameTime gameTime)
        {
            _image.Update(gameTime);
            foreach (Button b in _buttons)
                b.Update(gameTime);

            // Update position based on camera
            _image.Position -= ScreenManager.Instance.Camera.WorldChange;
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if (Visible)
            {
                _image.Draw(spriteBatch);
                foreach (Button b in _buttons)
                    b.Draw(spriteBatch);
            }
        }

        /// <summary>
        /// Handles a click on a button within this panel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void HandleButtonClick(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            Console.WriteLine(b.Value);
        }
    }
}
