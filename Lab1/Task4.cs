using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Task4
    {
        public async void LossOfWeight()
        {
            List<int> weights = new List<int>();
            while (true)
            {
                Console.WriteLine("Enter number of days:");

                int length = Convert.ToInt32(Console.ReadLine());
                for (int i = 0; i < length; i++)
                {
                    Console.WriteLine("Enter weight:");
                    int k = Convert.ToInt32(Console.ReadLine());
                    if (k > 0)
                    {
                        weights.Add(k);
                    }
                    else
                    {
                        Console.WriteLine("Weight < 0!");
                        i -= 1;
                    }
                }

                int maxLoss = 0;
                int lastWeight = weights[0];
                foreach (int weight in weights)
                {
                    if (weight < lastWeight)
                    {
                        maxLoss += (lastWeight - weight);
                    }
                    else
                    {
                        maxLoss = 0;
                    }
                    lastWeight = weight;

                }
                Console.WriteLine("Max loss: {0}", maxLoss);

            }

        }
    }
}
