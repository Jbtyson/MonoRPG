// CombatManager.cs
// James Tyson
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
    public class CombatManager
    {
        private Party _party;
        private Encounter _encounter;

        public CombatManager()
        {
            _party = new Party();
            _encounter = new Encounter();
        }

        public void LoadContent()
        {
            // Load the party
            XmlManager<Party> partyLoader = new XmlManager<Party>();
            _party = partyLoader.Load("Load/Gameplay/Combat/Party.xml");
            _party.LoadContent();

            // Load the encounter
            XmlManager<Encounter> encounterLoader = new XmlManager<Encounter>();
            _encounter = encounterLoader.Load(CombatScreen.EncounterId);
            _encounter.LoadContent();
        }

        public void UnloadContent()
        {
            _party.UnloadContent();
            _encounter.UnloadContent();
        }

        public void Update(GameTime gameTime)
        {
            _party.Update(gameTime);
            _encounter.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            _encounter.Draw(spriteBatch);
            _party.Draw(spriteBatch);            
        }
    }
}