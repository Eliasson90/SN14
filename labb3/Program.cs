using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labb3
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                int numberOfSalaries = ReadInt("Ange antal löner att mata in: ");

                if (numberOfSalaries < 2)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n Du måste mata in minst två löner för att kunna göra en beräkning!\n");
                    Console.ResetColor();
                }
                else
                {
                    ProcessSalaries(numberOfSalaries);
                }
                //texten i slutet
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("\n Tryck på valfri tangent för ny uträkning. ESC avslutar. \n");
                Console.ResetColor();
            }
            while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
        static int ReadInt(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                try
                {
                    int amount = int.Parse(input);
                    return amount;
                }
                catch (FormatException)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("FEL! {0} kan inte tolkas som ett heltal!", input);
                    Console.WriteLine();
                    Console.ResetColor();
                }
            }
        }
        //uträkningarna
        static void ProcessSalaries(int count)
        {
            //Variabler
            int[] salaries = new int[count];
            int[] sortedSalaries = new int[count];
            double averageSalary;
            int spreadSalary;
            double medianSalary;
            int middle;

            for (int i = 0; i < salaries.Length; i++)
            {
                salaries[i] = ReadInt(string.Format("Ange lön nummer {0}: ", i + 1));
            }
            //medelvärde
            averageSalary = Convert.ToDouble(salaries.Sum()) / salaries.Length;
            //spridning
            spreadSalary = salaries.Max() - salaries.Min();
            //sortera ordning
            sortedSalaries = (int[])salaries.Clone();
            Array.Sort(sortedSalaries);
            //Median
            middle = sortedSalaries.Length / 2;

            if ((sortedSalaries.Length % 2) != 0)
            {
                medianSalary = sortedSalaries[sortedSalaries.Length / 2];
            }
            else
            {
                medianSalary = (sortedSalaries[middle] + sortedSalaries[middle - 1]) / 2d;
            }

            Console.WriteLine();
            //skriv ut Data
            Console.WriteLine("------------------------------");
            Console.WriteLine("Medianlön: {0, 19:c0}", medianSalary);
            Console.WriteLine("Medellön: {0, 20:c0}", averageSalary);
            Console.WriteLine("Lönespridning: {0, 15:c0}", spreadSalary);
            Console.WriteLine("----------------------------------");

            //ordninarie löner
            for (int i = 0; i < salaries.Length; i++)
            {
                Console.Write("{0, 8}", salaries[i]);

                if ((i + 1) % 3 == 0)
                {
                    Console.WriteLine();
                }
                if (i == salaries.Length - 1)
                {
                    Console.WriteLine();
                }
            }
        }


    }
}
