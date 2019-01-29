using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangManStarterKit
{
    class Program
    {
        static void Main(string[] args)
        {
            Player p = new ABCplayer();
            HumanPlayer p2 = new HumanPlayer();
            //Need to add in how to handle multi letter words like apple
            HangmanGame hg = new HangmanGame(p2);
        }
    }
}
