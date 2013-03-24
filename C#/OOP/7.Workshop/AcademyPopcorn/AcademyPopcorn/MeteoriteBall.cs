using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class MeteoriteBall: Ball
    {
        public new const string CollisionGroupString = "ball";

        public MeteoriteBall(MatrixCoords topLeft, MatrixCoords speed)
            : base(topLeft,speed)
        {
            this.Speed = speed;
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            IList<TrailObject> listOfTrailObjects = new List<TrailObject>();
           
            var trailObject = new TrailObject(this.GetTopLeft(),3);
            listOfTrailObjects.Add(trailObject);

            
            return listOfTrailObjects;
        }

        
    }
}
