using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace solid
{
    public abstract class Solid 
    {
        private double _height;
        private double _radius;

        public abstract double BaseArea { get;}
        public abstract double Height { get; set; }
        public abstract double HeightSquared { get; }
        public abstract double Radius { get; set; }
        public abstract double RadiusSquared { get; }
        public abstract double SurfaceArea { get; }
        public abstract double Volume { get; }

        protected Solid(double radius, double height)
        {

        }

        public override string ToString()
        {
            return string.Format("");
        }
    }
}
