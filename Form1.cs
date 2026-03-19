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
using static WitcherInventory.Entities.Weapon;

namespace WitcherInventory
{
    public partial class WitcherInventory : Form
    {
        private Inventory _inventory;

        private Sword _selectedSword;       // Выбранный меч
        private Armor _selectedArmor;       // Выбранная броня
        private Potion _selectedPotion;     // Выбранное зелье
        private Bomb _selectedBomb;         // Выбранная бомба

        public WitcherInventory()
        {
            InitializeComponent();

            // Создаем инвентарь
            _inventory = new Inventory();

            // Добавляем тестовые предметы
            _inventory.AddItem(new Sword("Стальной меч", 3.5, 200, 150, DamageType.Steel));
            _inventory[0].Icon = Properties.Resources.SteelSword;
            _inventory.AddItem(new Swallow("Ласточка", 0.1, 20, 5));
            _inventory[1].Icon = Properties.Resources.Swallow;
            _inventory.AddItem(new Armor("Доспех Ворона", 5.0, 300, 100, 50));
            _inventory[2].Icon = Properties.Resources.CrowArmor;
            _inventory.AddItem(new Bomb("Сев. ветер", 0.5, 30, 70, DamageType.Ice, 4));
            _inventory[3].Icon = Properties.Resources.NorthWind;
            _inventory.AddItem(new SuperiorCat("Кошка", 0.1, 10, 1));
            _inventory[4].Icon = Properties.Resources.Cat;
            _inventory.AddItem(new Sword("Серебряный меч", 3.0, 300, 120, DamageType.Silver));
            _inventory[5].Icon = Properties.Resources.SilverSword;

            // Обновляем ListBox
            _inventory.UpdateListBox(listBox1);

            listBox1.MouseDoubleClick += ItemsListBox_MouseDoubleClick;
            SwordButton.Click += SwordButton_Click;
            ArmorButton.Click += ArmorButton_Click;
            PotionButton.Click += PotionButton_Click;
            BombButton.Click += BombButton_Click;
        }

        //Обработчик нажатия на предмет в списке
        private void ItemsListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = listBox1.IndexFromPoint(e.Location);

            if (index != ListBox.NoMatches && index < _inventory.Count)
            {
                Item selectedItem = _inventory[index];

                // Используем предмет при двойном клике
                switch (selectedItem)
                {
                    case Sword sword:
                        SetSelectedSword(sword);
                        break;

                    case Bomb bomb:
                        SetSelectedBomb(bomb);
                        break;

                    case Potion potion:
                        SetSelectedPotion(potion);
                        break;

                    case Armor armor:
                        SetSelectedArmor(armor);
                        break;

                    default:
                        throw new IndexOutOfRangeException("Неопознанный предмет");
                }
            }
        }

        // Установка выбранного предмета
        private void SetSelectedSword(Sword sword)
        {
            _selectedSword = sword;
            SwordButton.BackgroundImage = sword.Icon;
        }
        private void SetSelectedBomb(Bomb bomb)
        {
            _selectedBomb = bomb;
            BombButton.BackgroundImage = bomb.Icon;
        }
        private void SetSelectedPotion(Potion potion)
        {
            _selectedPotion = potion;
            PotionButton.BackgroundImage = potion.Icon;
        }
        private void SetSelectedArmor(Armor armor)
        {
            _selectedArmor = armor;
            ArmorButton.BackgroundImage = armor.Icon;
        }

        // Обработка нажатий
        private void SwordButton_Click(object sender, EventArgs e)
        {
            if (_selectedSword != null)
                TextBoxLog.AppendText(_selectedSword.Attack() + "\r\n");
        }
        private void ArmorButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (_selectedArmor != null)
                    TextBoxLog.AppendText(_selectedArmor.Fix() + "\r\n");
            }
            catch (InvalidOperationException ex)
            {
                System.Windows.Forms.MessageBox.Show("Броня не нуждается в починке");
            }
        }
        private void PotionButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (_selectedPotion != null)
                    TextBoxLog.AppendText(_selectedPotion.Drink() + "\r\n");
            }
            catch (InvalidOperationException ex)
            {
                System.Windows.Forms.MessageBox.Show("Нет зелий этого типа");
            }

            _inventory.UpdateListBox(listBox1);
        }
        private void BombButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (_selectedBomb != null)
                    TextBoxLog.AppendText(_selectedBomb.Attack() + "\r\n");
            }
            catch (InvalidOperationException ex)
            {
                System.Windows.Forms.MessageBox.Show("Нет бомб этого типа");
            }

            _inventory.UpdateListBox(listBox1);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
