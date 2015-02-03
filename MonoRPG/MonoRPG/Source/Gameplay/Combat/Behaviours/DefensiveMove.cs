using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

using MonoRPG.Source.Gameplay.Combat.Actors;
using MonoRPG.Source.Input;

namespace MonoRPG.Source.Gameplay.Combat.Behaviors
{
    public class DefensiveMove : Behavior
    {
        public DefensiveMove()
        {
           
        }

        public override void Update(GameTime gameTime, Agent agent)
        {
            if (agent.MyTurn && !agent.Busy && InputManager.Instance.LeftMouseClick())
                agent.GetPathTo(new Point(5,5), true);
        }
    }
}
