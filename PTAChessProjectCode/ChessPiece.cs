using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTAChessProjectCode
{
    public abstract class ChessPiece
    {
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public int ID { get; set; }
        public string Name { get; set; }
       

        //public bool CanMove { get; set; }

        public List<string> Movement;
        public List<string> PossibleMovement;
        


        
        public virtual string Describe()
        {
            return " "+PositionX + PositionY;
        }
    }
}
