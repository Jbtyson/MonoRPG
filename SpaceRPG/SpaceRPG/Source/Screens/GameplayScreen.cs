// GameplayScreen.cs
// James Tyson
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceRPG
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
            XmlManager<Map> mapLaoder = new XmlManager<Map>();
            _map = mapLaoder.Load("Load/Gameplay/Maps/Map1.xml");
            _map.LoadContent();
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
            _player.UnloadContent();
            _map.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            // Update player and then map so that the players actions matter this frame
            _player.Update(gameTime);
            _map.Update(gameTime, ref _player);

            // Update the camera position to our new position
            ScreenManager.Instance.Camera.Position = _player.Image.Position;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);

            // Draw the underlaying tiles, the player, and then the overlaying tiles
            _map.Draw(spriteBatch, "Underlay");
            _player.Draw(spriteBatch);
            _map.Draw(spriteBatch, "Overlay");
        }
    }
}
