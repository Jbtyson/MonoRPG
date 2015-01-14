// GameObject.cs
// James Tyson
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using SpaceRPG.Source.Visuals;

namespace SpaceRPG.Source.Gameplay
{
    /// <summary>
    /// GameObject is the base object for all game objects in the world
    /// </summary>
    public class GameObject
    {
        protected string _id;
        protected float _moveSpeed;
        protected Image _image;
        protected Vector2 _velocity;

        #region Accessors
        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public float MoveSpeed
        {
            get { return _moveSpeed; }
            set { _moveSpeed = value; }
        }
        public Image Image
        {
            get { return _image; }
            set { _image = value; }
        }
        public Vector2 Velocity
        {
            get { return _velocity; }
            set { _velocity = value; }
        }
        #endregion

        /// <summary>
        /// Loads content
        /// </summary>
        public virtual void LoadContent()
        {

        }

        /// <summary>
        /// Unloads content
        /// </summary>
        public virtual void UnloadContent()
        {

        }

        /// <summary>
        /// Updates based on gametime
        /// </summary>
        /// <param name="gameTime"></param>
        public virtual void Update(GameTime gameTime)
        {

        }

        /// <summary>
        /// Draws the current spritebatch to the screen
        /// </summary>
        /// <param name="spriteBatch"></param>
        public virtual void Draw(SpriteBatch spriteBatch)
        {

        }
    }
}
