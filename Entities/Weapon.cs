using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WitcherInventory.Entities
{
    // Базовый класс для всего оружия в инвентаре Ведьмака
    public abstract class Weapon : Item
    {
        private int _damage;
        private DamageType _damageType;

        // Конструктор
        public Weapon(string name, double weight, int cost,
                      int damage, DamageType damageType)
            : base(name, weight, cost)
        {
            _damage = damage;
            _damageType = damageType;
        }

        // Базовый урон оружия
        public int Damage
        {
            get { return _damage; }
            set { _damage = value; }
        }

        // Тип урона
        public DamageType DamageTypeMethod
        {
            get { return _damageType; }
        }

        public override string Use()
        {
            return Attack();
        }
        // Атака оружием
        public virtual string Attack()
        {
            return $"Было нанесено {Damage} единиц {DamageTypeToString(DamageTypeMethod)} урона";
        }


        // Тип урона оружия
        public enum DamageType
        {
            Steel,      // Сталь
            Silver,     // Серебро
            Fire,       // Огонь
            Ice,        // Мороз
            Dimeritium   // Двимерит
        }

        public string DamageTypeToString (DamageType DamageTypeField)
        {
            switch (DamageTypeField)
            {
                case DamageType.Steel:
                    return "стального";
                    break;
                case DamageType.Silver:
                    return "серебряного";
                    break;
                case DamageType.Fire:
                    return "огненного";
                    break;
                case DamageType.Ice:
                    return "морозного";
                    break;
                case DamageType.Dimeritium:
                    return "двимеритного";
                    break;
                default:
                    return "неизвестного";
            }
        }
    }
}
