using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_1
{
    class Program
    {
        static void Main(string[] args)
        {
            //skapa variabler
            int betalade;
            double totalSumma;
            uint subTotal;
            int tillbaka;            
            double avrundaSumma;

            do
            {

                totalSumma = LasPositivDouble("ange Totalsumma      : ");
                if (totalSumma < 1)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("Totalsumman är för liten. Köpet kunde inte genomföras");
                    Console.ResetColor();
                    return;
                }

                subTotal = (uint)Math.Round(totalSumma);

                betalade = LasInt("Ange erhållet belopp : ", (int)subTotal);

                avrundaSumma = subTotal - totalSumma;

                tillbaka = betalade - (int)totalSumma;

                Console.WriteLine("\nKVITTO");
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("{0,-20} : {1,20:c}", "Total", totalSumma);
                Console.WriteLine("{0,-20} : {1,20:c}", "Avrundning", avrundaSumma);
                Console.WriteLine("{0,-20} : {1,20:c0}", "Att betala", subTotal);
                Console.WriteLine("{0,-20} : {1,20:c0}", "Kontant", betalade);
                Console.WriteLine("{0,-20} : {1,20:c0}", "Tillbaka", tillbaka);
                Console.WriteLine("--------------------------------------------");

                DelaUppIFaktorer(tillbaka);

                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("\nTryck ESC för att avsluta eller valfri knapp för en ny beräkning.");
                Console.ResetColor();

            }
            while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }

        public static double LasPositivDouble(string titel)
        {
            double tal = 0;
            while (true)
            {
                try
                {
                    Console.Write(titel);
                    tal = double.Parse(Console.ReadLine());

                    if (tal > 0)
                        break;

                    // för litet
                }
                catch
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("Var vänlig ange belopp i form av en siffra!");
                    Console.ResetColor();
                }

            }
            return tal;
        }
        public static int LasInt(string title, int minValue)
        {

            int tal = 0;
            while (true)
            {
                try
                {
                    Console.Write(title);
                    tal = int.Parse(Console.ReadLine());


                    if (tal >= minValue)
                    {
                        break;
                    }

                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("Fel! {0} för litet.", tal);
                    Console.ResetColor();
                }
                catch
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.Write("Var vänlig ange belopp i from av en heltals-siffra!");
                    Console.ResetColor();
                }
            }
            return tal;
        }
        public static void DelaUppIFaktorer(int vaxel)
        {
            int[] typAvPengar = { 500, 100, 50, 20, 5, 1 };
            string[] typ = { "lappar", "lappar", "lappar", "lappar", "kronor", "kronor" };
            int mangdAvPengar;
         
            for (int i = 0; i < typAvPengar.Count(); i++)
            {
                mangdAvPengar = vaxel / typAvPengar[i];
                vaxel = vaxel % typAvPengar[i];

                if (mangdAvPengar > 0)
                {
                    Console.WriteLine("{0,4}-{1}  :  {2}", typAvPengar[i], typ[i], mangdAvPengar);
                }
            }
        }
    }
}


