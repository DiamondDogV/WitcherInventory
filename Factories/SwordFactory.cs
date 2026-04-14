using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WitcherInventory.Entities;
using static WitcherInventory.Entities.Weapon;

namespace WitcherInventory.Factories
{
    public class SwordFactory : IItemFactory
    {
        public string ItemType => "Sword";

        public Item CreateItem(params object[] parameters)
        {
            string name = (string)parameters[0];
            double weight = (double)parameters[1];
            int cost = (int)parameters[2];
            int damage = (int)parameters[3];
            DamageType damageType = (DamageType)parameters[4];

            var sword = new Sword(name, weight, cost, damage, damageType);

            if (damageType == DamageType.Steel)
                sword.Icon = Properties.Resources.SteelSword;
            if (damageType == DamageType.Silver)
                sword.Icon = Properties.Resources.SilverSword;

            return sword;
        }
    }
}