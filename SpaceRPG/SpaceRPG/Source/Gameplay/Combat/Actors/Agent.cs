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

namespace SpaceRPG.Source.Gameplay.Combat.Actors
{
    /// <summary>
    /// Agent is a base class for all players/enemies in a combat scenario
    /// </summary>
    public class Agent : GameObject
    {
        /// <summary>
        /// This is the location on a combat grid, not position on a screen
        /// </summary>
        public Vector2 Location, Destination;
        public bool Moving, Busy, MyTurn, Aligned, ReachedNode, DisplayMoveRange;
        public List<Point> MovementNodes;
        public int MoveRange;
        [XmlIgnore]
        public Action CurrentAction;

        public delegate void TurnChange();
        [XmlIgnore]
        public TurnChange TurnIsOver;
        

        /// <summary>
        /// Defauly constructor
        /// </summary>
        public Agent()
        {
            Location = Destination = Vector2.Zero;
        }

        /// <summary>
        /// Loads content
        /// </summary>
        public virtual void LoadContent()
        {
            base.LoadContent();
        }

        /// <summary>
        /// Unloads content
        /// </summary>
        public virtual void UnloadContent()
        {
            base.UnloadContent();
        }

        /// <summary>
        /// Updates based on gametime
        /// </summary>
        /// <param name="gameTime"></param>
        public virtual void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (MyTurn)
            {
                if (Moving)
                {
                    Move(gameTime);
                    DisplayMoveRange = false;
                }
                
                if (!Busy)
                {
                    if (InputManager.Instance.KeyPressed(Keys.M))
                        DisplayMoveRange = !DisplayMoveRange;
                }
            }
        }

        /// <summary>
        /// Draws the current spritebatch to the screen
        /// </summary>
        /// <param name="spriteBatch"></param>
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }

        /// <summary>
        /// Calculates a path to and potentially moves an agent to a new destination
        /// </summary>
        /// <param name="newLoc">New location to move the agent to</param>
        /// <param name="beginMove">If true, immediately begins executing the move</param>
        public virtual void GetPathTo(Vector2 newLoc, bool beginMove)
        {
            // Snap ouselves to the grid...bandaid fix this later
            Location = new Vector2((int)Image.Position.X / 32, (int)Image.Position.Y / 32);

            // Find the horizontal node to match x positions and then move to the end location
            if (newLoc.X != Location.X)
            {
                Point horNode = new Point((int)newLoc.X, (int)Location.Y);
                MovementNodes.Add(horNode);
            }
            if (newLoc.Y != Location.Y)
            {
                Point endNode = new Point((int)newLoc.X, (int)newLoc.Y);
                MovementNodes.Add(endNode);
            }

            if (beginMove)
            {
                ExecuteMove();
            }
        }

        /// <summary>
        /// Handles player position during a move
        /// </summary>
        /// <param name="gameTime"></param>
        public void Move(GameTime gameTime)
        {
            // Get our new position
            Image.Position += Velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
            Location = new Vector2((int)Image.Position.X / 32, (int)Image.Position.Y / 32);

            // Check if we reaced a node
            if (ReachedNode || (int)Location.X == MovementNodes[0].X && (int)Location.Y == MovementNodes[0].Y)
            {
                ReachedNode = true;
                // Now we need to make sure that our image is moving to align with the top left corner of the square
                if (Velocity.X > 0) // moving to the right, so we may need to hop back left
                {
                    if (Image.Position.X >= MovementNodes[0].X * 32)
                    {
                        Image.Position.X = MovementNodes[0].X * 32;
                        Aligned = true;
                    }
                }

                else if (Velocity.X < 0) // moving to the left, so we may need to hop back right
                {
                    if (Image.Position.X <= MovementNodes[0].X * 32)
                    {
                        Image.Position.X = MovementNodes[0].X * 32;
                        Aligned = true;
                    }
                }

                else if (Velocity.Y > 0) // moving down, so we may need to hop back up
                {
                    if (Image.Position.Y >= MovementNodes[0].Y * 32)
                    {
                        Image.Position.Y = MovementNodes[0].Y * 32;
                        Aligned = true;
                    }
                }

                else if (Velocity.Y < 0) // moving up, so we may need to hop back down
                {
                    if (Image.Position.Y <= MovementNodes[0].Y * 32)
                    {
                        Image.Position.Y = MovementNodes[0].Y * 32;
                        Aligned = true;
                    }
                }

                if (Aligned)
                {
                    Location = new Vector2((int)Image.Position.X / 32, (int)Image.Position.Y / 32);
                    MovementNodes.RemoveAt(0);
                    Console.WriteLine(">> Reached Node <<");

                    // Check if we reached the last node
                    if (MovementNodes.Count == 0)
                    {
                        Velocity = Vector2.Zero;
                        Moving = false;
                        Busy = false;
                        Console.WriteLine(">>> Movement complete <<<");
                        TurnIsOver();
                    }
                    else
                    {
                        ExecuteMove();
                    }
                    Aligned = false;
                    ReachedNode = false;
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

            Moving = true;
            Busy = true;
            Aligned = false;

            // Calculate the velocity
            Vector2 diff = new Vector2(MovementNodes[0].X - (int)Location.X, MovementNodes[0].Y - (int)Location.Y);
            if (diff.X > 0)
            {
                Velocity.X = MoveSpeed;
                Image.SpriteSheetEffect.CurrentFrame.Y = 2;
            }
            else if (diff.X < 0)
            {
                Velocity.X = -MoveSpeed;
                Image.SpriteSheetEffect.CurrentFrame.Y = 1;
            }
            else
                Velocity.X = 0;

            if (diff.Y > 0)
            {
                Velocity.Y = MoveSpeed;
                Image.SpriteSheetEffect.CurrentFrame.Y = 0;
            }
            else if (diff.Y < 0)
            {
                Velocity.Y = -MoveSpeed;
                Image.SpriteSheetEffect.CurrentFrame.Y = 3;
            }
            else
                Velocity.Y = 0;
        }
    }
}
