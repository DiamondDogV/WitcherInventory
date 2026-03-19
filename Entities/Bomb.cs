using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WitcherInventory.Entities
{
    // Класс для бомб
    public class Bomb : Weapon
    {
        private int _count;
        private const int _maxCount = 10;

        // Конструктор
        public Bomb(string name, double weight, int cost,
                    int damage, DamageType damageType, int count)
            : base(name, weight, cost, damage, damageType)
        {
            if (count > _maxCount)
                throw new ArgumentException($"Нельзя иметь больше {_maxCount} бомб этого типа");
            _count = count;
        }

        public int Count
        {
            get { return _count; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Количество не может быть отрицательным");
                if (value > _maxCount)
                    throw new ArgumentException($"Нельзя иметь больше {_maxCount} бомб такого типа");

                _count = value;
            }
        }

        public override string Attack()
        {
            if (Count == 0)
                throw new InvalidOperationException("Нет бомб");
            Count--;

            return $"Было нанесено {Damage} единиц {DamageTypeToString(DamageTypeMethod)} урона";
        }

        public override double TotalWeight
        {
            get { return Weight * Count; }
        }

        public override string GetDisplayText()
        {
            return $"{Count,-2} {Name,-10}    {Damage,3}        {TotalWeight,-4}  {Cost,3}";
        }
    }
}
