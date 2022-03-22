using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Task3
    {
        public async void Check()
        {
            HashSet<int> sequence = new HashSet<int>();
            while (true)
            {
                Console.WriteLine("Enter length of sequence:");

                int length = Convert.ToInt32(Console.ReadLine());
                for (int i = 0; i < length; i++)
                {
                    Console.WriteLine("Enter number:");
                    int k = Convert.ToInt32(Console.ReadLine());
                    if (k > length)
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                    else if (sequence.Contains(k))
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                    else
                    {
                        sequence.Add(k);
                    }

                }
                Console.WriteLine("YES");




            }

        }
    }
}
