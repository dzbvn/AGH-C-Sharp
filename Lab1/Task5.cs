using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Task5
    {
        public void Statistics()
        {
            Console.WriteLine("Enter text");
            string text = Console.ReadLine();

            Dictionary<char, int> statistics = new Dictionary<char, int>();

            foreach (char c in text)
            {
                if (!statistics.ContainsKey(c))
                {
                    statistics.Add(c, 1);
                }
                else
                {
                    statistics[c] += 1;
                }
            }
            foreach (KeyValuePair<char, int> kvp in statistics)
            {
                Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
            }
            System.Threading.Thread.Sleep(3000);
        }
    }
}