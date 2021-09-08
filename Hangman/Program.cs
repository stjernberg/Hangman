using System;
using System.Text;

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
            string[] words = new string[] { "car", "boat", "windsurfer", "red", "program", "holiday", "christmas", "summer", "winter" };
            Random rand = new Random();
            int index = rand.Next(words.Length);
            string randomWord = words[index];

            Console.WriteLine(randomWord);

            GuessLetter(randomWord);

        }

        static void GuessLetter(String randomWord)
        {

            StringBuilder wrongLetters = new StringBuilder();
            char[] lettersGuessed = new char[randomWord.Length];
            //++Ability to add whole word
            int nrOfGuesses = 0;
            int letterCorrect = 0;
            bool gameOver = false;
            char playersGuess;

            for (int i = 0; i < randomWord.Length; i++)
            {
                lettersGuessed[i] = '_';

            }

           
            while (!gameOver)

            {
                Console.WriteLine("Guess a letter.");
                playersGuess = char.Parse(Console.ReadLine());
                nrOfGuesses++;

                //++Exceptionhandling 


                if (nrOfGuesses < 10 && letterCorrect < randomWord.Length)
                {
                   

                    for (int i = 0;  i < randomWord.Length; i++)
                    {

                        if (playersGuess == randomWord[i])
                        {
                            lettersGuessed[i] = playersGuess;
                            letterCorrect++;

                        }

                        else
                        {
                            wrongLetters.Append(playersGuess);
                        }
  
                       
                    }
                    Console.WriteLine(lettersGuessed);

                    // ++ add - Console.WriteLine(wrongLetters);
                }
         
                else
                {
                    gameOver = true;
                }

            }//while


            Console.WriteLine("Game over!");

        }//end of GuessLetter
    }//end of class
}//end of namespace
