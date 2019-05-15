using System;
using System.Linq;

namespace HangManStarterKit
{
    class Program
    {
        static void Main(string[] args)
        {
            //HumanPlayer hp = new HumanPlayer();
            //HangmanGame hg = new HangmanGame(hp);
            //hg.Run();
            AutoPlay ap = new AutoPlay();
            ap.Run();
        }
    }
}
