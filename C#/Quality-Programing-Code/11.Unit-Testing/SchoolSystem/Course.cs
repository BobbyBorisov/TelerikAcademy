namespace SchoolSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Course
    {
        public const byte MaxStudentCountInCourse = 29;
        
        private string name;

        public Course(string name) 
        {
            this.Name = name;
            this.Students = new List<Student>();
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
                    throw new ArgumentException("Name of student cannot be null or empty");
                }

                this.name = value; 
            }
        }

        public List<Student> Students { get; set; }

        public void AddStudent(Student student)
        {
            bool isStudentFound = this.CheckIfStudentIsFound(student);

            if (isStudentFound) 
            {
                throw new ArgumentException("Student has been added already");
            }

            if (this.Students.Count() + 1 > MaxStudentCountInCourse) 
            {
                throw new ArgumentOutOfRangeException("The course is full. Student cannot be added.");
            }

            this.Students.Add(student);
        }

        public void RemoveStudent(Student student) 
        {
            bool isStudentFound = this.CheckIfStudentIsFound(student);

            if (!isStudentFound) 
            {
                throw new ArgumentException("Cannot find student");
            }

            this.Students.Remove(student);
        }

        /*
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine("Course:" + this.Name);

            foreach (var student in this.Students) 
            {
                sb.AppendLine(student.ToString());
            }

            return sb.ToString();
        }
         * */

        private bool CheckIfStudentIsFound(Student student) 
        {
            var result = this.Students.Find(x => x.Id == student.Id);
            var isFound = false;

            if (result != null)
            {
                isFound = true;
            }

            return isFound;
        }
    }
}
