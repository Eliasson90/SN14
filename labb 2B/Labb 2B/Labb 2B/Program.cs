using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_2B
{
    class Program
    {
        const byte MinBas = 1;
        const byte MaxBas = 79;
        const string Title = "Ange ett udda tal asterisker , max 79 i trianglens bas: ";

        static void Main(string[] args)
        {
            do
            {
                Console.Clear();

                //anropa inläsning av tal

                byte amount = ReadOddByte();

                //anropa DrawTriangle för visning av triangle

                RenderTriangle(amount);

                //Avsluta med esc 

                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                Console.WriteLine("Tryck på valfri tagent för att börja om - ESC avslutar.");
                Console.ResetColor();

            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }

        public static byte ReadOddByte()
        {
            byte number = 0;

            while (true)
            {
                try
                {
                    Console.Write(Title);
                    number = byte.Parse(Console.ReadLine());

                    if (number % 2 == 0 || number < MinBas && number > MaxBas)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine("Fel! det inmartade värdet är inte ett udda tal mellan {0} och {1}!. ", MinBas, MaxBas);
                        Console.ResetColor();
                        continue;
                    }
                    else
                    {
                        return number;
                    }

                }
                catch
                {
                    throw new ArgumentException();
                }
            }

        }

        public static void RenderTriangle(byte cols)
        {
            //rita ut trianglen

            for (int i = 0; i < cols; i += 2)
            {
                for (int j = cols - i; j >= 0; j -= 2)
                {
                    Console.Write(" ");
                }

                for (int k = 0; k <= i; k++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }
    }
}
