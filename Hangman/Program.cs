using System;

namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the hangman game. Please press 'Enter'  to start.");

            while (Console.ReadKey().Key != ConsoleKey.Enter)
            {
                Console.WriteLine(" Press 'Enter' to start the game");
            }

            ChooseWord();
        }

        static void ChooseWord()
        {
            string[] words = new string[] { "car", "boat", "windsurfer", "automatic", "programming", "holiday", "christmas", "summer", "winter" };
            Random rand = new Random();
            int index = rand.Next(words.Length);
            string randomWord = words[index];

            Console.WriteLine(randomWord);

            GuessLetter(randomWord);
        }

        static void GuessLetter(String randomWord)
        {

            char[] lettersGuessed = new char[randomWord.Length];
            Console.WriteLine("Guess a letter.");

            for (int i = 0; i < randomWord.Length; i++)
            {
                lettersGuessed[i] = '_';

            }

           int r = 0;
           while (r <= randomWord.Length)
           {

                char playersGuess = char.Parse(Console.ReadLine());

                for (int j = 0; j < randomWord.Length; j++)
                {

                
                    if (playersGuess == randomWord[j])
                    {
                    
                    lettersGuessed[j] = playersGuess;
                    }
                }
                Console.WriteLine(lettersGuessed);
                r++;
               

            }//while

           
            Console.WriteLine("Game over!");

        }//end of GuessLetter
    }//end of class
}//end of namespace
