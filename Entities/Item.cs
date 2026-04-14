using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WitcherInventory.Entities
{
    // Абстрактный базовый класс для всех предметов в инвентаре
    public abstract class Item
    {
        private string _name;             // Название предмета
        private double _weight;           // Вес в кг
        private int _cost;                // Цена в кронах
        private Image _icon;              // Иконка предмета

        // Конструктор
        protected Item(string name, double weight, int cost)
        {
            _name = name;
            _weight = weight;
            _cost = cost;
        }

        // Свойства (Properties) - инкапсулированный доступ к полям
        public string Name
        {
            get { return _name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Название не может быть пустым");
                _name = value;
            }
        }
        public double Weight
        {
            get { return _weight; }
            set {
                if (value < 0)
                    throw new ArgumentException("Вес не может быть отрицательным");
                _weight = value;
            }
        }
        public int Cost
        {
            get { return _cost; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Цена не может быть отрицательной");
                _cost = value;
            }
        }
        public Image Icon
        {
            get { return _icon; }
            set { _icon = value; }
        }

        //Общий вес предмета
        public virtual double TotalWeight
        {
            get { return _weight; }
        }

        public virtual string Use()
        {
            return $"Вы использовали {Name}";
        }

        public abstract string GetDisplayText();
    }
}
