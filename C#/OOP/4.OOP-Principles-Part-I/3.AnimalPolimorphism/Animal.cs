using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_Task
{
    public abstract class Animal : ISound
    {
        public abstract void Sound();
        public string Name { get;  set; }
        public virtual Sex Sex { get; set; }
        public int Age { get;  set; }

       
        

    }
}
