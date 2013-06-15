using System;
using System.Linq;

namespace _14.Labyrinth
{
    public class Coord
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Coord(int y, int x)
        {
            this.X = x;
            this.Y = y;
        }

        public Coord()
        {

        }
    }
}
