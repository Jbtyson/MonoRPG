// Button.cs
// James Tyso
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
    public class Button
    {
        //Used if you want the button to display different pictures for the 
        public enum ButtonState
        {
            Neutral,
            Over,
            Pressed
        }

        private ButtonState _state;
        private bool _maintainPressedState; //Used if the mouse presses down on button but then leaves the
        // button, so if it re-enters it will re-press it
        [XmlElement("Image")]
        public List<Image> Images; //Will hold one for each button state
        private Image _currentImage;

        private Point _location; //Location/size for the button
        private Rectangle _hitbox; //Area where clicking button will work

        private object _value;

        /// <summary>
        /// A Click event. When the button is clicked (called on release),
        ///  it calls this event.
        /// </summary>
        public delegate void ButtonEvent(Button sender);
        [XmlIgnore]
        public ButtonEvent ButtonClicked;



        public Button()
        {
            Images = new List<Image>();
            _location = Point.Zero;
            _hitbox = Rectangle.Empty;
            _state = ButtonState.Neutral;
            _maintainPressedState = false;
            _currentImage = new Image();
        }

        public Point Location
        {
            get { return _location; }
            set { _location = value; }
        }

        public Rectangle HitBox
        {
            get { return _hitbox; }
            set { _hitbox = value; }
        }

        public object Value
        {
            get { return _value; }
            set { _value = value; }
        }

        public void LoadContent(Vector2 position)
        {
            foreach (Image i in Images)
            {
                i.LoadContent();
                i.Position = position;
            }
            _currentImage = Images[0];
            _hitbox = new Rectangle((int)position.X, (int)position.Y, _currentImage.SourceRect.Width, _currentImage.SourceRect.Height);
        }

        public void UnloadContent()
        {
            foreach (Image i in Images)
                i.UnloadContent();
        }

        public void Update(GameTime gameTime)
        {
            bool isMouseDown = InputManager.Instance.LeftMouseDown();
            Point location = InputManager.Instance.MousePosition;
            bool isMouseOver = _hitbox.Contains(location);

            //Clear the pressed state variable if click is released outside of button
            if (!isMouseDown && _maintainPressedState)
                _maintainPressedState = false;

            // Check for button state changes
            switch (_state)
            {
                case ButtonState.Neutral:
                    if (isMouseOver)
                    {
                        if (_maintainPressedState)
                            _state = ButtonState.Pressed;
                        else
                            _state = ButtonState.Over;
                        SetCurrentImage();
                    }
                    break;
                case ButtonState.Over:
                    if (!isMouseOver)
                    {
                        _state = ButtonState.Neutral;
                        SetCurrentImage();
                    }
                    else
                    {
                        if (isMouseDown)
                        {
                            _maintainPressedState = true;
                            _state = ButtonState.Pressed;
                            SetCurrentImage();
                        }
                    }
                    break;
                case ButtonState.Pressed:

                    if (!isMouseDown)
                    {
                        //Click
                        if (isMouseOver)
                            _state = ButtonState.Over;
                        else
                            _state = ButtonState.Neutral;
                        ButtonClicked(this);
                        SetCurrentImage();
                    }
                    else if (!isMouseOver)
                    {
                        _state = ButtonState.Neutral;
                        SetCurrentImage();
                    }
                    break;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            _currentImage.Draw(spriteBatch);
        }

        /// <summary>
        /// Sets the current image based on the button state
        /// </summary>
        private void SetCurrentImage()
        {
            switch (_state)
            {
                case ButtonState.Neutral:
                    _currentImage = Images[0];
                    break;
                case ButtonState.Over:
                    _currentImage = Images[1];
                    break;
                case ButtonState.Pressed:
                    _currentImage = Images[2];
                    break;
            }
        }
    }
}
