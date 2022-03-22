using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public class Student
    {
        public string course;
        public int year;
        Dictionary<string, double> results = new Dictionary<string, double>();

        public Student(string course, int year)
        {
            this.course = course;
            this.year = year;
        }

        public void addExamResult(string testName, double score)
        {
            results.Add(testName, score);
        }


    }

    class Task7
    {
        public async void Start()
        {
            List<Student> listOfStudents = new List<Student>();
            while (true)
            {
                Console.WriteLine("\tMENU\nAdd student [a]\nList of students [l]");
                char c = Console.ReadKey().KeyChar;
                switch (c)
                {
                    case 'a':
                        {
                            Console.Clear();
                            Console.WriteLine("Add student");
                            Console.WriteLine("Course name:");
                            string course = Console.ReadLine();
                            Console.WriteLine("Year of study:");
                            int year = Convert.ToInt32(Console.ReadLine());
                            listOfStudents.Add(new Student(course, year));
                            Console.WriteLine("Amount of exams:");
                            int iloscEgzaminow = Convert.ToInt32(Console.ReadLine());
                            for (int i = 0; i < iloscEgzaminow; i++)
                            {
                                Console.WriteLine("Name of subject:");
                                string testName = Console.ReadLine();
                                Console.WriteLine("Score:");
                                double score = Convert.ToDouble(Console.ReadLine());
                                listOfStudents.Last().addExamResult(testName, score);

                            }
                            break;
                        }
                    case 'l':
                        {
                            Console.Clear();
                            Console.WriteLine("List of students");
                            int i = 1;
                            foreach(Student s in listOfStudents){
                                Console.WriteLine("Student no. {0}\nCourse name: {1}\nYear of study: {2}\n", i, s.course, s.year);
                            }
                            break;
                        }

                }
            }

        }
    }
}