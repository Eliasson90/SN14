
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Labb_7_SecreatNumber.Models
{
    public enum Outcome
    {
        Undefined,
        Low,
        High,
        Right,
        NoMoreGuesses,
        OldGuess
    }

    public struct GuessedNumber
    {
        public int? Number;
        public Outcome Outcome;
    }

    public class SecretNumber
    {

        private int? _number;
        private List<GuessedNumber> _guessedNumbers;
        private GuessedNumber _lastGuessedNumber;
        public const int MaxNumberOfGuesses = 7;
        
       

        public bool CanMakeGuess
        {
            get
            {
                return Count < MaxNumberOfGuesses;

            }

        }

        public int Count
        {
            get
            {
                return _guessedNumbers.Count;
            }
           

        }

        public IList<GuessedNumber> GuessedNumbers
        {
            get
            {
                return _guessedNumbers.AsReadOnly();
            }
        }

        public GuessedNumber LastGuessedNumber
        {
            get
            {
                return _lastGuessedNumber;

            }

        }

        public int? Number
        {
            get
            {
                if (CanMakeGuess)
                {
                    return null;
                }
                else
                {
                    return _number;
                }
            }

            private set { _number = value; }

        }


        public void Initialize()
        {
            _guessedNumbers.Clear();
            _lastGuessedNumber.Outcome = Outcome.Undefined;

            Random numberRandom = new Random();
            _number = numberRandom.Next(1, 101);


        }

        public Outcome MakeGuess(int guess)
        {

            _lastGuessedNumber.Number = guess;


            if (guess == _number)
            {
                _lastGuessedNumber.Outcome = Outcome.Right;
            }

            else if (guess > _number)
            {
                _lastGuessedNumber.Outcome = Outcome.High;

            }
            else
            {
                _lastGuessedNumber.Outcome = Outcome.Low;
            }

            if (guess < 1 || guess > 100)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (_guessedNumbers.Any(n => n.Number == guess))
            {
                _lastGuessedNumber.Outcome = Outcome.OldGuess;
            }
            _guessedNumbers.Add(_lastGuessedNumber);

            return _lastGuessedNumber.Outcome;

        }

        public SecretNumber()
        {
            _guessedNumbers = new List<GuessedNumber>();
            Initialize();
        }

        public string GuessText
        {
            
            get
            {
                string _guessNr = "";
                     switch (Count)
                    {

                        case 1:
                            _guessNr = "Första gissningen";
                            break;
                        case 2:
                            _guessNr = "Andra gissningen";
                            break;
                        case 3:
                            _guessNr = "Tredje gissningen";
                            break;
                        case 4:
                            _guessNr = "Fjärde gissningen";
                            break;
                        case 5:
                            _guessNr = "Femte gissningen";
                            break;
                        case 6:
                            _guessNr = "Sjätte gissningen";
                            break;
                        case 7:
                            _guessNr = "Sjunde gissningen";
                            break;
                    }

                     
                     return String.Format("{0}", _guessNr);
            }
           
            
        }

        public string GetMessage(Outcome outcome)
        {
            string message = "";

            switch (outcome)
            {
                case Outcome.Right:
                    return String.Format("Grattis, du klarade det på {0} försöket!", GuessText);
                case Outcome.OldGuess:
                    return String.Format("Du har redan gissat på {0}, välj ett annat tal.", LastGuessedNumber.Number);
                case Outcome.High:
                    message = String.Format("{0} är för lågt.", LastGuessedNumber.Number);
                    break;
                case Outcome.Low:
                    message = String.Format("{0} är för lågt.", LastGuessedNumber.Number);
                    break;
            }
            if (!CanMakeGuess)
            {
                message = String.Format("{0} Inga fler gissningar, det hemliga talet var {1}", message, Number);
            }

            return message;
        }

    }
}