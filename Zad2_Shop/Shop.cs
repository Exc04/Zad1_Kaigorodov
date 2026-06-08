using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Threading.Tasks;
using System.IO;

namespace Zad2_Shop
{
    public class Shop
    {
        private Dictionary<Product, int> products;
        private decimal profit; // Прибыль магазина

        // Конструктор магазина
        public Shop()
        {
            products = new Dictionary<Product, int>();
            profit = 0; 
        }

        // Создать и добавить товар в магазин
        public void CreateProduct(string name, decimal price, int count)
        {
            products.Add(new Product(name, price), count);
        }

        // Продажа нескольких товаров 
        public void Sell(Product product, int count)
        {
            if (products.ContainsKey(product))
            {
                if (products[product] < count)
                {
                    MessageBox.Show($"Недостаточно товара! В наличии: {products[product]}");
                }
                else
                {
                    products[product] -= count;
                    profit += product.Price * count; 
                    MessageBox.Show($"Продано {count} шт. товара {product.Name}");
                }
            }
            else
            {
                MessageBox.Show("Товар не найден!");
            }
        }

        // Поиск товара по имени
        public Product FindByName(string name)
        {
            foreach (var product in products.Keys)
            {
                if (product.Name == name)
                {
                    return product;
                }
            }
            return null;
        }

        // Продажа нескольких товаров 
        public void Sell(string ProductName, int count)
        {
            Product ToSell = FindByName(ProductName);
            if (ToSell != null)
            {
                this.Sell(ToSell, count);
            }
            else
            {
                MessageBox.Show("Товар не найден!");
            }
        }

        // расчета прибыли магазина 
        public void GetProfit(string message)
        {
            MessageBox.Show($"{message}: {profit:F2} руб.", "Прибыль магазина");
        }

        // Статистика магазина 
        public void GetStatistics()
        {
            int totalSold = 0;
            decimal totalRevenue = profit; 

            // Подсчитываем общее количество проданных товаров
            string stats = "СТАТИСТИКА МАГАЗИНА\n\n";
            stats += $"Общая выручка: {profit:F2} руб.\n";
            stats += "\nОстатки товаров:\n";

            foreach (var product in products)
            {
                stats += $"{product.Key.GetInfo()} | Остаток: {product.Value} шт.\n";
            }

            MessageBox.Show(stats, "Статистика магазина");
        }


        // Проверить наличие товара
        public bool Check(string productName, int requestedCount)
        {
            Product product = FindByName(productName);
            if (product != null && products.ContainsKey(product))
            {
                return products[product] >= requestedCount;
            }
            return false;
        }
    }
}
