// Agent.cs
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

using SpaceRPG.Source.Managers;
using SpaceRPG.Source.Gameplay.Combat.Maps;

namespace SpaceRPG.Source.Gameplay.Combat.Actors
{
    /// <summary>
    /// Agent is a base class for all players/enemies in a combat scenario
    /// </summary>
    public class Agent : GameObject
    {
        protected CombatTile _tile;
        protected Vector2 _dimensions, _isometricOffset;
        protected Vector2 _destination;
        protected Point _location;
        protected bool _moving, _busy, _myTurn, _aligned, _reachedNode, _displayMoveRange;
        protected List<Point> _movementNodes;
        protected int _moveRange;
        protected Action _currentAction;
        protected ICombatGrid _combatGrid;

        #region Accessors
        public CombatTile Tile
        {
            get { return _tile; }
            set { _tile = value; }
        }
        public Vector2 Dimensions
        {
            get { return _dimensions; }
            set { _dimensions = value; }
        }
        public Vector2 Destination
        {
            get { return _destination; }
            set { _destination = value; }
        }
        public Point Location
        {
            get { return _location; }
            set { _location = value; }
        }
        public bool Moving
        {
            get { return _moving; }
            set { _moving = value; }
        }
        public bool Busy
        {
            get { return _busy; }
            set { _busy = value; }
        }
        public bool MyTurn
        {
            get { return _myTurn; }
            set { _myTurn = value; }
        }
        public bool Aligned
        {
            get { return _aligned; }
            set { _aligned = value; }
        }
        public bool ReachedNode
        {
            get { return _reachedNode; }
            set { _reachedNode = value; }
        }
        public bool DisplayMoveRange
        {
            get { return _displayMoveRange; }
            set { _displayMoveRange = value; }
        }
        public List<Point> MovementNodes
        {
            get { return _movementNodes; }
            set { _movementNodes = value; }
        }
        public int MoveRange
        {
            get { return _moveRange; }
            set { _moveRange = value; }
        }
        [XmlIgnore]
        public Action CurrentAction
        {
            get { return _currentAction; }
            set { _currentAction = value; }
        }
        #endregion

        public delegate void TurnChange();
        [XmlIgnore]
        public TurnChange TurnIsOver;
        

        /// <summary>
        /// Defauly constructor
        /// </summary>
        public Agent()
        {
            _destination = Vector2.Zero;
            _location = Point.Zero;
            _dimensions = Vector2.Zero;
            _isometricOffset = Vector2.Zero;
        }

        /// <summary>
        /// Loads content
        /// </summary>
        public override void LoadContent()
        {
            base.LoadContent();
        }

        /// <summary>
        /// Unloads content
        /// </summary>
        public override void UnloadContent()
        {
            base.UnloadContent();
        }

        /// <summary>
        /// Updates based on gametime
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (_myTurn)
            {
                if (_moving)
                {
                    this.Move(gameTime);
                    _displayMoveRange = false;
                }
                
                if (!Busy)
                {
                    if (InputManager.Instance.KeyPressed(Keys.M))
                        _displayMoveRange = !_displayMoveRange;
                }
            }
        }

        /// <summary>
        /// Draws the current spritebatch to the screen
        /// </summary>
        /// <param name="spriteBatch"></param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }

        /// <summary>
        /// Calculates a path to and potentially moves an agent to a new destination on a grid
        /// </summary>
        /// <param name="newLoc">New location to move the agent to</param>
        /// <param name="beginMove">If true, immediately begins executing the move</param>
        public virtual void GetPathTo(Point newLoc, bool beginMove)
        {
            // Find the horizontal node to match x positions and then move to the end location
            if (newLoc.X != Location.X)
            {
                Point horNode = new Point((int)newLoc.X, (int)Location.Y);
                _movementNodes.Add(horNode);
            }
            if (newLoc.Y != Location.Y)
            {
                Point endNode = new Point((int)newLoc.X, (int)newLoc.Y);
                _movementNodes.Add(endNode);
            }

            if (beginMove)
            {
                this.ExecuteMove();
            }
        }

        /// <summary>
        /// Handles player position during a move
        /// </summary>
        /// <param name="gameTime"></param>
        public void Move(GameTime gameTime)
        {
            // Get our new position
            _image.Position += _velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
            _location = _combatGrid.GetTileAtPosition(_image.Position).GridPosition;

            // Check if we reaced a node
            if (ReachedNode || (int)Location.X == MovementNodes[0].X && (int)Location.Y == MovementNodes[0].Y)
            {
                ReachedNode = true;
                // Now we need to make sure that our image is moving to align with the top left corner of the square
                if (Velocity.X > 0) // moving to the right, so we may need to hop back left
                {
                    if (_image.Position.X >= _movementNodes[0].X * 32)
                    {
                        _image.Position.X = _movementNodes[0].X * 32;
                        _aligned = true;
                    }
                }

                else if (Velocity.X < 0) // moving to the left, so we may need to hop back right
                {
                    if (_image.Position.X <= _movementNodes[0].X * 32)
                    {
                        _image.Position.X = _movementNodes[0].X * 32;
                        _aligned = true;
                    }
                }

                if (Velocity.Y > 0) // moving down, so we may need to hop back up
                {
                    if (_image.Position.Y >= _movementNodes[0].Y * 32)
                    {
                        _image.Position.Y = _movementNodes[0].Y * 32;
                        _aligned = true;
                    }
                }

                else if (Velocity.Y < 0) // moving up, so we may need to hop back down
                {
                    if (_image.Position.Y <= _movementNodes[0].Y * 32)
                    {
                        _image.Position.Y = _movementNodes[0].Y * 32;
                        _aligned = true;
                    }
                }

                if (_aligned)
                {
                    _location = new Point((int)Image.Position.X / 32, (int)Image.Position.Y / 32);
                    _movementNodes.RemoveAt(0);
                    Console.WriteLine(">> Reached Node <<");

                    // Check if we reached the last node
                    if (_movementNodes.Count == 0)
                    {
                        _velocity = Vector2.Zero;
                        _moving = false;
                        _busy = false;
                        Console.WriteLine(">>> Movement complete <<<");
                        this.TurnIsOver();
                    }
                    else
                    {
                        this.ExecuteMove();
                    }
                    _aligned = false;
                    _reachedNode = false;
                }
            }
        }

        /// <summary>
        /// Executes a move to the next node in the node list
        /// </summary>
        public void ExecuteMove()
        {
            if (MovementNodes.Count == 0)
                return;

            _moving = true;
            _busy = true;
            _aligned = false;

            // Calculate the velocity
            Vector2 diff = new Vector2(MovementNodes[0].X - (int)Location.X, MovementNodes[0].Y - (int)Location.Y);
            
            if (diff.X > 0)
            {
                _velocity.X = _moveSpeed;
                _velocity.Y = _moveSpeed / 2;
                _image.SpriteSheetEffect.CurrentFrame.Y = 2;
            }
            else if (diff.X < 0)
            {
                _velocity.X = -_moveSpeed;
                _image.SpriteSheetEffect.CurrentFrame.Y = 1;
            }

            if (diff.Y > 0)
            {
                _velocity.Y = _moveSpeed;
                _image.SpriteSheetEffect.CurrentFrame.Y = 0;
            }
            else if (diff.Y < 0)
            {
                _velocity.Y = -_moveSpeed;
                _image.SpriteSheetEffect.CurrentFrame.Y = 3;
            }
        }
    }
}
