using System;

namespace HangManStarterKit
{
    class RandomPlayer : Player
    {
        public Random Rnd { get; set; }

        public RandomPlayer()
        {
            Rnd = new Random();
        }

        public override char Guess()
        {
            int index = -1;
            char guess = 'a';
            try
            {
                index = Rnd.Next(0, alphabet.Count);

            }
            catch (Exception)
            {
                Rnd = new Random();
                index = Rnd.Next(0, alphabet.Count);
            }
            if (index < alphabet.Count)
            {
                guess = alphabet[index];
                alphabet.RemoveAt(index);
            }
            return guess;
        }
    }
}
