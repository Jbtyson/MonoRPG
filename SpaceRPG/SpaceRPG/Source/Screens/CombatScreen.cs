// CombatScreen.cs
// James Tyson
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using SpaceRPG.Source.Managers;
using SpaceRPG.Source.Visuals.Maps;

namespace SpaceRPG.Source.Screens
{
    public class CombatScreen : GameScreen
    {
        private CombatManager _combatManager;
        private Map _map;

        public static string EncounterId;

        public CombatScreen()
        {
            _combatManager = new CombatManager();
            _map = new Map();
        }

        public override void LoadContent()
        {
            base.LoadContent();

            // Load the Map
            XmlManager<Map> mapLoader = new XmlManager<Map>();
            _map = mapLoader.Load(EncounterId +"Map.xml");
            _map.LoadContent();

            // Load the combat manager
            XmlManager<CombatManager> combatManagerLoader = new XmlManager<CombatManager>();
            _combatManager = combatManagerLoader.Load("Load/Gameplay/Combat/CombatManager.xml");
            _combatManager.LoadContent(_map);
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
            _map.UnloadContent();
            _combatManager.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            _map.Update(gameTime);
            _combatManager.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            _map.Draw(spriteBatch, "underlay");
            _combatManager.Draw(spriteBatch);
            _map.Draw(spriteBatch, "overlay");
        }
    }
}
