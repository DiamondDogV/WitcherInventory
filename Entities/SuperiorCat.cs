using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WitcherInventory.Entities
{
    //Зелье кошка
    public class SuperiorCat : Potion
    {

        // Конструктор
        public SuperiorCat(string name, double weight, int cost, int count)
            : base(name, weight, cost, count)
        {
        }

        // Эффект ночное зрение
        public override string PotionEffect()
        {
            return "Ведьмак видит в темноте следующие 5 минут";
        }
    }
}
