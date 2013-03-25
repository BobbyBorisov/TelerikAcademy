using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizerCore
{
    class OutOfRange : ApplicationException
    {
        private DateTime start;

        public DateTime Start
        {
            get
            {
                return this.start;
            }
            set
            {
                this.start = value;
            }
        }
        
        public OutOfRange(DateTime start,string message)
            : base(message)
        {
            this.Start = start;
        }
    }
}