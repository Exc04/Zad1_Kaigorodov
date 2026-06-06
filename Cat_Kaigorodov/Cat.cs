using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cat_Kaigorodov
{
    class Cat
    {
        private string name;
        private double ves;
        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                bool OnlyLetters = true;

                foreach (var ch in value)
                {
                    if (!char.IsLetter(ch))
                    {
                        OnlyLetters = false;
                    }
                }

                if (OnlyLetters)
                {
                    name = value;
                }
                else
                {
                    Console.WriteLine($"{value} - неправильное имя!!!");
                }
            }
        }

        public double Ves
        {
            get
            {
                return ves;
            }

            set
            {
                if (value <= 0 || value > 20)
                {
                    Console.WriteLine($"{value} - неправильный вес!!!");
                }
                else
                {
                    ves = value;
                }
            }
        }

        public Cat(string CatName)
        {
            Name = CatName;
        }

        public void golos()
        {
            Console.WriteLine($"{name}: МЯЯЯУ!");
        }

    }
}
