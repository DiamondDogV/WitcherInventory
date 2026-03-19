using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WitcherInventory.Entities
{
    // Базовый класс для зелья
    public abstract class Potion : Item
    {
        private int _count;
        private int _maxCount = 10;

        // Конструктор
        public Potion(string name, double weight, int cost, int count)
            : base(name, weight, cost)
        {
            if (_count > _maxCount)
                throw new ArgumentException($"Нельзя иметь больше {_maxCount} зелий этого типа");
            _count = count;
        }

        // Количество зелий
        public int Count
        {
            get { return _count; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Количество не может быть отрицательным");
                if (value > _maxCount)
                    throw new ArgumentException($"Нельзя иметь больше {_maxCount} зелий этого типа");

                _count = value;
            }
        }

        // Выпить зелье
        public string Drink()
        {
            // Проверяем, есть ли что пить
            if (Count > 0)
            {
                Count--;
            }
            else
            {
                throw new InvalidOperationException("Нет зелья");
            }
            string effect = PotionEffect();
            return effect;
        }

        //Эффект зелья
        public virtual string PotionEffect()
        {
            return "";
        }

        public override double TotalWeight
        {
            get { return Weight * Count; }
        }

        public override string GetDisplayText()
        {
            return $"{Count,-2} {Name,-17}        {TotalWeight,-4}  {Cost,3}";
        }
    }
}
