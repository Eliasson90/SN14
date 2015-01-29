using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kylskåp
{
    public class Program
    {
        private const string HorisontalLine = "═";
        static void Main(string[] args)
        {
            Cooler cooler = null;
                       
                //Test 1:
                    ViewTestHeader("TEST 1: \nTest av standardkonstruktorn\n");
                    cooler = new Cooler();
                    Console.WriteLine(cooler.ToString());
                    
            
               // Test 2:
                    ViewTestHeader("TEST 2: \nTest av konstruktor med 2 parametrar, <24,5°C och 4°C>\n");
                    cooler = new Cooler(24.5m, 4);
                    Console.WriteLine(cooler.ToString());
                    

               // Test 3:
                    ViewTestHeader("TEST 3: \nTest av konstruktor med 4 parametrar, <19,5°C, 4°C, True och False>\n");
                    cooler = new Cooler(19.5m, 4, true, false);
                    Console.WriteLine(cooler.ToString());
                    

                //Test 4:                     
                    ViewTestHeader("TEST 4: \nTest av kylning med metoden Tick.\n");
                    cooler = new Cooler(5.3m, 4, true, false);
                    Run(cooler, 10);

               // Test 5:
                    ViewTestHeader("TEST 5: \nTest av avstängt kylskåp med metoden Tick, vara avslaget och med stängd dörr.\n");
                    cooler = new Cooler(5.3m, 4, false, false);
                    Run(cooler, 10);

                //Test 6:
                    ViewTestHeader("TEST 6: \nTest av påslaget kylskåp med metoden Tick, vara på och ha öppen dörr.\n");
                    cooler = new Cooler(10.2m, 4, true, true);
                    Run(cooler, 10);

                //Test 7:
                    ViewTestHeader("TEST 7: \nTest av avslaget kylskåp med metoden Tick, ha öppen dörr.\n");
                    cooler = new Cooler(19.7m, 4, false, true);
                    Run(cooler, 10);

               // Test 8:
                    ViewTestHeader("TEST 8: \nTest av egenskaperna så att undantag kastas då innertemperaturen och måltemperaturen tilldelas ett felaktigt värde.\n");
                    cooler = new Cooler();

                    try
                    {
                        cooler.InsideTemperature = 80;

                        //fel
                    }
                    catch(ArgumentException)
                    {
                        //rätt
                        ViewErrorMessage("Innetemperaturen är inte i intervallet 0°C - 45°C\nInnetemperaturen är inte i intervallet 0°C - 45°C");
                    }
                 

                    try
                    {
                        cooler.TargetTemperature = 80;
                    }
                    catch
                    {
                        ViewErrorMessage("Måltemperaturen är inte i intervallet 0°C - 45°C\nMåltemperaturen är inte i intervallet 0°C - 45°C");
                    }
               // Test 9:
                    ViewTestHeader("TEST 9: \nTest av konstruktor så att undantag kastas då innertemperaturen och måltemperaturen tilldelas ett felaktigt värde.\n");
                
                    try
                    {
                        cooler = new Cooler(80, 80, true, true);

                    }
                    catch
                    {
                        ViewErrorMessage("Innetemperaturen är inte i intervallet 0°C - 45°C\nInnetemperaturen är inte i intervallet 0°C - 45°C");
                    }

                    try
                    {
                        cooler = new Cooler(80, 80, false, false);
                    }
                    catch
                    {
                        ViewErrorMessage("Måltemperaturen är inte i intervallet 0°C - 45°C\nMåltemperaturen är inte i intervallet 0°C - 45°C");
                    }
            
        }

       private  static void Run(Cooler cooler, int minutes)
        {
            Console.WriteLine(cooler.ToString());

            for (int countMinutes = 0; countMinutes < 10; countMinutes++)
            {
                cooler.Tick();
                Console.WriteLine(cooler.ToString());
            }
        }

        static void ViewErrorMessage(string message)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        static void ViewTestHeader(string header)
        {
            for (int i = 0; i < 50; i++)
            {
                Console.Write(HorisontalLine);
            }
            Console.WriteLine();
            Console.WriteLine(header);
        }
    }
}
