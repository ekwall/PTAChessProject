using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessVer2
{
    public abstract class ChessPiece
    {
        public int PosX { get; set; }
        public int PosY { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
        public List<ChessPiece> PiecesICanKill { get; set; }

        public int id { get; set; }

        //public List<List<string>> PieceMovement { get; set; }
        // 
        public List<string> Coordinates { get; set; }

        // Temporär lista vilken sparar samtliga coordinater en pjäs tillåts att flytta till.
        // Varje pjäs får en unik lista med detta innehåll.

        public List<List<string>> TurnAvailableMoves { get; set; }


    }
}
