using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public class Contract{
        public int salary;
        public int overtime;

        public Contract(){
            this.salary = 0;
            this.overtime = 0;
        }
        public Contract(int salary, int overtime){
            this.salary = salary;
            this.overtime = overtime;
        }
        public Contract Internship(){
            Contract c = new Contract();
            c.salary = 1000;
            return c;
        }

        public Contract FullTime(){
            Contract c = new Contract();
            c.salary = 5000;
            c.overtime = 0;
            return c;
        }
        public int Salary(){
            if(this.overtime != 0){
                return this.salary + this.overtime * (this.salary/60);
            }
            return this.salary;
        }
    }

    public class Employee
    {
        public string firstName;
        public string lastName;
        public Contract contract;
        public Employee(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.contract = new Contract().Internship();
        }
        public int Salary(){
            return contract.salary;
        }

        public string ToString(){
            return "First Name: " + firstName + "\nLast Name: " + lastName + "\nSalary: " + Convert.ToString(this.Salary());
        }

    }

    

    class Task8
    {
        public async void Start()
        {
            Employee e1 = new Employee("Jan", "Kowalski");
            Employee e2 = new Employee("Wojciech", "Nowak");
            e2.contract = e2.contract.FullTime();
            Console.WriteLine(e1.ToString());
            Console.WriteLine(e2.ToString());


        }
    }
}