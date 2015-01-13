// CombatTile.cs
// Ben Stegeman
// James Tyson
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using SpaceRPG.Source.Managers;
using SpaceRPG.Source.Visuals;
using SpaceRPG.Source.Visuals.Maps;
using SpaceRPG.Source.Visuals.Maps.Isometric;
using SpaceRPG.Source.Util.Shapes;

namespace SpaceRPG.Source.Gameplay.Combat.Maps.Isometric
{
    /// <summary>
    /// CombatTile holds map data relevant to one specific tile on a map, such as whether it's impassable, height of the tile, etc.
    /// </summary>
    public class CombatTile
    {
        private IsometricTile _sourceTile;
        private Diamond _hitbox;
        private bool _hasCursor;

        public IsometricTile SourceTile
        {
            get { return _sourceTile; }
            set { _sourceTile = value; }
        }
        public bool HasCursor
        {
            get { return _hasCursor; }
            set { _hasCursor = value; }
        }

        //Just examples of potential tile properties. We'll need some more obvs.
        public bool Walkable;
        public int Type, Height;
        public bool Damaging;
        public int TurnsToBurn;

        public CombatTile() {
            Walkable = false;
            Damaging = false;
            Height = 0;
            TurnsToBurn = 0;
            _hitbox = new Diamond();
        }

        public void LoadContent(IsometricTile tile)
        {
            _sourceTile = tile;
            _hitbox = new Diamond(new Rectangle((int)tile.Position.X, (int)tile.Position.Y, tile.SourceRect.Width, tile.SourceRect.Height));
            Type = tile.Value1;
            Height = tile.Height;

            //We can come up with many types, not just 3. (Double digit ints and negative ints can be read as well.)
            switch (Type)
            {
                case 1:
                    Walkable = false;
                    Damaging = false;
                    break;
                case 2:
                    Walkable = true;
                    Damaging = false;
                    break;
                case 3:
                    Walkable = false;
                    Damaging = false;
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
            if (_hitbox.Contains(InputManager.Instance.MousePosition))
                _hasCursor = true;
            else
                _hasCursor = false;
        }

        public void Draw(SpriteBatch spriteBatch)
        {

        }
    }
}
