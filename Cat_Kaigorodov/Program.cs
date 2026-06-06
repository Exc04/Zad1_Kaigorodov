using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cat_Kaigorodov
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество котов: ");
            int Count = Convert.ToInt32(Console.ReadLine());

            Cat[] cats = new Cat[Count];

            for (int i = 0; i < Count; i++)
            {
                Console.WriteLine($"----Кот №{i + 1}----");

                cats[i] = new Cat("");

                Console.Write($"Введите имя кота: ");
                cats[i].Name = Console.ReadLine();

                Console.Write($"Введите вес кота (0 < вес <= 20): ");
                cats[i].Ves = Convert.ToDouble(Console.ReadLine());
            }

            Console.WriteLine("---- Результат ----");
            
            for (int i = 0; i < Count; i++)
            {
                Console.WriteLine($"Кот {i + 1}: ");
                cats[i].golos();
                Console.WriteLine($"Вес: {cats[i].Ves} кг");
            }

            Console.ReadLine();
        }

        
    }
}
