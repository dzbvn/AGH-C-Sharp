using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public abstract class Mammal
    {
        public int weight;
        public double water;

        public int CheckWeight() => this.weight;

        public double DrinkWater() => this.water;

        public abstract int EatHay();

    }

    public class Cow : Mammal
    {
        int hay;
        public Cow(int weight){
            this.weight = weight;
            this.water = 3;
            this.hay = 80;
        }
        public override int EatHay() => this.hay;
    }

    public class Kitten : Mammal
    {
        public Kitten(int weight){
            this.weight = weight;
            this.water = 0.5;
        }
        void EatEverythingExceptHay(){}
        public override int EatHay() => 0;

    }

    public class Sheep : Mammal
    {
        int hay;
        public Sheep(int weight){
            this.weight = weight;
            this.water = 2;
            this.hay = 40;
        }
        public override int EatHay() => this.hay;
    }



    class Task9
    {
        public async void Start()
        {
            List<Mammal> ListOfAnimals = new List<Mammal>();
            ListOfAnimals.Add(new Cow(400));
            ListOfAnimals.Add(new Cow(450));
            ListOfAnimals.Add(new Sheep(100));
            ListOfAnimals.Add(new Sheep(80));
            ListOfAnimals.Add(new Kitten(1));

            double drunkWater = 0;
            foreach(Mammal animal in ListOfAnimals){
                drunkWater += animal.DrinkWater();
            }

            int eatenHay = 0;
            foreach(var animal in ListOfAnimals){
                eatenHay += animal.EatHay();
            }

            int minWeight = int.MaxValue;
            foreach(var animal in ListOfAnimals){
                if (animal.CheckWeight() < minWeight){
                    minWeight = animal.CheckWeight();
                } 
            }

            Console.WriteLine("Drunk Water: {0}\nEaten Hay: {1}\nMin Weight: {2}", drunkWater, eatenHay, minWeight);

        }
    }
}