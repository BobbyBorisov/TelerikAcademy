namespace SchoolSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class School
    {
        private string name;

        public School(string name)
        {
            this.Name = name;
            this.Courses = new List<Course>();
        }

        public string Name
        {
            get 
            { 
                return this.name; 
            }

            set 
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name of the school cannot be null or empty");
                }

                this.name = value; 
            }
        }
        
        public List<Course> Courses { get; set; }

        public void AddCourse(Course course) 
        {
            bool courseExists = this.CheckIfCourseExists(course);

            if (courseExists) 
            {
                throw new ArgumentException("Course already exists");
            }

            this.Courses.Add(course);
        }

        public void RemoveCourse(Course course)
        {
            bool courseExists = this.CheckIfCourseExists(course);

            if (!courseExists)
            {
                throw new ArgumentException("Cannot remove non-existent course");
            }

            this.Courses.Remove(course);
        }

        /*
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine("School:" + this.Name);

            foreach (var course in this.Courses)
            {
                sb.AppendLine(course.ToString());
            }

            return sb.ToString();
        }
        */

        private bool CheckIfCourseExists(Course course)
        {
            var result = this.Courses.Find(x => x.Name == course.Name);
            var isFound = false;

            if (result != null)
            {
                isFound = true;
            }

            return isFound;
        }
    }
}
