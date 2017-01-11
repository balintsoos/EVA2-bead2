using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zh.Model
{
    public class Field
    {
        Coordinate coords;
        private int color;
        private Boolean visible;

        public Field(int x, int y, int color)
        {
            this.coords = new Coordinate(x, y);
            this.color = color;
            visible = false;
        }
        public Field(Field f)
        {
            new Field(f.Coords.X, f.Coords.Y, f.Color);
        }

        public Boolean Visible
        {
            get { return visible; }
            set { visible = value; }
        }

        public Coordinate Coords
        {
            get { return coords; }
            set { coords = value; }
        }

        public int X
        {
            get { return coords.X; }
        }

        public int Y
        {
            get { return coords.Y; }
        }
        public int Color
        {
            get { return color; }
        }

        public override string ToString()
        {
            return "Field: " + color.ToString() + " on X: " + X.ToString() + ", " + Y.ToString() + ". ";
        }
    }
}
