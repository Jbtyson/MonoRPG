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

namespace SpaceRPG.Source.Gameplay.Combat
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
        public bool Moving, Busy, MyTurn;
        public List<Point> MovementNodes;
        public delegate void TurnChange();
        [XmlIgnore]
        public TurnChange TurnIsOver;

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
            if (Moving)
            {
                // Get our new position
                Image.Position += Velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
                Location = Image.Position / 32;

                // Check if we reaced a node
                if ((int)Location.X == MovementNodes[0].X && (int)Location.Y == MovementNodes[0].Y)
                {
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
                        // Calculate the velocity
                        Vector2 diff = new Vector2(MovementNodes[0].X - (int)Location.X, MovementNodes[0].Y - (int)Location.Y);
                        if (diff.X > 0)
                            Velocity.X = MoveSpeed;
                        else if (diff.X < 0)
                            Velocity.X = -MoveSpeed;
                        else
                            Velocity.X = 0;

                        if (diff.Y > 0)
                            Velocity.Y = MoveSpeed;
                        else if (diff.Y < 0)
                            Velocity.Y = -MoveSpeed;
                        else
                            Velocity.Y = 0;
                    }
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
        /// Moves an agent to a new destination
        /// </summary>
        /// <param name="newLoc"></param>
        public virtual void MoveTo(Vector2 newLoc)
        {
            Destination = newLoc;
            Moving = true;
            Busy = true;
            
            // Add our starting location as the first node
            Point node1 = new Point((int)Location.X, (int)Location.Y);
            MovementNodes.Add(node1);
            // Find the nodes to get there in two straight lines (north/south, east/west)
            Point node2 = new Point((int)newLoc.X, (int)Location.Y);
            Point node3 = new Point(node2.X, (int)newLoc.Y);
            MovementNodes.Add(node2);
            MovementNodes.Add(node3);

            Console.WriteLine("Moving to point {0} through nodes {1}, {2}, {3}.", node3.ToString(), node1.ToString(), node2.ToString(), node3.ToString());
        }
    }
}
