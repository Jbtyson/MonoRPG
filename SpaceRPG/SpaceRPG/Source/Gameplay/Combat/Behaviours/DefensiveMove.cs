﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

using SpaceRPG.Source.Gameplay.Combat;
using SpaceRPG.Source.Managers;

namespace SpaceRPG.Source.Gameplay.Combat.Behaviors
{
    public class DefensiveMove : Behavior
    {
        public DefensiveMove()
        {
           
        }

        public override void Update(GameTime gameTime, Agent agent)
        {
            if (agent.MyTurn && !agent.Busy && InputManager.Instance.LeftMouseClick())
                agent.MoveTo(new Vector2(InputManager.Instance.MousePosition.X/32, InputManager.Instance.MousePosition.Y/32));
        }
    }
}
