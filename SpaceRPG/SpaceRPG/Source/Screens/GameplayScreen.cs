// GameplayScreen.cs
// James Tyson
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using SpaceRPG.Source.Gameplay;
using SpaceRPG.Source.Managers;
using SpaceRPG.Source.Visuals.Maps;

namespace SpaceRPG.Source.Screens
{
    /// <summary>
    /// Gameplay Screen represents the screen that the player "playes the game" in
    /// </summary>
    public class GameplayScreen : GameScreen
    {
        private Player _player;
        private Map _map;

        public override void LoadContent()
        {
            base.LoadContent();

            // Load the player
            XmlManager<Player> playerLoader = new XmlManager<Player>();
            _player = playerLoader.Load("Load/Gameplay/Characters/Player.xml");
            _player.LoadContent();

            // Load the Map
            XmlManager<Map> MapLoader = new XmlManager<Map>();
            _map = MapLoader.Load("Load/Gameplay/Maps/Map1.xml");
            _map.LoadContent();
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
            _player.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            // Update player and then map so that the players actions matter this frame
            _player.Update(gameTime);
            _map.Update(gameTime);

            // Initiate Combat
            if (InputManager.Instance.KeyPressed(Keys.Enter) && !ScreenManager.Instance.IsTransitioning)
            {
                CombatScreen.EncounterId = "Load/Gameplay/Levels/Tutorial/Encounter1";
                ScreenManager.Instance.ChangeScreens("CombatScreen");
            }                
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);

            // Draw map before player so that the player appears on top
            _map.Draw(spriteBatch);
            _player.Draw(spriteBatch);
        }
    }
}
