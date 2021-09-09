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
            bool won = false;
            char guess;
            string input;


            for (int i = 0; i < randomWord.Length; i++)
            {
                rightLetters[i] = '_';
            }


            while (!gameOver && !won)
            {
                //++Exceptionhandling                                

                if (nrOfGuesses < 10 && countCorrect < randomWord.Length)
                {
                    Console.WriteLine("Guess a letter or the word.");
                    input = Console.ReadLine();
                    guess = input[0];

                    if (input.Length > 1)
                    {
                        if (input == randomWord)
                        {
                            won = true;
                            gameOver = true;
                        }
                    }

                    else
                    {
                        for (int i = 0; i < randomWord.Length; i++)
                        {
                            if (guess == randomWord[i])
                            {
                                rightLetters[i] = guess;
                                countCorrect++;

                                if (countCorrect == randomWord.Length)
                                {
                                    won = true;
                                }
                            }

                            else
                            {
                                wrongLetters.Append(guess);
                            }

                        }
                    }

                    string outputRight = string.Join(" ", rightLetters);
                    Console.WriteLine(outputRight);
                    nrOfGuesses++;
                    // ++ add - Console.WriteLine(wrongLetters);
                }//end of if 


                else
                {
                    gameOver = true;
                }



            }//end of while


            // ++ add - Console.WriteLine(wrongLetters);

            gameOver = true;
            Console.WriteLine("Game over!");

            if (won)
            {
                Console.WriteLine("You won!");
            }
            else
            {
                Console.WriteLine("You lost!");
            }

        }//end of GuessLetter
    }//end of class
}//end of namespace
