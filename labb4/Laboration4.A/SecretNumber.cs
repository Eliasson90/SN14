using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboration4.A
{
    public class SecretNumber
    {

        private int _count;
        private int _number;

        public const int MaxNumberOfGuesses = 7;

        public SecretNumber()
        {
            Initialize();
        }

        public void Initialize()
        {
            _count = 0;

            Random numberRandom = new Random();
            _number = numberRandom.Next(1, 101);
        }

        public bool MakeGuess(int number)
        {

            if (number < 1 || number > 100)
            {
                throw new ArgumentOutOfRangeException("Fel! Talet ligger inte i det bestämda intervallet!");
            }

            if (_count >= 7)
            {
                throw new ApplicationException();
            }
            else
            {
                _count++;
            }

            int gissningar = MaxNumberOfGuesses - _count;

            if (number == _number)
            {
                Console.WriteLine("{0} RÄTT GISSAT!! Du klarade det på {1} försök ", number, _count);
                return true;
            }

            else if (number > _number)
            {
                Console.WriteLine("{0} är för högt. Du har {1} Gissningar kvar", number, gissningar);
                
            }
            else 
            {
                Console.WriteLine("{0} är för lågt. Du har {1} Gissningar kvar", number, gissningar);
               
            }
            
             if (MaxNumberOfGuesses == _count)
            {
                Console.WriteLine("Det hemmliga talet är {0}", _number);
               
            }
             return false;
        }

    }


}