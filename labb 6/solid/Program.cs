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
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(" ╔═══════════════════════════════════╗ ");
                    Console.WriteLine(" ║              Cone                 ║ ");
                    Console.WriteLine(" ╚═══════════════════════════════════╝ ");
                    Console.ResetColor();
                    Console.WriteLine();
                    break;
                case SolidType.Cylinder:
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(" ╔═══════════════════════════════════╗ ");
                    Console.WriteLine(" ║             Cylinder              ║ ");
                    Console.WriteLine(" ╚═══════════════════════════════════╝ ");
                    Console.ResetColor();
                    Console.WriteLine();
                    break;
            }

            double radius = ReadDoubleGreaterThanZero("Ange radie (r): ");
            double height = ReadDoubleGreaterThanZero("Ange höjd (h) : ");

            switch (solidType)
            {
                case SolidType.CircularCone:
                    return new CircularCone(radius, height);
                case SolidType.Cylinder:
                    return new Cylinder(radius, height);
                default:
                    return null;
            }
        }

        static void Main(string[] args)
        {
            int menyVal = 0;

            do
            {
                ViewMenu();

                try
                {
                    menyVal = int.Parse(Console.ReadLine());
                    if (menyVal < 0 || menyVal > 2)
                    {
                        throw new ArgumentException();
                    }
                   
                }
                catch
                {
                    Console.WriteLine();
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("FEL! Ange ett nummer mellan 0-2.");
                    Console.ResetColor();

                }

                if(menyVal == 1 || menyVal == 2)
                switch (menyVal)
                {
                    case 0:
                        return;

                    case 1:
                        ViewSolidDetail(CreateSolid(SolidType.CircularCone));

                        break;
                    case 2:                    
                        ViewSolidDetail(CreateSolid(SolidType.Cylinder));

                        break;
                }

                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                Console.WriteLine("Tryck på valfri tagent för att börja om - ESC avslutar.");
                Console.ResetColor();

            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
            
        private static double ReadDoubleGreaterThanZero(string prompt)
        {
            double number;

            while (true)
            {
                Console.Write(prompt);
                try
                {
                    number = double.Parse(Console.ReadLine());
                    if (number <= 0)
                    {
                        throw new ArgumentException();
                    }
                    return number;
                }
                catch (Exception)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine();
                    Console.WriteLine("Ange ett flyttal större än 0.");
                    Console.WriteLine();
                    Console.ResetColor();
                }
            }
        }

        private static void ViewMenu()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" ╔═══════════════════════════════════╗ ");
            Console.WriteLine(" ║          Solida volymer           ║ ");
            Console.WriteLine(" ╚═══════════════════════════════════╝ ");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine(" 0. Avsluta.");
            Console.WriteLine(" 1. Cone.");
            Console.WriteLine(" 2. Cylinder.");
            Console.WriteLine("\n ═══════════════════════════════════════════\n");
            Console.Write(" Ange menyval [0-2]: ");
        }

        private static void ViewSolidDetail(Solid solid)
        {
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine(" ╔═══════════════════════════════════╗ ");
            Console.WriteLine(" ║              Detaljer             ║ ");
            Console.WriteLine(" ╚═══════════════════════════════════╝ ");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine(solid.ToString());
            Console.WriteLine("\n ═══════════════════════════════════════════\n");
        }
    }
}
