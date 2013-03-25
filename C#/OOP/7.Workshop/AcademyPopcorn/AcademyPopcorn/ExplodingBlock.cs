using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class ExplodingBlock:Block
    {
        //public new const string CollisionGroupString = "explosionblock";

        public ExplodingBlock(MatrixCoords topLeft)
            : base(topLeft)
        {
            this.body = new char[,] { { 'e' } };
        }

       
       
        public override IEnumerable<GameObject> ProduceObjects()
        {

            if (this.IsDestroyed == true)
            {
                var rangeOfExposion = new List<Explosion>();
                rangeOfExposion.Add(new Explosion(this.TopLeft, new MatrixCoords(1, 0)));
                rangeOfExposion.Add(new Explosion(this.TopLeft, new MatrixCoords(-1, 0)));
                rangeOfExposion.Add(new Explosion(this.TopLeft, new MatrixCoords(0, -1)));
                rangeOfExposion.Add(new Explosion(this.TopLeft, new MatrixCoords(0, 1)));
                
                return rangeOfExposion;
            }

            return base.ProduceObjects();
        }
    }
}
