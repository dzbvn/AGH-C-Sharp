using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
       class Task1
    {
        public void Year()
        {
            while (true)
            {
                Console.WriteLine("\nEnter year:");
                int year = Convert.ToInt32(Console.ReadLine());
                if (year % 100 == 0)
                {
                    if (year % 400 == 0)
                    {
                        Console.WriteLine("Leap year!");
                    }
                    else
                    {
                        Console.WriteLine("Not a leap year!");
                    }
                }
                else if (year % 4 == 0)
                {
                    Console.WriteLine("Leap year!");
                }

            }
        }
    }
}