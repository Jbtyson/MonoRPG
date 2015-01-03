using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

using SpaceRPG.Source.Gameplay.Combat;

namespace SpaceRPG
{
    public class AggressiveMove : Behavior
    {
        public AggressiveMove()
        {

        }

        public override void Update(GameTime gameTime, Agent agent)
        {
            if(!agent.Busy)
                agent.MoveTo(new Vector2(agent.Location.X, agent.Location.Y + 1));
        }
    }
}
