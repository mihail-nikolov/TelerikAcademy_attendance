using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Ext_Delegates_Lambda_Linq;
/*Problem 9. Student groups

    Create a class Student with properties FirstName, LastName, FN, Tel, Email, Marks (a List), GroupNumber.
    Create a List<Student> with sample students. Select only the students that are from group number 2.
    Use LINQ query. Order the students by FirstName.
 * Problem 10. Student groups extensions

    Implement the previous using the same query expressed with extension methods.
Problem 11. Extract students by email

    Extract all students that have email in abv.bg.
    Use string methods and LINQ.

Problem 12. Extract students by phone

    Extract all students with phones in Sofia.
    Use LINQ.

Problem 13. Extract students by marks

    Select all students that have at least one mark Excellent (6) into a new anonymous class that has properties – FullName and Marks.
    Use LINQ.

Problem 14. Extract students with two marks

    Write down a similar program that extracts the students with exactly two marks "2".
    Use extension methods.

Problem 15. Extract marks

    Extract all Marks of the students that enrolled in 2006. (The students from 2006 have 06 as their 5-th and 6-th digit in the FN).
Problem 16.* Groups

    Create a class Group with properties GroupNumber and DepartmentName.
    Introduce a property GroupNumber in the Student class.
    Extract all students from "Mathematics" department.
    Use the Join operator.

Problem 17. Longest string

    Write a program to return the string with maximum length from an array of strings.
    Use LINQ.

Problem 18. Grouped by GroupNumber

    Create a program that extracts all students grouped by GroupNumber and then prints them to the console.
    Use LINQ.

Problem 19. Grouped by GroupName extensions

    Rewrite the previous using extension methods.

*/
namespace _09.StudentNameSpace
{
    class Program
    {
        static void Main()
        {
            Student pesho = new Student("Pesho", "Mesho", 114506, "0834856456", "pm@gmail.com", 2, 23);
            pesho.Marks = new List<int> { 2, 2, 5, 6 };
            Student gey = new Student("Gey", "Gejov", 115408, "085656132", "gg@abv.bg", 5, 32);
            gey.Marks = new List<int> { 3, 4, 5, 6 };
            Student gubi = new Student("Gubi", "Tapag", 112412, "08946545221", "tp@yahoo.com", 11, 33);
            gubi.Marks = new List<int> { 5, 4, 5, 6 };
            Student giubre = new Student("Alex", "Jivotinski", 155406, "08946545221", "tp@yahoo.com", 12, 26);
            giubre.Marks = new List<int> { 6,5, 5, 6 };
            Student djingi = new Student("Djingi", "Bijmimadas", 159406, "023256878", "db@yahoo.com", 3, 27);
            giubre.Marks = new List<int> { 6, 6, 5, 6 };

            List<Student> students = new List<Student> { };
            students.Add(pesho);
            students.Add(gey);
            students.Add(gubi);
            students.Add(giubre);
            students.Add(djingi);
            students.ForEach(Student.print);
            Console.WriteLine();
            Console.WriteLine("GROUP 2");

            List<Student> group2 = students.FindAll(s => s.GroupNum == 2);
            group2.ForEach(Student.print);
            Console.WriteLine();
            Console.WriteLine("ORDERED");

            students.OrderByFName();

            Console.WriteLine();
            Console.WriteLine("ABV.BG");

            students.AbvMail();

            Console.WriteLine();
            Console.WriteLine("sofia tel");

            students.SofiaTel();

            Console.WriteLine();
            Console.WriteLine("marks 2006");

            students.ExtarctMarks2006();

            Console.WriteLine();
            Console.WriteLine("grouped by groupNum");

            students.GroupByGroupNum();

            Console.WriteLine();
            Console.WriteLine("First before last name");

            students.FBeforeLName();

            Console.WriteLine();
            Console.WriteLine("range 18 24");

            students.Range1824();

            Console.WriteLine();
            Console.WriteLine("ordered LAMBDA");

            students.OrderStudentsFNameLNameLAMBDA();

            Console.WriteLine();
            Console.WriteLine("ordered LINQ");
            students.OrderStudentsFNameLNameLINQ();

            Console.WriteLine();
            Console.WriteLine("ExtractByExcellentMark");
            students.ExtractByExcellentMark();

            Console.WriteLine();
            Console.WriteLine("ExtractByPoorMarks");
            students.ExtractByPoorMarks();
        }
    }
}
