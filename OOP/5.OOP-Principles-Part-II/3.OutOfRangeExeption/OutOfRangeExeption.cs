using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutOfRangeExeption
{
    class OutOfRangeExeption<T> : ApplicationException
    {
        
        public T Start {get;set;}
        public T Stop {get;set;}
        

        public OutOfRangeExeption(T start, T stop, string message)
            : base(message)
        {
            this.Start = start;
            this.Stop = stop;
        }
    }
}
