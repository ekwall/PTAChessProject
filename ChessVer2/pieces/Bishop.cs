using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessVer2
{
    class Bishop : ChessPiece
    {

        public Bishop(int x, int y)
        {
            Name = "L";
            PosX = x;
            PosY = y;
            Coordinates = new List<string>();

        //PieceMovement.

            

            string moveUpLeft = "-1,-1.8";
            string moveDownRight = "1,1.8";
            string moveUpRight = "-1,1.8";
            string moveDownLeft = "1,-1.8";

            //List<string> Coordinates = new List <string>();

            Coordinates.Add(moveUpLeft);
            Coordinates.Add(moveDownRight);
            Coordinates.Add(moveUpRight);
            Coordinates.Add(moveDownLeft);

        



        }
    }
}
