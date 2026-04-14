using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WitcherInventory.Entities;
using static WitcherInventory.Entities.Weapon;

namespace WitcherInventory.Factories
{
    internal class BombFactory : IItemFactory
    {
        public string ItemType => "Bomb";

        public Item CreateItem(params object[] parameters)
        {
            string name = (string)parameters[0];
            double weight = (double)parameters[1];
            int cost = (int)parameters[2];
            int damage = (int)parameters[3];
            DamageType damageType = (DamageType)parameters[4];
            int count = (int)parameters[5];

            var bomb = new Bomb(name, weight, cost, damage, damageType, count);

            if (name == "Сев. ветер")
                bomb.Icon = Properties.Resources.NorthWind;
            if (name == "Двимерит")
                bomb.Icon = Properties.Resources.Dimeritium;
            if (name == "Лунная пыль")
                bomb.Icon = Properties.Resources.MoonDust;

            return bomb;
        }
    }
}
