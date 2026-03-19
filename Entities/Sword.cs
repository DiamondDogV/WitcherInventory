using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WitcherInventory.Entities
{
    // Класс для мечей
    public class Sword : Weapon
    {
        // Конструктор
        public Sword(string name, double weight, int cost,
                    int damage, DamageType damageType)
            : base(name, weight, cost, damage, damageType)
        {
            if (damageType != DamageType.Steel && damageType != DamageType.Silver)
                throw new ArgumentException("Мечи такими не бывают");
        }

        public override string GetDisplayText()
        {
            return $"{Name,-14}   {Damage,3}        {TotalWeight,-4}  {Cost,3}";
        }
    }
}
