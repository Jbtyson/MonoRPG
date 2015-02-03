﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

using MonoRPG.Source.Gameplay.Combat.Maps;

namespace MonoRPG.Source.Gameplay.Combat.Maps
{
    public interface ICombatGrid
    {
        CombatTile GetTileAtPosition(Point loc, int height);
        CombatTile GetTileAtPosition(Vector2 loc, int height);
        CombatTile[,] GetGrid();
        CombatTile this[int x, int y] { get; set; }
    }
}
