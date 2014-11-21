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
    public class GameplayScreen : GameScreen
    {
        Player player;
        Map map;

        public override void LoadContent()
        {
            base.LoadContent();

            XmlManager<Player> playerLoader = new XmlManager<Player>();
            player = playerLoader.Load("Load/Gameplay/Characters/Player.xml");
            player.LoadContent();

            XmlManager<Map> mapLaoder = new XmlManager<Map>();
            map = mapLaoder.Load("Load/Gameplay/Maps/Map1.xml");
            map.LoadContent();
        }

        public override void UnloadContent()
        {
            base.UnloadContent();

            player.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            // Update player and then map
            player.Update(gameTime);
            map.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);

            // Draw map before player
            map.Draw(spriteBatch);
            player.Draw(spriteBatch);
        }
    }
}
