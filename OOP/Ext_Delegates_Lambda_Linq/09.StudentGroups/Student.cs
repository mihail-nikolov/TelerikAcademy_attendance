using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.StudentNameSpace
{
    public class Student
    {
        private string fName;
        private string lName;
        private int fN;
        private string tel;
        private string email;
        private List<int> marks;
        private int groupNum;
        private int age;

        public string FName 
        {
            get { return this.fName; }
            private  set { this.fName = value; }
        }
        public string LName
        {
            get { return this.lName; }
            private set { this.lName = value; }
        }
        public int FN
        {
            get { return this.fN; }
            set { this.fN = value; }
        }
        public string Tel
        {
            get { return this.tel; }
            set { this.tel = value; }
        }
        public string Email
        {
            get { return this.email; }
            set { this.email = value; }
        }
        public List<int> Marks
        {
            get { return this.marks; }
            set { this.marks = value; }
        }
        public int GroupNum
        {
            get { return this.groupNum; }
            set { this.groupNum = value; }
        }
        public int Age
        {
            get { return this.age; }
            set { this.age = value; }
        }
        public Student(string fname, string lname, int fN, string tel, string email, int groupNum, int age)
        {
            this.FName = fname;
            this.LName = lname;
            this.FN = fN;
            this.Tel = tel;
            this.Email = email;
            this.Marks = new List<int> { };
            this.GroupNum = groupNum;
            this.Age = age;
        }
        public override string ToString()
        {
            string str = string.Format("{0} {1}, FN: {2}, tel: {3}, mail: {4} group: {5}, age: {6}",
                this.FName, this.LName, this.FN, this.Tel, this.Email, this.GroupNum, this.Age);
            return str;
        }

        public static Action<Student> print = (student) =>
        {
            Console.WriteLine(student);
            Console.Write("marsk:");
            student.Marks.ForEach(mark => Console.Write(mark + " "));
            Console.WriteLine();
            Console.Write("===============================================================");
            Console.WriteLine();
        };
        
    }
}
