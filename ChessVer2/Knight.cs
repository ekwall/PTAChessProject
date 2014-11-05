using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessVer2
{
    class Knight : ChessPiece
    {


        public Knight(int x, int y)
        {
            Name = "K";

            PosX = x;
            PosY = y;

            Coordinates = new List<string>();

            //PieceMovement.



            string moveUpLeft = "-1,-2.1";
            string moveUpRight = "1,-2.1";
            string moveRightUp = "2,-1.1";
            string moveRightDown = "2,1.1";
            string moveDownRight = "1,2.1";
            string moveDownLeft = "-1,2.1";
            string moveLeftDown = "-2,1.1";
            string moveLeftUp = "-2,-1.1";

            //List<string> Coordinates = new List <string>();

            Coordinates.Add(moveUpLeft);
            Coordinates.Add(moveUpRight);
            Coordinates.Add(moveRightUp);
            Coordinates.Add(moveRightDown);
            Coordinates.Add(moveDownRight);
            Coordinates.Add(moveDownLeft);
            Coordinates.Add(moveLeftDown);
            Coordinates.Add(moveLeftUp);





        }
    }
}
