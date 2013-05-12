using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SchoolSystem;
namespace SchoolTest
{
    [TestClass]
    public class CoursesTest
    {
        [TestMethod]
        public void CourseConstructorTestName()
        {
            string courseName = "Javascript";
            var course = new Course("Javascript");
            Assert.AreEqual(courseName, course.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CourseConstructorTestNameNullValue()
        {
            var course = new Course(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CourseTestRemove()
        {
            var student = new Student("Ivan Ivanov", 12300);
            var student1 = new Student("Petkan Ivanov", 12100);
            var course = new Course("Csharp");
            course.AddStudent(student);
            course.RemoveStudent(student1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CourseTestAdd()
        {
            var student = new Student("Gosho Goshov", 12300);
            var course = new Course("Csharp");
            course.AddStudent(student);
            course.AddStudent(student);
        }

        [TestMethod]
        public void CourseTestRemoveExistentStudent()
        {
            var student = new Student("Ivan Ivanov", 12300);
            var course = new Course("CMS");

            course.AddStudent(student);
            course.RemoveStudent(student);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CourseTestAddStudentToFullList()
        {
            var course = new Course("Javascript APIs");
            
            for (var i = 1; i < 31; i++) 
            {
                course.AddStudent(new Student("Test Student", i + 10000));
            }
        }
    }
}
