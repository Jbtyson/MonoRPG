using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

using MonoRPG.Source.Gameplay.Combat.Actors;

namespace MonoRPG.Source.Gameplay.Combat.Behaviors
{
    public class AggressiveMove : Behavior
    {
        public AggressiveMove()
        {

        }

        public override void Update(GameTime gameTime, Agent agent)
        {
            if (agent.MyTurn && !agent.Busy)
            {
                agent.GetPathTo(new Point(agent.Location.X + 5, agent.Location.Y + 3), true);
            }
                
        }
    }
}
