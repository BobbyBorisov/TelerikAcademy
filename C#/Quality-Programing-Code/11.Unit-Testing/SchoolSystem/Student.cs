namespace SchoolSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Student
    {
        private string name;

        private int id;

        public Student(string name, int id) 
        {
            this.Name = name;
            this.Id = id;
        }

        public string Name
        {
            get 
            { 
                return this.name; 
            }

            set 
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Name of student cannot be null");
                }

                if (value == string.Empty) 
                {
                    throw new ArgumentException("Name of student cannot be empty");
                }

                this.name = value;
            }
        }

        public int Id
        {
            get 
            {
                return this.id;
            }

            set 
            {
                if (value <= 10000 || value >= 99999) 
                {
                    throw new ArgumentOutOfRangeException("The id of student " + this.Name + "should be between 10000 and 99999");
                }

                this.id = value;
            }
        }

        /*
        public override string ToString()
        {
            return string.Format("---Id:{0}  Name:{1}",this.Id,this.Name);
        }
        */
    }
}
