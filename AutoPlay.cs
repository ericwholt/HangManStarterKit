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
        //private Player CurrentPlayer { get; set; }
        private int TimesToRun { get; set; }
        public List<TimeSpan> SPTimeSpans { get; set; }
        public List<TimeSpan> RPTimeSpans { get; set; }
        public List<TimeSpan> BFPTimeSpans { get; set; }
        public double RPAverageTicks { get; set; }
        public double BFPAverageTicks { get; set; }
        public double SPAverageTicks { get; set; }

        public AutoPlay()
        {
            RPTries = new List<int>();
            BFPTries = new List<int>();
            SPTries = new List<int>();
            SPTimeSpans = new List<TimeSpan>();
            RPTimeSpans = new List<TimeSpan>();
            BFPTimeSpans = new List<TimeSpan>();

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
            //RPTimeSpans.Add(rp.timeSpan);
            BFPTries.Add(bfp.Tries);
            //BFPTimeSpans.Add(bfp.timeSpan);
            SPTries.Add(sp.Tries);
            //SPTimeSpans.Add(sp.timeSpan);

            //double RPAverageTicks = RPTimeSpans.Average(timeSpan => timeSpan.Ticks);
            //double BFPAverageTicks = RPTimeSpans.Average(timeSpan => timeSpan.Ticks);
            //double SPAverageTicks = RPTimeSpans.Average(timeSpan => timeSpan.Ticks);
            

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
        //public void DisplayStats()
        //{
        //    Console.Clear();
        //    Console.WriteLine($"Test on {Word} was ran {NumberOfRuns} times");
        //    Console.WriteLine();
        //    Console.ForegroundColor = ConsoleColor.Yellow;
        //    Console.WriteLine($"Smart Player Average: {SPTries.Average()}");
        //    Console.WriteLine();
        //    Console.ForegroundColor = ConsoleColor.Green;
        //    Console.WriteLine($"Random Player Average: {RPTries.Average()}");
        //    Console.WriteLine();
        //    Console.ForegroundColor = ConsoleColor.Red;
        //    Console.WriteLine($"Brute Force Player Average: {BFPTries.Average()}");
        //}

        /// <summary>
        /// Print the word used and number of tests. Then prints average of each players tries per game.
        /// </summary>
        private void DisplayStats()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(AddSpacesToFrontBackString($"Test on {Word} was ran {NumberOfRuns} times", 68));
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine($"{AddSpacesToString("Player Type", 20)}{AddSpacesToString("Games Played", 15)}{AddSpacesToString("Avg Tries", 13)}{AddSpacesToString("Avg Time", 20)}");
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine($"{AddSpacesToString("Smart Player", 20)}{AddSpacesToString(NumberOfRuns.ToString(), 15)}{AddSpacesToString(SPTries.Average().ToString(), 13)}{AddSpacesToString("Not Implemented", 20)}");
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine($"{AddSpacesToString("Random Player", 20)}{AddSpacesToString(NumberOfRuns.ToString(), 15)}{AddSpacesToString(RPTries.Average().ToString(), 13)}{AddSpacesToString("Not Implemented", 20)}");
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine($"{AddSpacesToString("Brute Force Player", 20)}{AddSpacesToString(NumberOfRuns.ToString(), 15)}{AddSpacesToString(BFPTries.Average().ToString(), 13)}{AddSpacesToString("Not Implemented", 20)}");
            Console.ResetColor();
        }

        /// <summary>
        /// Returns string with spaces on right side equal to string length minus int number of spaces.
        /// </summary>
        /// <param name="str">string</param>
        /// <param name="numberOfSpaces">int</param>
        /// <returns>string</returns>
        private string AddSpacesToString(string str, int numberOfSpaces)
        {
            {
                int leng = numberOfSpaces - str.Length;
                for (int i = 0; i < leng; i++)
                {
                    str += " ";
                }
                return str;
            }
        }

        private string AddSpacesToFrontBackString(string str, int numberOfSpaces)
        {
            {
                //while (str.Length < 4)
                //{
                //    str += " ";
                //}

                string tempStr = "";
                int halfString;
                int strLength = 0;
                if (str.Length % 2 == 1)
                {

                    strLength = str.Length + 1;
                }
                else
                {
                    strLength = str.Length;
                }
                halfString = strLength / 2;
                int numberOfSpacesEven;
                if (numberOfSpaces % 2 == 1)
                {
                    numberOfSpacesEven = numberOfSpaces - 1;
                }
                else
                {
                    numberOfSpacesEven = numberOfSpaces;
                }
                int halfSpaces = numberOfSpacesEven / 2;
                //int leng = halfSpaces - str.Length;
                for (int i = 0; i < halfSpaces - halfString; i++)
                {
                    tempStr += " ";
                }
                //for (int k = 0; k < remainspaces; k++)
                //{
                //    tempStr += " ";
                //}
                tempStr += str.Trim();
                for (int j = 0; j < halfSpaces - halfString; j++)
                {
                    tempStr += " ";
                }
                if (tempStr.Length - numberOfSpaces < 0)
                {
                    tempStr += " ";
                }

                return tempStr;
            }
        }
    }
}
