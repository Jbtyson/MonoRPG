// Stats.cs
// James Tyson
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonoRPG.Source.Gameplay.Combat
{
    public class Stats
    {
        public int Health;
        public int Attack;
        public int Defense;
        public double CritChance;
        public int CritDamage;
        public double DamageReduction;
        public int Speed;
        public int Level;

        public Stats()
        {
            Health = 0; Attack = 0; Defense = 0;
            CritChance = 0; CritDamage = 0;
            DamageReduction = 0; Speed = 0; Level = 0;
        }

    }
}

