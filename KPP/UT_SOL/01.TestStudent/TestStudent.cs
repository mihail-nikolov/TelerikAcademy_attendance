using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _01.Students;

namespace _01.TestStudents
{
   
    [TestClass]
    public class StudentTest
    {
        [TestMethod]
        public void StudentNameCorrect()
        {
            Student mihail = new Student("Mihail", 10001);
            Assert.AreEqual("Mihail" ,mihail.Name,
                            "names not the same!");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void StudentNameEmptyString()
        {
            Student mihail = new Student("", 10001);
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void StudentBiggerID()
        {
            Student mihail = new Student("asda", 100000);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void StudentSmallerID()
        {
            Student mihail = new Student("asda", 9999);
        }
        [TestMethod]
        public void StudentUniqueNum()
        {
            Student mihail1 = new Student("Mihail", 10001);
            Assert.AreEqual(mihail1.UniqueNumber, 10001,
                            "un Number wroong!");
        }
    }
}
