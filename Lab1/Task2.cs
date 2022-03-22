using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Task2
    {
        
        public void Sum()
        {
            while (true)
            {
                Console.WriteLine("Enter positive number:");

                string number = Console.ReadLine();
                if (Convert.ToInt32(number) < 0)
                {
                    Console.WriteLine("The number is negative!");
                    System.Threading.Thread.Sleep(500);
                    return;
                }


                int res = 0;
                foreach (char c in number)
                {
                    res += c - '0';
                }
                Console.WriteLine(res);
            }

        }
    }
}