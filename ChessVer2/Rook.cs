using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessVer2
{
    public class Rook : ChessPiece
    {



        public Rook(int x, int y)
        {

            PosX = x;
            PosY = y;

            Name = "R";
            Coordinates = new List<string>();

        //PieceMovement.

            

            string moveUp = "0,-1.7";
            string moveDown = "0,1.7";
            string moveLeft = "-1,0.7";
            string moveRight = "1,0.7";

            //List<string> Coordinates = new List <string>();

            Coordinates.Add(moveUp);
            Coordinates.Add(moveDown);
            Coordinates.Add(moveLeft);
            Coordinates.Add(moveRight);

        



        }

    }
}
