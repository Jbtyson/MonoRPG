// Encounter.cs
// James Tyson
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using SpaceRPG.Source.Gameplay.Items;
using SpaceRPG.Source.Gameplay.Combat.Actors;

namespace SpaceRPG.Source.Gameplay.Combat
{
    public class Encounter
    {
        [XmlElement("Enemy")]
        public List<Enemy> Enemies;
        public Reward Rewards;

        public Encounter()
        {
            Enemies = new List<Enemy>();
        }

        public void LoadContent()
        {
            foreach (Enemy e in Enemies)
                e.LoadContent();
        }

        public void UnloadContent()
        {
            foreach (Enemy e in Enemies)
                e.UnloadContent();
        }

        public void Update(GameTime gameTime)
        {
            foreach (Enemy e in Enemies)
                e.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Enemy e in Enemies)
                e.Draw(spriteBatch);
        }
    }
}