using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WitcherInventory.Entities;

namespace WitcherInventory.Collections
{
    // Класс для управления инвентарем ведьмака
    public class Inventory
    {
        private List<Item> _items;      // Приватное поле для хранения предметов

        // Конструктор
        public Inventory()
        {
            _items = new List<Item>();
        }

        // Добавить предмет
        public void AddItem(Item item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            _items.Add(item);
        }

        // Свойство для доступа к предметам (только чтение)
        public IReadOnlyList<Item> Items
        {
            get { return _items.AsReadOnly(); }
        }

        // Количество предметов в инвентаре
        public int Count
        {
            get { return _items.Count; }
        }

        // Индексатор для доступа по индексу
        public Item this[int index]
        {
            get {
                if (index < 0 || index >= _items.Count)
                    throw new IndexOutOfRangeException("Индекс вне диапазона");
                return _items[index];
            }
        }

        // Получить список строк для отображения в ListBox
        public List<string> GetDisplayList()
        {
            List<string> displayList = new List<string>();

            for (int i = 0; i < _items.Count; i++)
            {
                displayList.Add($"{_items[i].GetDisplayText()}");
            }

            return displayList;
        }

        // Обновить ListBox
        public void UpdateListBox(ListBox listBox)
        {
            if (listBox != null)
            {
                listBox.DataSource = null;
                listBox.DataSource = GetDisplayList();
            }
        }

    }
}
