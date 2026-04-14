using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WitcherInventory.Entities;

namespace WitcherInventory.Factories
{
    public class ArmorFactory : IItemFactory
    {
        public string ItemType => "Armor";

        public Item CreateItem(params object[] parameters)
        {
            string name = (string)parameters[0];
            double weight = (double)parameters[1];
            int cost = (int)parameters[2];
            int durability = (int)parameters[3];
            int protection = (int)parameters[4];

            var armor = new Armor(name, weight, cost, durability, protection);

            armor.Icon = Properties.Resources.CrowArmor;

            return armor;
        }
    }
}
