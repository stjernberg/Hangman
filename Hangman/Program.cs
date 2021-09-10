﻿using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the hangman game. Please press 'Enter'  to start.");

            while (Console.ReadKey().Key != ConsoleKey.Enter)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" Press 'Enter' to start the game");
                Console.ResetColor();
            }

            GetRandomWord();
        }

        static void GetRandomWord()
        {
            string[] words = new string[] { "car", "boat", "windsurfer", "red", "program", "holiday", "christmas", "summer", "winter" };
            Random rand = new Random();
            int index = rand.Next(words.Length);
            string random = words[index];
            string randomWord = random.ToUpper();
            Console.WriteLine(randomWord);
            GuessLetterOrWord(randomWord);
        }

        static void GuessLetterOrWord(String randomWord)
        {

            StringBuilder wrongLetters = new StringBuilder();
            StringBuilder typedLetters = new StringBuilder();
            char[] rightLetters = new char[randomWord.Length];
            int nrOfGuesses = 10;
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

                if (nrOfGuesses > 0 && countCorrect < randomWord.Length)
                {
              
                    Console.WriteLine("Guess a letter or the word.");
                    input = Console.ReadLine().ToUpper();
                    guess = input[0];

                   
                    if (Char.IsLetter(guess) && !typedLetters.ToString().Contains(guess))
                    {

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

                                typedLetters.Append(guess);

                                if (guess == randomWord[i])
                                {
                                    rightLetters[i] = guess;
                                    countCorrect++;

                                    if (countCorrect == randomWord.Length)
                                    {
                                        won = true;
                                        gameOver = true;
                                    }
                                }

                                else
                                {
                                    if (!randomWord.Contains(guess) && !wrongLetters.ToString().Contains(guess))
                                    {
                                        wrongLetters.Append(guess + " ");
                                    }

                                }

                            }
                        }
                        nrOfGuesses--;

                        if (!gameOver && !won)
                        {
                            string outputRight = string.Join(" ", rightLetters);
                            Console.WriteLine($"{outputRight} \nLetters guessed wrong: {wrongLetters}");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine((nrOfGuesses > 0) ? $"You have { nrOfGuesses} guesses left" : "");
                            Console.ResetColor();
                        }

                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write ((Char.IsLetter(guess)) ? $"You already guessed letter {guess}." : "Input must be a letter or a word."); 
                        Console.WriteLine(" Please try again!");
                        Console.ResetColor();
                    }

                }//end of outer if         

                else
                {
                    gameOver = true;
                }


            }//end of while gameOver


            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Game over!");
            Console.Write((won) ? "You won!" : "You lost!");
            Console.WriteLine("The correct word was " + randomWord);
            Console.ResetColor();

        }//end of GuessLetter
    }//end of class
}//end of namespace
