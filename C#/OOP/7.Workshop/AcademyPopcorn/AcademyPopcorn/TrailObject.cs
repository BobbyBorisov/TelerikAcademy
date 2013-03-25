using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class TrailObject:GameObject
    {
        
        
        public int LifeTime { get; set; }
        //public static int Count = 0;

        public TrailObject(MatrixCoords coords, int lifetime)
            : base(coords, new char[,] { { '+' } })
        {
            this.LifeTime = lifetime;
        }

        public override void Update()
        {
            //Count++;
            this.LifeTime--;
            if (this.LifeTime<=0) 
            {
                this.IsDestroyed=true;
            }
        }
    }
}
