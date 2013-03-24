using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class Gift:MovingObject
    {
        public Gift(MatrixCoords topLeft, MatrixCoords speed)
            : base(topLeft,new char[,] { { '$' } },speed) { }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == "racket";
        }

        protected override void UpdatePosition()
        {
            this.topLeft -= this.Speed;
        }
    }
}
