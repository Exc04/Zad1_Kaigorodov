using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad2_Shop
{
    public class Product
    {
        public decimal Price { get; set; }  // Цена товара
        public string Name { get; set; }    // Наименование товара

        
        // Конструктор товара
        public Product(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        
        // Возвращает информацию о товаре
        public string GetInfo()
        {
            return $"{Name} | {Price} руб.";
        }
    }
}
