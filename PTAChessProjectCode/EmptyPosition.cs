using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTAChessProjectCode
{
    class EmptyPosition : ChessPiece
    {
        private string team;


        public EmptyPosition(string team)
        {

            this.team = team;
        }
    }
}
