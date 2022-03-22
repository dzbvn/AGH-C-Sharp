using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Task6
    {
        public void Swap()
        {
            Console.WriteLine("Enter text:");
            string text = Console.ReadLine();

            Console.WriteLine("Where:");
            string where = Console.ReadLine();

            Console.WriteLine("To what:");
            string toWhat = Console.ReadLine();

            text = text.Replace(where, toWhat);
            
            Console.WriteLine(text);
            
            
        }
    }
}
