using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kylskåp
{
    public class Program
    {
        static void Main(string[] args)
        {
            Cooler cooler = null;
                       
                //Test 1:
                    ViewTestHeader("TEST 1: Test av standardkonstruktorn\n");
                    cooler = new Cooler();
                    Console.WriteLine(cooler.ToString());
                    

               // Test 2:
                    Console.WriteLine("TEST 2: Test av konstruktor med 2 parametrar, <24,5 och 4>\n");
                    cooler = new Cooler();
                    Console.WriteLine(cooler.ToString());
                    

               // Test 3:
                    Console.WriteLine("TEST 3: Test av konstruktor med 4 parametrar, <19,5, 4, True och False>\n");
                    cooler = new Cooler();
                    Console.WriteLine(cooler.ToString());
                    

                //Test 4:                     
                    

               // Test 5:
                    

                //Test 6:
                    

                //Test 7:
                    

               // Test 8:
                    

               // Test 9:
                    

            
        }

       private  static void Run(Cooler cooler, int minutes)
        {
            //for (int ticks = 0; ticks < minutes; ticks++)
            //{
            //    cooler.Tick();
            //    Console.WriteLine(cooler.ToString());
            //}
        }

        static void ViewErrorMessage(string message)
        {
            //Console.BackgroundColor = ConsoleColor.Red;
            //Console.WriteLine(message);
            //Console.ResetColor();
        }

        static void ViewTestHeader(string header)
        {
            
        }
    }
}
