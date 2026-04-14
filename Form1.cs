using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WitcherInventory.Collections;
using WitcherInventory.Entities;
using WitcherInventory.Factories;
using WitcherInventory.Configuration;
using static WitcherInventory.Entities.Weapon;

namespace WitcherInventory
{
    public partial class WitcherInventory : Form
    {
        private Inventory _inventory;
        private ItemFactoryRegistry _factoryRegistry;

        // Словарь для хранения выбранных предметов
        private Dictionary<Type, Item> _selectedItems = new Dictionary<Type, Item>();
        // Словарь соответствия тип предмета -> кнопка
        private Dictionary<Type, Button> _typeToButton;

        public WitcherInventory()
        {
            InitializeComponent();

            InitializeFactories();
            InitializeInventory();
            InitializeButtonMapping();
        }

        private void InitializeFactories()
        {
            _factoryRegistry = new ItemFactoryRegistry();

            // Регистрируем все фабрики
            _factoryRegistry.RegisterFactory(new SwordFactory());
            _factoryRegistry.RegisterFactory(new ArmorFactory());
            _factoryRegistry.RegisterFactory(new PotionFactory());
            _factoryRegistry.RegisterFactory(new BombFactory()); // Создайте аналогично
        }

        private void InitializeInventory()
        {
            _inventory = new Inventory();

            // Загружаем предметы из конфигурации
            var allItems = ItemDatabase.GetAllItems();

            foreach (var itemDef in allItems)
            {
                var item = _factoryRegistry.CreateItem(itemDef.Type, itemDef.Parameters);
                item.Icon = itemDef.Icon;
                _inventory.AddItem(item);
            }

            _inventory.UpdateListBox(listBox1, LabelWeight);
            listBox1.MouseDoubleClick += ItemsListBox_MouseDoubleClick;
        }

        private void InitializeButtonMapping()
        {
            _typeToButton = new Dictionary<Type, Button>
            {
                { typeof(Sword), SwordButton },
                { typeof(Armor), ArmorButton },
                { typeof(Swallow), PotionButton },
                { typeof(SuperiorCat), PotionButton },
                { typeof(Bomb), BombButton }
            };

            foreach (var button in _typeToButton.Values)
            {
                button.Click += ItemButton_Click;
            }
        }

        // Единый обработчик для всех кнопок
        private void ItemButton_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;

            // Находим тип предмета по кнопке
            foreach (var mapping in _typeToButton)
            {
                if (mapping.Value == clickedButton && _selectedItems.ContainsKey(mapping.Key))
                {
                    dynamic selectedItem = _selectedItems[mapping.Key];
                    string result = selectedItem.Use();

                    TextBoxLog.AppendText(result + "\r\n");

                    // Обновляем инвентарь после использования
                    _inventory.UpdateListBox(listBox1, LabelWeight);
                    break;
                }
            }
        }

        // Обновленный метод выбора предмета
        private void ItemsListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = listBox1.IndexFromPoint(e.Location);

            if (index != ListBox.NoMatches && index < _inventory.Count)
            {
                Item selectedItem = _inventory[index];

                // Сохраняем в словарь по типу предмета
                _selectedItems[selectedItem.GetType()] = selectedItem;

                // Обновляем иконку на соответствующей кнопке
                if (_typeToButton.ContainsKey(selectedItem.GetType()))
                {
                    _typeToButton[selectedItem.GetType()].BackgroundImage = selectedItem.Icon;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}