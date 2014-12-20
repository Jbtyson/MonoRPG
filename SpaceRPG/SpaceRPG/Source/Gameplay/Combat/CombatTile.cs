using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceRPG
{
    class CombatTile
    {

        //Just examples of potential tile properties. We'll need some more obvs.
        public bool Walkable;
        public int Height;
        public bool Damaging;
        public int TurnsToBurn;

        public CombatTile() {
            Walkable = false;
            Damaging = false;
            Height = 0;
            TurnsToBurn = 0;
        }

        public void LoadContent(string tilevalues)
        {
            string[] tilevaluepair = tilevalues.Split(':');

            int type = Convert.ToInt32(tilevaluepair[0]);
            Height = Convert.ToInt32(tilevaluepair[1]);

            //We can come up with many types, not just 3. (Double digit ints and negative ints can be read as well.)
            switch (type)
            {
                case 1:
                    Walkable = true;
                    Damaging = false;
                    TurnsToBurn = 1;
                    break;
                case 2:
                    Walkable = true;
                    Damaging = true;
                    break;
                default:
                    Walkable = false;
                    Damaging = false;
                    break;
            }
        }

        public void UnloadContent()
        {

        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {

        }
    }
}
