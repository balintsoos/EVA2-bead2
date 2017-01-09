using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zh.Model
{
    public class Coordinate
    {
        private int x;
        private int y;

        public Coordinate(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public Coordinate(Coordinate c)
        {
            this.x = c.X;
            this.y = c.Y;
        }

        public int X
        {
            get { return x; }
            set { x = value; }
        }

        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Coordinate c = obj as Coordinate;
            if ((System.Object)c == null)
            {
                return false;
            }

            return (c.X == this.x) && (c.Y == this.Y);
        }

        public override int GetHashCode()
        {
            return x * 1000 + y * 152;
        }

    }
}
