using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using MonoRPG.Source.Gameplay.Combat.Actors;
using MonoRPG.Source.Gameplay.Combat.Maps;

namespace MonoRPG.Source.Gameplay.Combat
{
    public class Party
    {
        public delegate CombatTile GetTile(Point loc);
        GetTile GetTileAt;

        [XmlElement("Ally")]
        public List<Ally> Members;

        public Party()
        {
            Members = new List<Ally>();
        }

        public void LoadContent(ICombatGrid grid)
        {
            foreach (Ally ally in Members)
                ally.LoadContent(grid);
        }

        public void UnloadContent()
        {
            foreach (Ally ally in Members)
                ally.UnloadContent();
        }

        public void Update(GameTime gameTime)
        {
            foreach (Ally ally in Members)
                ally.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Ally ally in Members)
                ally.Draw(spriteBatch);
        }
    }
}
