namespace Methods
{
    using System;
    
    public class Student
    {
        public Student(string firstName, string lastName, string city, DateTime birthdate) 
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.City = city;
            this.BirthDate = birthdate;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string City { get; set; }

        public DateTime BirthDate { get; set; }

        public int IsOlderThan(Student other)
        {
            var result = DateTime.Compare(this.BirthDate, other.BirthDate);

            return result;
        }
    }
}
