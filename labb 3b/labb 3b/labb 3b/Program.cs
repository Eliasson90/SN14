using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labb_3b
{
    class Program
    {
        static void Main(string[] args)
        {

            do
            {
                Console.Clear();

                string titleNumberOfSalaries = "Ange antalet löner att mata in: ";
                int numberOfSalaries = 0;

                //Array
                int[] arrayOfSalaries = ReadInt(numberOfSalaries);
                Console.WriteLine();

                //kolla så att minst 2 löner matas in 
                if (numberOfSalaries >= 2)
                {
                    arrayOfSalaries = ReadSalaries(numberOfSalaries);
                    ViewResult(arrayOfSalaries);
                }
                else
                {
                    string messageMoreSalaries = "Du måste mata in minst 2 löner för att kunna beräkna: ";
                    ViewMessage(messageMoreSalaries, true);
                }

            } while (IsCounting());
        }

        private static int ReadInt(string prompt)
        {

        }

        private static int[] ReadSalaries(int count)
        {

        }

        private static void ViewResult(int[] salaries)
        {

        }

        private static int GetDisperation(int[] source)
        {

        }

        private static int GetMedian(int[] source)
        {

        }

        private static void ViewMessage(string message, bool isError)
        {
            if(isError == false)
            {
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.WriteLine(message);
                Console.ResetColor();
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine(message);
                Console.ResetColor();
            }
        }

        private static bool IsCounting()
        {
            string messageChoise = "/nTryck på en tangent för ny beräkning - ESC för att avsluta. ";

            ViewMessage(messageChoise, false);
                return false;
        }
        return true;
    }
}
