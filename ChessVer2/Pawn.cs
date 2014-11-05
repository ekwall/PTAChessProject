using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessVer2
{
    public class Pawn : ChessPiece
    {


        public Pawn()
        {
            
            Coordinates = new List<string>();

            string moveUp = "0,-1.7";
            string moveDown = "0,1.7";
            string moveLeft = "-1,0.7";
            string moveRight = "1,0.7";

            Coordinates.Add(moveUp);
            Coordinates.Add(moveDown);
            Coordinates.Add(moveLeft);
            Coordinates.Add(moveRight);

        }
    }

    
}
