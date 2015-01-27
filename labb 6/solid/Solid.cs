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
        public double HeightSquared { get { return _height * _height; } }

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
        public double RadiusSquared { get { return _radius * _radius; } }
        public abstract double SurfaceArea { get; }
        public abstract double Volume { get; }

        protected Solid(double radius, double height)
        {
            Height = height;
            Radius = radius;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Radie (r)  :  {0, 10:f2}\n", Radius);
            sb.AppendFormat("Höjd (h)   :  {0, 10:f2}\n", Height);
            sb.AppendFormat("Volym      :  {0, 10:f2}\n", Volume);
            sb.AppendFormat("Basarea    :  {0, 10:f2}\n", BaseArea);
            sb.AppendFormat("Ytarea     :  {0, 10:f2}\n", SurfaceArea);
            return sb.ToString();            
        }
       
    }
}
