using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessVer2
{
    public class Pawn : ChessPiece
    {


        public Pawn(int x, int y)
        {

            PosX = x;
            PosY = y;
            Name = "P";
            Coordinates = new List<string>();

            string moveUp = "0,-1.1";
            string moveDown = "0,1.1";
            
          
            


            Coordinates.Add(moveUp);
            Coordinates.Add(moveDown);
            
            
           
            
            

        }
    }

    
}
