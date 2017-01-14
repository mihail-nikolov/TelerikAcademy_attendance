using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _01.Students;

namespace _01.TestStudents
{
    [TestClass]
    public class TestSchool
    {
        [TestMethod]
        public void SchoolNameCorrect()
        {
            School maths = new School("maths");
            Assert.AreEqual("maths", maths.Name,
                            "name NOK!");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SchoolNameEmptyStr()
        {
            School maths = new School("");
        }
        [TestMethod]
        public void AddStudent()
        {
            Student mihail = new Student("Mihail", 10001);
            School maths = new School("maths");
            maths.Add(mihail);
            Assert.AreEqual(mihail.UniqueNumber, maths.StudentsInSchool[0].UniqueNumber,
                            "student not added!");
            Assert.AreEqual(1, maths.StudentsInSchool.Count,
                            "student not added!");

        }
        [TestMethod]
        public void DeleteStudent()
        {
            Student mihail = new Student("Mihail", 10001);
            School maths = new School("maths");
            maths.Add(mihail);
            maths.Remove(mihail);
            Assert.AreEqual(0, maths.StudentsInSchool.Count,
                            "student not removed!");
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddStudentWhichAlreadyInCourse()
        {
            Student mihail = new Student("Mihail", 10001);
            School maths = new School("maths");
            maths.Add(mihail);
            maths.Add(mihail);
        }
        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void DeleteStudentWhichNotExists()
        {
            Student mihail = new Student("Mihail", 10001);
            School maths = new School("maths");
            maths.Remove(mihail);
        }

    }
}
