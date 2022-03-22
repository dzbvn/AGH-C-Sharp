using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Test1();
            //Test2();
            //Test3();
            //Test4();
            //Test5();
            //Test6();
            //Test7();
            //Test8();
            Test9();

        }

        static void Test1()
        {
            Task1 task = new Task1();
            task.Year();
        }
        static void Test2()
        {
            Task2 task = new Task2();
            task.Sum();
        }
        static void Test3()
        {
            Task3 task = new Task3();
            task.Check();
        }
        static void Test4()
        {
            Task4 task = new Task4();
            task.LossOfWeight();
        }
        static void Test5()
        {
            Task5 task = new Task5();
            task.Statistics();
        }
        static void Test6()
        {
            Task6 task = new Task6();
            task.Swap();
        }
        static void Test7()
        {
            Task7 task = new Task7();
            task.Start();
        }
        static void Test8()
        {
            Task8 task = new Task8();
            task.Start();
        }
        static void Test9()
        {
            Task9 task = new Task9();
            task.Start();
        }

        
    }
}