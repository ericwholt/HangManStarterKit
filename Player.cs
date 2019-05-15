using System;
using System.Collections.Generic;

namespace HangManStarterKit
{
    abstract class Player
    {
        public int Tries = 0;
        public TimeSpan timeSpan = new TimeSpan();
        public DateTime startTime = new DateTime();
        public DateTime endTime = new DateTime();

        public List<char> alphabet = new List<char> { 'a', 'b', 'c', 'd', 'e', 'f', 'g',
                'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't',
                'u', 'v', 'w', 'x', 'y', 'z' };
        public abstract char Guess();
    }
}
