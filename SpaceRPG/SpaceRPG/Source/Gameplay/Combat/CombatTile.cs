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

        //Just examples of potential tile properties.
        private bool _walkable;
        private bool _damaging;
        private int _height;

        public bool Walkable { get { return _walkable; } }
        public bool Damaging { get {return _damaging;}}
        public int Height { get { return _height; }}

        public CombatTile() {
            _walkable = false;
            _damaging = false;
            _height = 0;
        }

        public void LoadContent(string tilevalues)
        {
            string[] tilevaluepair = tilevalues.Split(':');

            int type = Convert.ToInt32(tilevaluepair[0]);
            _height = Convert.ToInt32(tilevaluepair[1]);

            switch (type)
            {
                case 1:
                    _walkable = true;
                    _damaging = false;
                    break;
                case 2:
                    _walkable = true;
                    _damaging = true;
                    break;
                default:
                    _walkable = false;
                    _damaging = false;
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
