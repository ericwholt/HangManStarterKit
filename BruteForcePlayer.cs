﻿using System.Collections.Generic;

namespace HangManStarterKit
{
    class BruteForcePlayer : Player
    {
        public override char Guess()
        {

                char guess = alphabet[0];
                alphabet.RemoveAt(0);
            return guess;
        }
    }
}
