using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace SpaceRPG
{
    public class DefensiveMove : Behavior
    {
        public DefensiveMove()
        {

        }

        public override void Update(GameTime gameTime, GameObject obj)
        {
            obj.Velocity.X = obj.MoveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
    }
}
