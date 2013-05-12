using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SchoolSystem;
namespace SchoolTest
{
    [TestClass]
    public class StudentTest
    {
        [TestMethod]
        public void StudentConstructor_NameTest()
        {
            var student = new Student("Pesho",12300);
            Assert.AreEqual("Pesho", student.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StudentConstructor_NameNullValue()
        {

            var student = new Student(null,12300);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void StudentConstructor_NameStringEmptyValue()
        {

            var student = new Student(string.Empty, 12300);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void StudentConstructor_IdOutOfRange()
        {

            var student = new Student("Pesho", 100000);
        }

    }
}
