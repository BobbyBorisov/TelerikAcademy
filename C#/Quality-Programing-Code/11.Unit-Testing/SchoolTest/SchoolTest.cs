using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SchoolSystem;
namespace SchoolTest
{
    [TestClass]
    public class SchoolTest
    {
        [TestMethod]
        public void SchoolConstructorTestName()
        {
            string schoolName = "TUES";
            var school = new School("TUES");
            Assert.AreEqual(schoolName, school.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SchoolConstructorTestNameNullValue()
        {
            
            var school = new School(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SchoolTestRemoveNonExistingCourse()
        {
            var firstCourse = new Course("Javascript");
            var secondCourse = new Course("Csharp");
            var school = new School("TUES");

            school.AddCourse(firstCourse);
            school.RemoveCourse(secondCourse);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SchoolTestAddCourseSecondTime()
        {
            var course = new Course("Javascript");
            var school = new School("Boby Georgiev");
            school.AddCourse(course);
            school.AddCourse(course);
        }

        [TestMethod]
        public void SchoolTestRemoveExistentStudent()
        {
            var course = new Course("Javascript");
            var school = new School("TUES");

            school.AddCourse(course);
            school.RemoveCourse(course);
        }

        
    }
}
