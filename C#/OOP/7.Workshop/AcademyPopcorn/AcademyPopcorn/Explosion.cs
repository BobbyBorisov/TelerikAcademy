using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class Explosion:MovingObject
    {
        public int LifeTime = 0;

        public Explosion(MatrixCoords topLeft, MatrixCoords speed)
            :base(topLeft, new char[,] { { '!' } }, speed)  { }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == "block";
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            this.IsDestroyed = true;
        }

        public override void Update()
        {
            //Count++;
            //this.LifeTime--;
            base.Update();
            if (this.LifeTime == 0)
            {
                this.IsDestroyed = true;
            }
        }
    }
}
