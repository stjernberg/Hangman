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
            char[] rightLetters = new char[randomWord.Length];
            //++Ability to add whole word
            int nrOfGuesses = 0;
            int countCorrect = 0;
            bool gameOver = false;
            char playersGuess;


            for (int i = 0; i < randomWord.Length; i++)
            {
                rightLetters[i] = '_';
            }


            while (!gameOver)
            {
                //++Exceptionhandling 

                if (nrOfGuesses < 10 && countCorrect < randomWord.Length)
                {

                    Console.WriteLine("Guess a letter.");

                    playersGuess = char.Parse(Console.ReadLine());
                    nrOfGuesses++;

                    for (int i = 0; i < randomWord.Length; i++)
                    {

                        if (playersGuess == randomWord[i])
                        {
                            rightLetters[i] = playersGuess;
                            countCorrect++;
                        }


                        else
                        {
                            wrongLetters.Append(playersGuess);
                                                      
                        }


                    }
                    Console.WriteLine(rightLetters);
                    
                    // ++ add - Console.WriteLine(wrongLetters);
                }//end of if 



                else
                {
                    gameOver = true;
                    Console.WriteLine("Game over!");
                }

            }//end of while

           



        }//end of GuessLetter
    }//end of class
}//end of namespace
