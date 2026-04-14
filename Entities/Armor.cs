using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WitcherInventory.Entities
{
    // Базовый класс для облачения
    public class Armor : Item
    {
        private int _durability;
        private int _protection;

        // Конструктор
        public Armor(string name, double weight, int cost, int durability, int protection)
            : base(name, weight, cost)
        {
            _durability = durability;
            _protection = protection;
        }

        // Текущая прочность (0-100)
        public int Durability
        {
            get { return _durability; }
            private set
            {
                _durability = value;
                _durability = Math.Max(_durability, 0);
                _durability = Math.Min(_durability, 100);

                if (_durability == 0)
                {
                    System.Windows.Forms.MessageBox.Show("Броня разрушена");
                    Protection /= 2;
                }
            }
        }

        //Защита доспеха
        public int Protection
        {
            get { return _protection; }
            set { _protection = value; }
        }

        public override string Use()
        {
            return Fix();
        }
        //Починка
        public string Fix()
        {
            if (!IsBroken)
            {
                return "Броня не нуждается в починке";
            }
            Durability = 100;
            Protection *= 2;

            return "Броня починена";
        }

        // Разрушена ли броня?
        public bool IsBroken
        {
            get { return _durability == 0; }
        }

        public override string GetDisplayText()
        {
            return $"{Name,-14}   {Protection,3}        {TotalWeight,-4}  {Cost,3}";
        }
    }
}
