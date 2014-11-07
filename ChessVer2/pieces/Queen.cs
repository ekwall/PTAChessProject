using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessVer2
{
    public class Queen:ChessPiece
    {
        public Queen(int x, int y)
        {

            PosX = x;
            PosY = y;
            Name = "D";
            Coordinates = new List<string>();

            //Piece movements

            string moveUp = "0,-1.7";
            string moveRightDiagonallyUp = "1,-1.7";
            string moveRight ="1,0.7";
            string moveRightDiagonallyDown ="1,1.7";
            string moveDown = "0,1.7";
            string moveLeftDiagonallyDown="-1,1.7";
            string moveLeft = "-1,0.7";
            string moveLeftDiagonallyUp = "-1,-1.7";

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
