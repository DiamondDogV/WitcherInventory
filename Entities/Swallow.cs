using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WitcherInventory.Entities
{
    //Зелье ласточка
    public class Swallow : Potion
    {
        private const int _maxCount = 5;

        // Конструктор
        public Swallow(string name, double weight, int cost, int count)
            : base(name, weight, cost, count)
        {
        }

        // Эффект отхил
        public override string PotionEffect()
        {
            return "Здоровье восстановлено на 50%";
        }
    }
}
