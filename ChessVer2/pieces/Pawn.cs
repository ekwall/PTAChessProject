using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessVer2
{
    public class Pawn : ChessPiece
    {


        public Pawn(int x, int y, string movement)
        {

            PosX = x;
            PosY = y;
            Name = "B";
            Coordinates = new List<string>();

            string moveUp = movement;
            
            
            
          
            


            Coordinates.Add(moveUp);
            Coordinates.Add(moveUp);
            
            
            
            
           
            
            

        }
    }

    
}
