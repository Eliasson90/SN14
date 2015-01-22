using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace solid
{
    public class Cylinder : Solid
    {
        public double BaseArea { get;}
        public double SurfaceArea { get;}
        public double Volume { get;}

       public Cylinder(double radius, double height)
           :base(radius, height)
        {

        }
    }
}
