using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace HangManStarterKit
{
    class AutoPlay
    {
        private string Word { get; set; }
        public int NumberOfRuns { get; private set; }
        public List<int> RPTries { get; private set; }
        public List<int> BFPTries { get; private set; }
        public List<int> SPTries { get; private set; }
        private int TimesToRun { get; set; }

        public AutoPlay()
        {
            RPTries = new List<int>();
            BFPTries = new List<int>();
            SPTries = new List<int>();
            this.TimesToRun = TimesToRun;
            NumberOfRuns = 0;
        }

        /// <summary>
        /// Runs Automated tests using SmartPlayer, RandomPlayer, and BruteForcePlayer. 
        /// It displays the averages each players tries.
        /// </summary>
        public void Run()
        {
            Console.WriteLine("Welcome to Hangman Automated Tester.");
            Console.WriteLine();
            Console.Write("What word would you like to test with: ");
            Word = GetWord();
            Console.Write("How many times would you like to run the test: ");
            TimesToRun = GetInt();
            Play(Word, TimesToRun);
            DisplayStats();
            Console.Read();
        }

        /// <summary>
        /// Builds the player objects and HangmanGame objects for each player. 
        /// It then adds the numbers of tries for each player in their own list.
        /// </summary>
        /// <param name="word">string The word to test against</param>
        /// <param name="timesToRun">int The number of tests to run</param>
        private void Play(string word, int timesToRun)
        {
            NumberOfRuns++;
            timesToRun--;
            RandomPlayer rp = new RandomPlayer();
            BruteForcePlayer bfp = new BruteForcePlayer();
            SmartPlayer sp = new SmartPlayer();

            HangmanGame hg1 = new HangmanGame(rp, word, true);

            HangmanGame hg2 = new HangmanGame(bfp, word, true);
            HangmanGame hg3 = new HangmanGame(sp, word, true);

            RPTries.Add(rp.Tries);
            BFPTries.Add(bfp.Tries);
            SPTries.Add(sp.Tries);


            if (timesToRun > 0)
            {
                Play(word, timesToRun);
            }
        }

        /// <summary>
        /// Method to get valid word. Display error if contains anything but letters.
        /// </summary>
        /// <returns>string</returns>
        private string GetWord()
        {
            string word = Console.ReadLine().Trim();
            if (Regex.IsMatch(word, @"^[a-zA-Z]+$"))
            {
                return word;
            }
            else
            {
                Console.WriteLine("Must use A through Z. No numbers or symbols");
                return GetWord();
            }
        }

        /// <summary>
        /// Get number from user. Gives error if input was not a number.
        /// </summary>
        /// <returns></returns>
        private int GetInt()
        {
            try
            {
                return int.Parse(Console.ReadLine().Trim());
            }
            catch (Exception)
            {
                Console.WriteLine("Not a number please enter a number");
                return GetInt();
            }
        }

        /// <summary>
        /// Print the word used and number of tests. Then prints average of each players tries per game.
        /// </summary>
        public void DisplayStats()
        {
            Console.Clear();
            Console.WriteLine($"Test on {Word} was ran {NumberOfRuns} times");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Smart Player Average: {SPTries.Average()}");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Random Player Average: {RPTries.Average()}");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Brute Force Player Average: {BFPTries.Average()}");
        }
    }
}
