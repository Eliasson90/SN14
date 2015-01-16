using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labb2
{
    class Program
    {
        static void Main(string[] args)
        {
            //rader
            for (int row = 0; row < 25; row++)
            {
                if (row % 2 == 1)
                {
                    Console.Write(" ");
                }

                //byta färger
                switch (row % 3)
                {
                    case 0:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        break;

                    case 1:
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        break;

                    case 2:
                        Console.ForegroundColor = ConsoleColor.Green;
                        break;
                }

                // kolumner
                for (int col = 0; col < 39; col++)
                {
                    Console.Write("* ");
                }
                //reseta färgen
                Console.ResetColor();
                //skriv ut press to continue
                Console.WriteLine();
            }
        }

    }
}

