using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Zad2_Shop
{
    public class Shop
    {
        private Dictionary<Product, int> products;  // Товары и их количество
        private decimal totalProfit;                 // Прибыль магазина
        private int totalsold = 0;                  //Счетчик продаж

        
        // Конструктор магазина
      
        public Shop()
        {
            products = new Dictionary<Product, int>();
            totalProfit = 0;
        }

        // Получение прибыли

        public decimal GetProfit()
        {
            return totalProfit;
        }

        // поиск товар по имени

        public Product FindByName(string name)
        {
            return products.Keys.FirstOrDefault(p => p.Name == name);
        }

       
        // Получение количество товара
       
        public int GetProductCount(Product product)
        {
            return products.ContainsKey(product) ? products[product] : 0;
        }

        // Добавление товар в магазин

        public bool AddProduct(string name, decimal price, int count)
        {
            if (string.IsNullOrEmpty(name) || price <= 0 || count <= 0)
                return false;

            var existing = FindByName(name);
            if (existing != null)
            {
                products[existing] += count;
            }
            else
            {
                products.Add(new Product(name, price), count);
            }
            return true;
        }

        // Продажа товар

        public bool SellProduct(string name, int count = 1)
        {
            var product = FindByName(name);
            if (product == null || !products.ContainsKey(product))
                return false;

            if (products[product] < count)
                return false;

            products[product] -= count;
            totalProfit += product.Price * count;

            if (products[product] == 0)
                products.Remove(product);
            totalsold++;
            return true;
        }

        public string GetStats()
        {
            return $"Продано {totalsold} шт. | Прибыль: {totalProfit} руб.";
        }
        
        // Получение товаров
        
        public Dictionary<Product, int> GetAllProducts()
        {
            return products;
        }
    }
}
