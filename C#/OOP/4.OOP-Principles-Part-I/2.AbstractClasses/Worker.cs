using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Task
{
    class Worker: Human
    {
        public float WeekSalary { get; set; }
        public float WorkHoursPerDay { get; set; }

        public Worker(string firstName, string lastName,float week_salary, float hours_per_day) {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.WeekSalary = week_salary;
            this.WorkHoursPerDay = hours_per_day;
        }

        public float MoneyPerHour() { 
            return WeekSalary/WorkHoursPerDay;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(FirstName + " " + LastName + " " + WeekSalary + " "+WorkHoursPerDay);
            return sb.ToString();
        }
    }
}
