using System;
using System.Collections.Generic;
using System.Linq;

namespace HangManStarterKit
{
    class HangmanGame
    {
        //this is the word you're trying to guess
        public bool automated = false;
        public string word;
        public int tries = 0;
        public List<char> guessedLetters = new List<char>();
        public List<char> foundLetters = new List<char>();
        List<string> wordBank = new List<string> { "fish", "apple", "tree", "dog", "rides", "scrambled" };
        Player guesser;
        public HangmanGame(Player guesser)
        {
            this.guesser = guesser;
            guesser.startTime = new DateTime();
            guesser.startTime = DateTime.Now;
            Random r = new Random();
            int index = r.Next(0, wordBank.Count);
            word = wordBank[index];

            Setup();
        }

        public HangmanGame(Player guesser, string word, bool automated = false)
        {
            this.automated = automated;
            this.guesser = guesser;
            this.word = word.ToLower();
            Setup();
            guesser.alphabet = new List<char> { 'a', 'b', 'c', 'd', 'e', 'f', 'g',
                'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't',
                'u', 'v', 'w', 'x', 'y', 'z' };
        }

        private void Setup()
        {
            for (int i = 0; i < word.Length; i++)
            {
                foundLetters.Add('_');
            }
            Run();
        }

        public void Run()
        {
            while (HasWon() == false)
            {
                char c = '!';
                if (automated)
                {

                    c = guesser.Guess();
                    PlayRound(c);
                }
                else
                {

                    Console.WriteLine();
                    PrintProgress();
                    Console.WriteLine("Please guess a letter");
                    //This is where you'll want to call your player.guess() method
                    /// char c = char.Parse(Console.ReadLine());
                    c = guesser.Guess();
                    Console.WriteLine(c);
                    PlayRound(c);
                }
            }
            PrintProgress();
        }

        public bool HasWon()
        {
            for (int i = 0; i < word.Length; i++)
            {
                if (foundLetters[i] != word[i])
                {
                    return false;
                }
            }
            guesser.Tries = tries;
            guesser.endTime = DateTime.Now;
            guesser.timeSpan = guesser.endTime - guesser.startTime;
            //Console.WriteLine(guesser.timeSpan);
            if (!automated)
            {
                Console.WriteLine("You won! Good Job!");
            }
            return true;
        }

        public void PlayRound(char guess)
        {
            tries++;
            if (guessedLetters.Contains(guess))
            {
                if (!automated)
                {
                    Console.WriteLine("You already guessed that!");
                }
            }
            else if (word.Contains(guess))
            {
                if (!automated)
                {
                    Console.WriteLine("Found a letter!");
                }
                for (int i = 0; i < word.Length; i++)
                {
                    if (word[i] == guess)
                    {
                        foundLetters[i] = guess;
                    }
                }
                guessedLetters.Add(guess);
            }
            else
            {
                if (!automated)
                {
                    Console.WriteLine("No Letter found...");
                }
            }
            if (guesser is HumanPlayer)
            {
                Console.ReadLine();
            }
            if (!automated)//Added for autoplay
            {
                Console.Clear();
            }

        }

        public void PrintProgress()
        {
            if (!automated)
            {
                foreach (char c in foundLetters)
                {
                    Console.Write(c + " ");
                }
                Console.WriteLine();
                Console.WriteLine("You have guessed: {0} times", tries);
            }
        }
    }
}
