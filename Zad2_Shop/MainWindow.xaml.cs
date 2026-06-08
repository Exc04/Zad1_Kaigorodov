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
        private Shop pyaterochka;

        public MainWindow()
        {
            InitializeComponent();

            pyaterochka = new Shop();

            // Тестовые товары
            pyaterochka.CreateProduct("Кола", 85, 200);
            pyaterochka.CreateProduct("Сок \"Добрый\"", 100, 50);
            pyaterochka.CreateProduct("Хлеб", 45, 30);
            pyaterochka.CreateProduct("Молоко", 79, 25);

            UpdateProductList();
        }

        private void UpdateProductList()
        {
            lstProducts.Items.Clear();

            var productsField = typeof(Shop).GetField("products",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            var products = productsField?.GetValue(pyaterochka) as Dictionary<Product, int>;

            if (products != null)
            {
                foreach (var product in products)
                {
                    lstProducts.Items.Add($"{product.Key.GetInfo()} | Количество: {product.Value} шт.");
                }
            }
        }


        private void BtnCreate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtName.Text))
                {
                    MessageBox.Show("Введите наименование товара!", "Ошибка",
                                    MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (!decimal.TryParse(txtPrice.Text, out decimal price) || price <= 0)
                {
                    MessageBox.Show("Некорректные данные!", "Ошибка",
                                    MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (!int.TryParse(txtCount.Text, out int count) || count <= 0)
                {
                    MessageBox.Show("Некорректные данные!", "Ошибка",
                                    MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                pyaterochka.CreateProduct(txtName.Text, price, count);

                txtName.Clear();
                txtPrice.Clear();
                txtCount.Clear();

                UpdateProductList();

                MessageBox.Show("Товар успешно добавлен!", "Успех",
                                MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
                                MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnSell_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtSellName.Text))
                {
                    MessageBox.Show("Введите наименование товара!", "Ошибка",
                                    MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                // Получаем количество для продажи
                int count = 1;
                if (!string.IsNullOrWhiteSpace(txtSellCount.Text))
                {
                    int.TryParse(txtSellCount.Text, out count);
                    if (count <= 0) count = 1;
                }

                // Проверка наличия товара
                if (!pyaterochka.Check(txtSellName.Text, count))
                {
                    MessageBox.Show($"Недостаточно товара {txtSellName.Text} в наличии!",
                                    "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                // Продажа нескольких товаров 
                pyaterochka.Sell(txtSellName.Text, count);

                txtSellName.Clear();
                txtSellCount.Text = "1";

                UpdateProductList();

                MessageBox.Show($"Успешно продано {count} шт. товара!", "Успех",
                                MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
                                MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnShowProfit_Click(object sender, RoutedEventArgs e)
        {
            pyaterochka.GetProfit("Текущая прибыль магазина");
        }

        private void BtnShowStats_Click(object sender, RoutedEventArgs e)
        {
            // Вызываем метод статистики
            pyaterochka.GetStatistics();
        }
    }
}
