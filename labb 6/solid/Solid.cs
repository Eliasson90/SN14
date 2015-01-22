using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace solid
{
    public abstract class Solid 
    {
        double _height;
        double _radius;

        public abstract double BaseArea { get;}
        public double Height { get; set; }
        public double HeightSquared { get;}
        public double Radius { get; set; }
        public double RadiusSquared { get;}
        public double SurfaceArea { get;}
        public double Volume { get;}

        protected Solid(double radius, double height)
        {

        }

        public override string ToString()
        {
            return string.Format("");
        }
    }
}
