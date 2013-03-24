using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Student_Task
{
    class Student: ICloneable,IComparable<Student>
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        public uint Ssn { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }
        public int Course{ get; set; }
        public Specialty Specialty { get; set; }
        public University University { get; set; }
        public Faculty Faculty { get; set; }

        //Constructor with less properties to fill
        public Student(string firstName, string lastName, uint ssn)
            : this(firstName,null, lastName, ssn,null,null,1,Specialty.NetNinja,University.Telerik,Faculty.Software) { }

        public Student(string firstName, string middleName, string lastName, uint ssn, string address, string mobile, int course, Specialty specialty, University university, Faculty faculty)
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.Ssn = ssn;
            this.Address = address;
            this.Mobile = mobile;
            this.Course = course;
            this.Specialty = specialty;
            this.University = university;
            this.Faculty = faculty;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Information about " + this.FirstName + " " + this.MiddleName + " " + this.LastName);
            sb.AppendLine("Social security number: " + this.Ssn);
            sb.AppendLine("Address: " + this.Address);
            sb.AppendLine("Mobile: " + this.Mobile);
            sb.AppendLine("Course: " + this.Course);
            sb.AppendLine("Specialty: " + this.Specialty);
            sb.AppendLine("University: " + this.University);
            sb.AppendLine("Faculty: " + this.Faculty);

            return sb.ToString();
        }

        public override bool Equals(object obj)
        {
            Student student = obj as Student;

            if (student == null)
                return false;

            if (!Object.Equals(this.Ssn, student.Ssn))
                return false;

            return true;
        }

        public static bool operator ==(Student student1, Student student2)
        {
            return Student.Equals(student1, student2);
        }

        public static bool operator !=(Student student1, Student student2)
        {
            return !(Student.Equals(student1, student2));
        }

        public override int GetHashCode()
        {
            unchecked 
            {
                int hash = 17;
                hash = hash * 23 + this.Ssn.GetHashCode();

                return hash;
            }
        }

        public object Clone()
        {
            //doing shadow clone
            return this.MemberwiseClone();
        }

        public int CompareTo(Student other)
        {
            if (this == other) 
            {
                return 0;
            }
            //First check names lexically
            if (String.Compare(this.FirstName,other.FirstName) < 0) 
            {
                return 1;
            }
            else if (String.Compare(this.FirstName, other.FirstName) > 0)
            {
                return -1;
            }
            else 
            {
                //if names are equal, then compare social securities
                return this.Ssn.CompareTo(other.Ssn);
                    
            }
        }

    }

    
}
