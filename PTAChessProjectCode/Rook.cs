using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTAChessProjectCode
{
    class Rook : ChessPiece
    {
        public Rook()
        {
            Movement = new List<string>();

            string length = "8";
            var N = "0,-1";
            var E = "1,0";
            var S = "0,1";
            var W = "-1,0";

            //Movement.Add(length);
            Movement.Add(N);
            Movement.Add(E);
            Movement.Add(S);
            Movement.Add(W);



        }
    }
}
