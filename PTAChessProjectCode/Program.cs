using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTAChessProjectCode                   //Andreas Push: https://ekwall@github.com/Win14Crone/PTAChessProject 
                                                //Therese Push: https://Win14Therese@github.com/Win14Crone/PTAChessProject
{
    class Program
    {
        static void Main(string[] args)
        {
            GameEngine Engine = new GameEngine();
            Engine.InitiateGame();
        }
    }
}
