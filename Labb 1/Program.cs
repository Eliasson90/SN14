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
            int Betalade; 
            double totalSumma;
            uint subTotal;
            int tillbaka; 
            int resultat;
            double avrundaSumma; 

            while (true)
            {
                try
                {
                    Console.Write("ange Totalsumma      :");
                    totalSumma = double.Parse(Console.ReadLine());
                    break;


                }


                catch
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("Var vänlig ange belopp i form av en siffra!");
                    Console.ResetColor();

                }
            }

            if (totalSumma < 1)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("Totalsumman är för liten. Köpet kunde inte genomföras");
                Console.ResetColor();
                return;
            }




            while (true)
            {
                try
                {
                    Console.Write("Ange erhållet belopp :");
                    Betalade = int.Parse(Console.ReadLine());
                    break;



                }



                catch
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.Write("Var vänlig ange belopp i from av en heltals-siffra!");
                    Console.ResetColor();

                }
            }

            if (totalSumma > Betalade)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("Betalning för liten. Köpet kunde inte genomföras");
                Console.ResetColor();
                return;
            }

            Console.WriteLine("\nKVITTO");
            Console.WriteLine("--------------------------------------------");

            Console.WriteLine("{0,-20} : {1,20:c}", "Total", totalSumma);
            //Avrunda
            subTotal = (uint)Math.Round(totalSumma);
            avrundaSumma = subTotal - totalSumma;
            Console.WriteLine("{0,-20} : {1,20:c}", "Avrundning", avrundaSumma);

            //växel
            tillbaka = Betalade - (int)totalSumma;
            Console.WriteLine("{0,-20} : {1,20:c0}", "Att betala", subTotal);
            Console.WriteLine("{0,-20} : {1,20:c0}", "Kontant", Betalade);
            Console.WriteLine("{0,-20} : {1,20:c0}", "Tillbaka", tillbaka);

            Console.WriteLine("--------------------------------------------");
            // Antal lappar tillbaka
            resultat = tillbaka / 500;

            if (resultat > 0)
            {
                Console.WriteLine("{0,-20} : {1,17}","500-lappar", resultat);
                tillbaka = tillbaka % 500;
            }

            resultat = tillbaka / 100;

            if (resultat > 0)
            {
                Console.WriteLine("{0,-20} : {1,17}","100-lappar", resultat);
                tillbaka = tillbaka % 100;
            }

            resultat = tillbaka / 50;

            if (resultat > 0)
            {
                Console.WriteLine("{0,-20} : {1,17}","50-lappar", resultat);
                tillbaka = tillbaka % 50;
            }

            resultat = tillbaka / 20;

            if (resultat > 0)
            {
                Console.WriteLine("{0,-20} : {1,17}","20-lappar", resultat);
                tillbaka = tillbaka % 20;
            }

            resultat = tillbaka / 5;

            if (resultat > 0)
            {
                Console.WriteLine("{0,-20} : {1,17}","5-kronor", resultat);
                tillbaka = tillbaka % 5;
            }

            resultat = tillbaka / 1;

            if (resultat > 0)
            {
                Console.WriteLine("{0,-20} : {1,17}","1-kronor", resultat);
                tillbaka = tillbaka % 1;
            }

        }
    }
}

