using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ext_Delegates_Lambda_Linq;
namespace _09.StudentNameSpace
{
    public static class StudentExtensions
    {
        public static void Range1824(this List<Student> students)
        {
            var ageRange1824 =
                from student in students
                where student.Age >= 18 && student.Age <= 24
                select student.FName + " " + student.LName + " " + student.Age;

            IEnumerableExtension.Foreach(ageRange1824);
        }

        public static void OrderStudentsFNameLNameLAMBDA(this List<Student> students)
        {
            var sorted = students.OrderByDescending(st => st.FName).ThenByDescending(st => st.LName).Select(st => st.FName + " " + st.LName);

            IEnumerableExtension.Foreach(sorted);
        }

        public static void OrderStudentsFNameLNameLINQ(this List<Student> students)
        {
            var sorted =
                from student in students
                orderby student.FName descending, student.LName descending
                select student.FName + " " + student.LName;
            IEnumerableExtension.Foreach(sorted);
        }

        public static void FBeforeLName(this List<Student> students)
        {
            var firstBeforeLast =
            from student in students
                where student.FName.CompareTo(student.LName) < 0
                select student.FName + " " + student.LName;

            IEnumerableExtension.Foreach(firstBeforeLast);
        }
        public static void OrderByFName(this List<Student> students)
        {
            var orderedByFirstName =
                from student in students
                orderby student.FName
                select student.FName + " " + student.LName;

            IEnumerableExtension.Foreach(orderedByFirstName);
        }
        public static void SofiaTel(this List<Student> students)
        {
            var sofiaTelStudents =
                from student in students
                where student.Tel.StartsWith("02")
                select student.FName + " " + student.LName + student.Tel;

            IEnumerableExtension.Foreach(sofiaTelStudents);
        }
        public static void AbvMail(this List<Student> students)
        {
            var abvMailStudent =
                from student in students
                where student.Email.Contains("@abv.bg")
                select student.FName + " " + student.LName + " " + student.Email;

            IEnumerableExtension.Foreach(abvMailStudent);
        }
        public static void ExtarctMarks2006(this List<Student> students)
        {
            var marks2006 =
                from student in students
                where student.FN.ToString().EndsWith("06")
                select student.Marks;

            foreach (var marks in marks2006)
            {
                foreach (var mark in marks)
                {
                    Console.Write(mark + " ");
                }
            }
        }
        public static void GroupByGroupNum(this List<Student> students)
        {
            var grouped =
               from student in students
               group student by student.GroupNum into gr
               select new { GroupN = gr.Key, Name = gr.ToList() };
            foreach (var item in grouped)
            {
                Console.Write("gr num: {0}", item.GroupN);
                Console.WriteLine();
                string studentsList = string.Join(", ", item.Name);
                Console.WriteLine(studentsList);
            }
        }
    }
}
