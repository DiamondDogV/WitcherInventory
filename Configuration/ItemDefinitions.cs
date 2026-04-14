using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using static WitcherInventory.Entities.Weapon;

namespace WitcherInventory.Configuration
{
    public class ItemDefinition
    {
        public string Type { get; set; }
        public object[] Parameters { get; set; }
        public Image Icon { get; set; }
    }

    public static class ItemDatabase
    {
        public static List<ItemDefinition> GetAllItems()
        {
            return new List<ItemDefinition>
            {
                new ItemDefinition
                {
                    Type = "Sword",
                    Parameters = new object[] { "Стальной меч", 3.5, 200, 150, DamageType.Steel },
                    Icon = Properties.Resources.SteelSword
                },
                new ItemDefinition
                {
                    Type = "Sword",
                    Parameters = new object[] { "Серебряный меч", 3.0, 300, 120, DamageType.Silver },
                    Icon = Properties.Resources.SilverSword
                },
                new ItemDefinition
                {
                    Type = "Potion",
                    Parameters = new object[] { "Ласточка", 0.1, 20, 5 },
                    Icon = Properties.Resources.Swallow
                },
                new ItemDefinition
                {
                    Type = "Potion",
                    Parameters = new object[] { "Кошка", 0.1, 10, 1 },
                    Icon = Properties.Resources.Cat
                },
                new ItemDefinition
                {
                    Type = "Armor",
                    Parameters = new object[] { "Доспех Ворона", 5.0, 300, 100, 50 },
                    Icon = Properties.Resources.CrowArmor
                },
                new ItemDefinition
                {
                    Type = "Bomb",
                    Parameters = new object[] { "Сев. ветер", 0.5, 30, 70, DamageType.Ice, 4 },
                    Icon = Properties.Resources.NorthWind
                },
                new ItemDefinition
                {
                    Type = "Bomb",
                    Parameters = new object[] { "Двимерит", 0.5, 50, 60, DamageType.Dimeritium, 2 },
                    Icon = Properties.Resources.Dimeritium
                },
                new ItemDefinition
                {
                    Type = "Bomb",
                    Parameters = new object[] { "Лунн. пыль", 0.5, 50, 80, DamageType.Silver, 5 },
                    Icon = Properties.Resources.MoonDust
                }
            };
        }
    }
}
