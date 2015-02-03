// CombatScreen.cs
// James Tyson
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using MonoRPG.Source.Managers;
using MonoRPG.Source.Visuals.Maps.Isometric;

namespace MonoRPG.Source.Screens
{
    public class CombatScreen : GameScreen
    {
        private CombatManager _combatManager;
        private IsometricMap _map;
        private UiManager _uiManager;

        public bool ClickOnUi { get { return _uiManager.IsMouseOnUi(); } }

        public static string EncounterId;

        public CombatScreen()
        {
            _combatManager = new CombatManager();
            _map = new IsometricMap();
            _uiManager = new UiManager();
        }

        public override void LoadContent()
        {
            base.LoadContent();

            // Load the OrthogonalMap
            XmlManager<IsometricMap> mapLoader = new XmlManager<IsometricMap>();
            _map = mapLoader.Load(EncounterId +"Map.xml");
            _map.LoadContent();


            // Load the UiManager
            XmlManager<UiManager> uiManagerLoader = new XmlManager<UiManager>();
            _uiManager = uiManagerLoader.Load("Load/Gameplay/Combat/UiManager.xml");
            _uiManager.LoadContent();

            // Load the combat manager
            XmlManager<CombatManager> combatManagerLoader = new XmlManager<CombatManager>();
            _combatManager = combatManagerLoader.Load("Load/Gameplay/Combat/CombatManager.xml");
            _combatManager.LoadContent(_map);

            // Set the top left corner of the camera to (0,0)
            ScreenManager.Instance.Camera.SetWorldPosition(Vector2.Zero);
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
            _map.UnloadContent();
            _combatManager.UnloadContent();
            _uiManager.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            _map.Update(gameTime);
            _combatManager.Update(gameTime);
            _uiManager.Update(gameTime);

            // Allow for for camera movement
            MoveCamera(gameTime);
        }

        /// <summary>
        /// Checks for inputs related to camera movement
        /// </summary>
        /// <param name="gameTime"></param>
        public void MoveCamera(GameTime gameTime)
        {
            if (InputManager.Instance.KeyDown(Keys.Up))
                ScreenManager.Instance.Camera.Position.Y -= (float)(300 * gameTime.ElapsedGameTime.TotalSeconds);
            if (InputManager.Instance.KeyDown(Keys.Down))
                ScreenManager.Instance.Camera.Position.Y += (float)(300 * gameTime.ElapsedGameTime.TotalSeconds);
            if (InputManager.Instance.KeyDown(Keys.Left))
                ScreenManager.Instance.Camera.Position.X -= (float)(300 * gameTime.ElapsedGameTime.TotalSeconds);
            if (InputManager.Instance.KeyDown(Keys.Right))
                ScreenManager.Instance.Camera.Position.X += (float)(300 * gameTime.ElapsedGameTime.TotalSeconds);
           
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            _map.Draw(spriteBatch, "Underlay");
            _combatManager.Draw(spriteBatch);
            _map.Draw(spriteBatch, "Overlay");
            _uiManager.Draw(spriteBatch);
        }
    }
}
