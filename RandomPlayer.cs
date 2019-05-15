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

            int index = Rnd.Next(0, alphabet.Count);
            char guess = 'a';
            if (index < alphabet.Count)
            {
                guess = alphabet[index];
                alphabet.RemoveAt(index);
            }
            return guess;
        }
    }
}
