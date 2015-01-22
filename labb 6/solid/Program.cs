using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace solid
{
    class Program
    {
       private static Solid CreateSolid(SolidType solidType)
            {
                switch (solidType)
                {
                    case SolidType.CircularCone:
                        return new CircularCone();
                    case SolidType.Cylinder:
                        return new Cylinder();

                   
                }
            }

        static void Main(string[] args)
        {
           
        }

        private static double ReadDoubleGreaterThanZero(string prompt)
        {

        }

        private static void ViewMenu()
        {
            
        }

        private static void ViewSolidDetail(Solid solid)
        {

        }
    }
}
