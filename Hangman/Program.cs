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
            Console.WriteLine(words[index]);
        }
    }
}
