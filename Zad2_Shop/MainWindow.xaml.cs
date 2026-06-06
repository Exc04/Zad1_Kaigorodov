using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Zad2_Shop
{
    public partial class MainWindow : Window
    {
        private Shop shop;

        public MainWindow()
        {
            InitializeComponent();
            shop = new Shop();
            Update();
        }

        
        // Добавление товара
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            string name = txtName.Text;
            if (!decimal.TryParse(txtPrice.Text, out decimal price))
            {
                MessageBox.Show("Неправильная цена!", "Ошибка");
                return;
            }
            if (!int.TryParse(txtCount.Text, out int count) || count <= 0)
            {
                MessageBox.Show("Неправильное количество!", "Ошибка");
                return;
            }

            if (shop.AddProduct(name, price, count))
            {
                MessageBox.Show($"Товар '{name}' добавлен!", "Успех");
                ClearInputs();
                Update();
            }
            else
            {
                MessageBox.Show("Ошибка добавления товара!", "Ошибка");
            }
        }

        
        // Продажа товара
        private void BtnSell_Click(object sender, RoutedEventArgs e)
        {
            string name = txtSellName.Text;
            if (!int.TryParse(txtSellCount.Text, out int count) || count <= 0)
                count = 1;

            if (shop.SellProduct(name, count))
            {
                MessageBox.Show($"Товар '{name}' продан!", "Успех");
                txtSellName.Text = "";
                txtSellCount.Text = "1";
                Update();
            }
            else
            {
                MessageBox.Show("Товар не найден или недостаточно!", "Ошибка");
            }
        }

        
        // Обновление интерфейса
        private void Update()
        {
            lbProducts.Items.Clear();
            foreach (var item in shop.GetAllProducts())
            {
                lbProducts.Items.Add($"{item.Key.GetInfo()} | {item.Value} шт.");
            }
            tbProfit.Text = $"Прибыль: {shop.GetProfit()} руб.";
        }

        
        // Очистка полей ввода
        private void ClearInputs()
        {
            txtName.Text = "";
            txtPrice.Text = "";
            txtCount.Text = "";
        }

       
        // Показать все товары
        private void ShowAllProducts()
        {
            if (shop.GetAllProducts().Count == 0)
            {
                MessageBox.Show("Товаров нет!", "Информация");
                return;
            }

            string msg = " СПИСОК ТОВАРОВ \n\n";
            foreach (var item in shop.GetAllProducts())
            {
                msg += $"{item.Key.GetInfo()} | {item.Value} шт.\n";
            }
            MessageBox.Show(msg, "Все товары");
        }


        // Обработчики меню
        private void MenuAdd_Click(object sender, RoutedEventArgs e) => BtnAdd_Click(null, null);
        private void MenuSell_Click(object sender, RoutedEventArgs e) => BtnSell_Click(null, null);
        private void MenuShowAll_Click(object sender, RoutedEventArgs e) => ShowAllProducts();
        private void MenuExit_Click(object sender, RoutedEventArgs e) => this.Close();

    }
}
