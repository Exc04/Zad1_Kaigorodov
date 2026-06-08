using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad2_Shop
{
    public class Product
    {
        private decimal price;
        private string name;

        // Конструктор товара
        public Product(string Name, decimal Price)
        {
            name = Name;
            price = Price;
        }

        
        // Возвращает информацию о товаре
        
        public string GetInfo()
        {
            return $"Наименование: {name}; Цена: {price}";
        }

        public decimal Price { get { return price; } set { price = value; } }
        public string Name { get { return name; } set { name = value; } }
    }
}
