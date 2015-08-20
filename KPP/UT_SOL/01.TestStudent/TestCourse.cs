using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _01.Students;

namespace _01.TestStudents
{
    
    
    [TestClass]
    public class CourseTest
    {
        [TestMethod]
        public void SchoolNameCorrect()
        {
            Course maths = new Course("maths");
            Assert.AreEqual("maths", maths.Name,
                            "name NOK!");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SchoolNameEmptyStr()
        {
            Course maths = new Course("");
        }
        [TestMethod]
        public void AddStudent()
        {
            Student mihail = new Student("Mihail", 10001);
            Course maths = new Course("maths");
            maths.Add(mihail);
            Assert.AreEqual(maths.StudentsInCourse[0].UniqueNumber, mihail.UniqueNumber,
                            "student not added!");
            Assert.AreEqual(maths.StudentsInCourse.Count,1,
                            "student not added!");

        }
        [TestMethod]
        public void DeleteStudent()
        {
            Student mihail = new Student("Mihail", 10001);
            Course maths = new Course("maths");
            maths.Add(mihail);
            maths.Remove(mihail);
            Assert.AreEqual(maths.StudentsInCourse.Count, 0,
                            "student not removed!");
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddStudentWhichAlreadyInCourse()
        {
            Student mihail = new Student("Mihail", 10001);
            Course maths = new Course("maths");
            maths.Add(mihail);
            maths.Add(mihail);

        }
        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void DeleteStudentWhichNotExists()
        {
            Student mihail = new Student("Mihail", 10001);
            Course maths = new Course("maths");
            maths.Remove(mihail);
        }
        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void AddMoreThan30Students()
        {
            Course maths = new Course("maths");
            for (int i = 0; i < 31; i++)
            {
                string Name = "mihail" + i.ToString();
                int ID = i + 10000;
                Student mihail = new Student(Name, ID);
                maths.Add(mihail);

            }
        }
    }
}
