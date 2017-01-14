using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Problem 1. School classes

    We are given a school. In the school there are classes of students. Each class has a set of teachers. Each teacher teaches a set of disciplines. Students have name and unique class number. Classes have unique text identifier. Teachers have name. Disciplines have name, number of lectures and number of exercises. Both teachers and students are people. Students, classes, teachers and disciplines could have optional comments (free text block).
    Your task is to identify the classes (in terms of OOP) and their attributes and operations, encapsulate their fields, define the class hierarchy and create a class diagram with Visual Studio.
*/
namespace _01.SchoolClasses
{
    class Program
    {
        static void Main(string[] args)
        {
            Discipline maths = new Discipline("maths", 4, 4);

            Teacher theHammer = new Teacher("hamara");
            Teacher betona = new Teacher("pesho");
            theHammer.Disciplines.Add(maths);
            betona.Disciplines.Add(maths);

            Student helena = new Student("elena", 23);
            Student mihail = new Student("mihail", 21);

            SchoolClass bClass = new SchoolClass("b");
            bClass.Students.Add(mihail);
            bClass.Students.Add(helena);
            bClass.Teachers.Add(theHammer);
            bClass.Teachers.Add(betona);

            School pmg = new School("pmg");
            pmg.SchoolClass.Add(bClass);

            Console.WriteLine(pmg.Name);

            Console.WriteLine(pmg.SchoolClass[0].ID);
            foreach (var student in pmg.SchoolClass[0].Students)
            {
                Console.WriteLine("name: {0} number: {1}",student.Name, student.Number);
            }
            foreach (var teacher in pmg.SchoolClass[0].Teachers)
            {
                Console.WriteLine("name: {0} disc: {1}", teacher.Name, teacher.Disciplines[0].Name);
            }
        }
    }
}
