// InputManager.cs
// James Tyson
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework.Input;

namespace SpaceRPG.Source.Managers
{
    /// <summary>
    /// Input manager is a singleton class to help us manage inputs
    /// </summary>
    public class InputManager
    {
        private KeyboardState _currentKeyState, _prevKeyState;
        private static InputManager _instance;

        /// <summary>
        /// Singleton instance of InputManager
        /// </summary>
        public static InputManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new InputManager();
                return _instance;
            }
        }

        /// <summary>
        /// Basic update function
        /// </summary>
        public void Update()
        {
            // Save the keyboard state
            _prevKeyState = _currentKeyState;

            // Lock input during screen transitions
            if (!ScreenManager.Instance.IsTransitioning)
                _currentKeyState = Keyboard.GetState();
        }

        /// <summary>
        /// Checks for a key(s) press
        /// </summary>
        /// <param name="keys">Key(s) to check for</param>
        /// <returns>True if the key(s) have been pressed/returns>
        public bool KeyPressed(params Keys[] keys)
        {
            foreach (Keys key in keys)
            {
                if (_currentKeyState.IsKeyDown(key) && _prevKeyState.IsKeyUp(key))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Checks for a key release
        /// </summary>
        /// <param name="keys">Key(s) to check for</param>
        /// <returns>True if the key(s) have been released/returns>
        public bool KeyReleased(params Keys[] keys)
        {
            foreach (Keys key in keys)
            {
                if (_currentKeyState.IsKeyUp(key) && _prevKeyState.IsKeyDown(key))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Checks for a key being currently held down
        /// </summary>
        /// <param name="keys">Key(s) to check for</param>
        /// <returns>True if the key(s) is currently down/returns>
        public bool KeyDown(params Keys[] keys)
        {
            foreach (Keys key in keys)
            {
                if (_currentKeyState.IsKeyDown(key))
                    return true;
            }
            return false;
        }
    }
}
