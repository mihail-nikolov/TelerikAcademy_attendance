using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Problem 2. Students and workers

    Define abstract class Human with first name and last name. Define new class Student which is derived from Human and has new field – grade. Define class Worker derived from Human with new property WeekSalary and WorkHoursPerDay and method MoneyPerHour() that returns money earned by hour by the worker. Define the proper constructors and properties for this hierarchy.
    Initialize a list of 10 students and sort them by grade in ascending order (use LINQ or OrderBy() extension method).
    Initialize a list of 10 workers and sort them by money per hour in descending order.
    Merge the lists and sort them by first name and last name.
*/
namespace _02.StudentsWorkers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student> { };
            students.Add(new Student("mihail", "nikolov", 6));
            students.Add(new Student("pesho", "nikolov", 3.45));
            students.Add(new Student("gosho", "nikolov", 5.52));
            students.Add(new Student("mihail", "petrov", 5.32));
            students.Add(new Student("ivan", "nikolov", 4.9));
            students.Add(new Student("mihail", "ivanov", 4.8));
            students.Add(new Student("mihail", "asenov", 4.4));
            students.Add(new Student("gubi", "nikolov", 4.3));
            students.Add(new Student("mihail", "tapag", 4));
            students.Add(new Student("spinderman", "nikolov", 3));

            var students1= students.OrderBy(st => st.Grade);
            foreach (var st in students1)
            {
                Console.WriteLine(st.FName + " " + st.LName + " " + st.Grade);
            }

            List<Worker> workers = new List<Worker> { };
            workers.Add(new Worker("mihail", "nikolov", 300, 8));
            workers.Add(new Worker("pesho", "nikolov", 321, 8));
            workers.Add(new Worker("gosho", "nikolov", 333, 8));
            workers.Add(new Worker("mihail", "petrov", 411, 8));
            workers.Add(new Worker("ivan", "nikolov", 322, 8));
            workers.Add(new Worker("mihail", "ivanov", 333, 8));
            workers.Add(new Worker("mihail", "asenov", 343, 8));
            workers.Add(new Worker("gubi", "nikolov", 355, 8));
            workers.Add(new Worker("mihail", "tapag", 368, 8));
            workers.Add(new Worker("spinderman", "nikolov", 312, 8));
            Console.WriteLine("=============================");
            var workers1 = workers.OrderByDescending(w => w.MoneyPerHour());
            foreach (var w in workers1)
            {
                Console.WriteLine(w.FName + " " + w.LName + " " + w.MoneyPerHour());
            }
            List<Human> humans = new List<Human> { };
            
            for (int i = 0; i < 9; i++)
            {
                humans.Add(workers[i]);
            }
            for (int i = 0; i < 9; i++)
            {
                humans.Add(students[i]);
            }
            Console.WriteLine("=============================");
            var humans1 = humans.OrderBy(h => h.FName);
            foreach (var item in humans1)
            {
                Console.WriteLine(item.FName + " " + item.LName);
            }
            Console.WriteLine("=============================");
            var humans2 = humans.OrderBy(h => h.LName);
            foreach (var item in humans2)
            {
                Console.WriteLine(item.FName +" " +  item.LName);
            }
        }
    }
}
