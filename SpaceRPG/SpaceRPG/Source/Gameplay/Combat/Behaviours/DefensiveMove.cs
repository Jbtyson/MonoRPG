using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace SpaceRPG
{
    public class AggressiveMove : Behavior
    {
        public AggressiveMove()
        {

        }

        public override void Update(GameTime gameTime, GameObject obj)
        {
            obj.Velocity.Y = obj.MoveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
    }
}
