using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessVer2
{
    class King:ChessPiece
    {
        public King(int x, int y)
        {
            Name = "K";
            PosX = x;
            PosY = y;
            Coordinates = new List<string>();

            //PieceMovement.



            string moveUp = "0,-1.1";
            string moveRightDiagonallyUp = "1,-1.1";
            string moveRight = "1,0.1";
            string moveRightDiagonallyDown = "1,1.1";
            string moveDown = "0,1.1";
            string moveLeftDiagonallyDown = "-1,1.1";
            string moveLeft = "-1,0";
            string moveLeftDiagonallyUp = "-1,-1.1";

            //List<string> Coordinates = new List <string>();

            Coordinates.Add(moveUp);
            Coordinates.Add(moveRightDiagonallyUp);
            Coordinates.Add(moveRight);
            Coordinates.Add(moveRightDiagonallyDown);
            Coordinates.Add(moveDown);
            Coordinates.Add(moveLeftDiagonallyDown);
            Coordinates.Add(moveLeft);
            Coordinates.Add(moveLeftDiagonallyUp);
        }
    }
}
