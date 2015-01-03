using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace SpaceRPG.Source.Gameplay.Items
{
    public class Reward
    {
        public int Exp;
        [XmlElement("Item")]
        public List<Item> Items;

        public Reward()
        {
            Exp = 0;
            Items = new List<Item>();
        }
    }
}
