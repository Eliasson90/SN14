using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_2B
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                while(true)
                {

                }

                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                Console.WriteLine("Tryck på valfri tagent för att börja om - ESC avslutar.");
                Console.ResetColor();

            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }

        public byte ReadOddByte()
        {

        }

        public void RenderTriangle(byte cols)
        {

        }
    }
}
