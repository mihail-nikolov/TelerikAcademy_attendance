using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonTypeSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Student pesho = new Student("pesho", "peshov", "geshov", "1234", "sofia na mainata si", "12312412421",
                4, Student.specialityEnum.Arh, Student.universityEnum.UACEG, Student.facultyEnum.AF);
            Console.WriteLine(pesho.GetHashCode());
            Console.WriteLine(pesho.ToString());

            Student gosho = new Student("gosho", "goshov", "geshov", "2352", "plovdiv na mainata si", "123123",
                3, Student.specialityEnum.SSS, Student.universityEnum.UACEG, Student.facultyEnum.SF);

            Console.WriteLine(pesho == null);
            Console.WriteLine(pesho != gosho);
            Console.WriteLine(pesho == pesho);
            Console.WriteLine(pesho.Equals(gosho));

            Student gubi = (Student)pesho.Clone();

            gubi.FName = "gubi";
            Console.WriteLine(gubi.ToString());
            Console.WriteLine(pesho.ToString());
            Console.WriteLine(pesho.CompareTo(gubi));
            Console.WriteLine(pesho.CompareTo(pesho));
        }
    }
}
