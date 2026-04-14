using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WitcherInventory.Entities;

namespace WitcherInventory.Factories
{
    public class PotionFactory : IItemFactory
    {
        public string ItemType => "Potion";

        public Item CreateItem(params object[] parameters)
        {
            string name = (string)parameters[0];
            double weight = (double)parameters[1];
            int cost = (int)parameters[2];
            int count = (int)parameters[3];

            // Можно создавать разные типы зелий
            if (name.Contains("Ласточка"))
            {
                var potion = new Swallow(name, weight, cost, count);
                potion.Icon = Properties.Resources.Swallow;
                return potion;
            }
            else
            {
                var potion = new SuperiorCat(name, weight, cost, count);
                potion.Icon = Properties.Resources.Cat;
                return potion;
            }
        }
    }
}