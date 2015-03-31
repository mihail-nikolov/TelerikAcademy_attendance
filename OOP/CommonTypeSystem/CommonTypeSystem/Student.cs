using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonTypeSystem
{
    public class Student:ICloneable, IComparable<Student>
    {
        public enum specialityEnum {SSS, Arh, ViK, TS, Hidro, Goedesy, El, CompSciences, SoftEng, Biology}
        public enum universityEnum { UACEG, SU, TU, TS }
        public enum facultyEnum { SF, AF, FMI, TF, HF, GF }

        private string fName;
        private string mName;
        private string lName;
        private string ssn;
        private string permanentAddress;
        private string phone;
        private string email;
        private int course;
        private specialityEnum speciality;
        private universityEnum university;
        private facultyEnum faculty;

        public Student(string fname, string mname, string lname, string ssn, string permAddr,
            string phone, int course, specialityEnum speciality,universityEnum university,facultyEnum faculty)
        {
            this.FName = fname;
            this.MName = mname;
            this.LName = lname;
            this.SSN = ssn;
            this.PermanentAddress = permAddr;
            this.Phone = phone;
            this.Course = course;
            this.Speciality = speciality;
            this.University = university;
            this.Faculty = faculty;
        }
        public string FName
        {
            get { return this.fName; }
            set 
            {
                this.fName = value;
            }
        }
        public string MName
        {
            get { return this.mName; }
            set
            {
                this.mName = value;
            }
        }
        public string LName
        {
            get { return this.lName; }
            set
            {
                this.lName = value;
            }
        }
        public string SSN
        {
            get { return this.ssn; }
            set
            {
                this.ssn = value;
            }
        }
        public string PermanentAddress
        {
            get { return this.permanentAddress; }
            set
            {
                this.permanentAddress = value;
            }
        }
        public string Phone
        {
            get { return this.phone; }
            set
            {
                this.phone = value;
            }
        }
        public string Email
        {
            get { return this.email; }
            set
            {
                if (!value.Contains('@'))
                {
                    throw new ArgumentException("enter valid email");   
                }
                this.email = value;
            }
        }
        public int Course
        {
            get { return this.course; }
            set
            {
                if (value < 0 || value > 8)
                {
                    throw new ArgumentException("courses are between 1 and 8");
                }
                this.course = value;
            }
        }
        public specialityEnum Speciality
        {
            get { return this.speciality; }
            set { this.speciality = value; }
        }
        public universityEnum University
        {
            get { return this.university; }
            set { this.university = value; }
        }
        public facultyEnum Faculty
        {
            get { return this.faculty; }
            set { this.faculty = value; }
        }
        
        public override string ToString()
        {
            string mySt = string.Format("{0} {1} SSN: {2}", this.FName, this.LName, this.SSN);
            return (mySt);
        }
        public override int GetHashCode()
        {
            return (int.Parse(this.SSN)*2 + this.SSN.Length *3 ) ;
        }
        public static bool operator !=(Student st1, Student st2)
        {
            return !(st1.Equals(st2));
        }
        public static bool operator ==(Student st1, Student st2)
        {
            return st1.Equals(st2);
        }
        public override bool Equals(object obj)
        {
            Student st2 = obj as Student;
            if (Object.Equals(st2, null))
            {
                return false;
            }
            if (Object.Equals(this.SSN, st2.SSN))
            {
                return true;
            }
            return false;
        }

        public object Clone()
        {
            return new Student(this.FName, this.MName, this.LName, this.SSN, this.PermanentAddress,
                this.Phone, this.Course, this.Speciality, this.University, this.Faculty);
        }

        public int CompareTo(Student st2)
        {

            int fNameComp = this.FName.CompareTo(st2.FName);
            if (fNameComp != 0)
            {
                return fNameComp;
            }
            int mNameComp = this.MName.CompareTo(st2.MName);
            if (mNameComp != 0)
            {
                return mNameComp;
            }
            int lNameComp = this.LName.CompareTo(st2.LName);
            if (lNameComp != 0)
            {
                return lNameComp;
            }
            int ssnComp = (int.Parse(this.SSN)).CompareTo(int.Parse(st2.SSN));
            return ssnComp;
        }
    }
}
