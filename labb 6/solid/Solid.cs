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

        public abstract double BaseArea { get; }

        public double Height
        {
            get { return _height; }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException();
                }
                _height = value;
            }

        }
        public double HeightSquared { get { return Height * Height; } }

        public double Radius
        {
            get { return _radius; }

            set
            {
                if(value <= 0)
                {
                    throw new ArgumentException();
                }
                _radius = value;
            }
        }
        public double RadiusSquared { get { return Radius * Radius; } }
        public abstract double SurfaceArea { get; }
        public abstract double Volume { get; }

        protected Solid(double radius, double height)
        {
            Height = height;
            Radius = radius;
        }

        public override string ToString()
        {
            return string.Format("Radie (r) :  {0}\nHöjd (h) :  {1}\nVolym :  {2}\nBasarea :  {3}\nYtarea :  {4}", Radius, Height, Volume, BaseArea, SurfaceArea);
        }
    }
}
