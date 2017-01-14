using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.StudentNameSpace
{
    public static class StudentAnonymousClas
    {
        public static void ExtractByExcellentMark(this List<Student> students)
        {
            var studentsWithExcellentMark =
                from student in students
                where student.Marks.Contains(6)
                select new
            {
                FullName = student.FName + " " + student.LName,
                Marks = student.Marks
            };
            foreach (var student in studentsWithExcellentMark)
            {
                Console.WriteLine("Full name: {0}", student.FullName);
                Console.WriteLine("Marks: {0}", string.Join(", ", student.Marks));
            }
        }
        public static void ExtractByPoorMarks(this List<Student> students)
        {
            var studentsWithPoorMarks =
            from student in students
            where student.Marks.FindAll(x => x == 2).Count == 2
            select new
            {
                FullName = student.FName + " " + student.LName,
                Marks = student.Marks
            };
            foreach (var student in studentsWithPoorMarks)
            {
                Console.WriteLine("Full name: {0}", student.FullName);
                Console.WriteLine("Marks: {0}", string.Join(", ", student.Marks));
            }
        }
    }
}
