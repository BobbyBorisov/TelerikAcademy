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

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == "ball" ;
        }

       
       
        public override IEnumerable<GameObject> ProduceObjects()
        {

            if (this.IsDestroyed == true)
            {
                var trailsOfExposion = new List<TrailObject>();
                var xa = new MatrixCoords(1, 1);
                var xo = new MatrixCoords(-1, -1);
                var newCoords = this.GetTopLeft() - xa;
                var newCoords1 = this.GetTopLeft() - xo;
                var trail = new TrailObject(newCoords, 1);
                var trail1 = new TrailObject(newCoords1, 1);
                trailsOfExposion.Add(trail);
                trailsOfExposion.Add(trail1);
                
                return trailsOfExposion;
            }

            return base.ProduceObjects();
        }
    }
}
