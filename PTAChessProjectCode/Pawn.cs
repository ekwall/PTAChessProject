using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTAChessProjectCode
{
    public class Pawn : ChessPiece
    {
        //public int Movement { get; set; }
        public int Strike { get; set; }
        
        public override string Describe()
        {
            return "Pawn "+ PositionX+PositionY;
        }
        public void MoveOptions()
        {
            //ToDo: enter logic for moving Pawn
        }
    }
}
