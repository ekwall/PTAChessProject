using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTAChessProjectCode
{
    class GameEngine
    {

        public List<ChessPiece> whitePieces { get; set; }
        public List<ChessPiece> blackPieces { get; set; }
        public List<ChessPiece> CanMove { get; set; }
        private int randomListPosition;
        public int DecidedX {get; set; }
        public int DecidedY { get; set; }
        IGame GameInterface;

        public GameEngine()
        {
            GameInterface = new IGame();
            CanMove = new List<ChessPiece>();
        }

        public void SetRandomListPosition(List<ChessPiece> pieces)
        {
           
            Random rnd = new Random();
            int max = pieces.Count;
            int min = 0;

            int randomNumber = rnd.Next(min, max);

            randomListPosition = randomNumber;
            
        }

        public void SetRandomListPosition(List<string> possibleMovements)
        {

            Random rnd = new Random();
            int max = possibleMovements.Count;
            int min = 0;

            int randomNumber = rnd.Next(min, max);

            randomListPosition = randomNumber;

        }

        

        

        public bool NotOutOfBounds(int x, int y, int newx, int newy)
        {
            int tryMoveX = x + newx;
            int tryMoveY = y + newy;
            
            
            if (tryMoveY == 1 || tryMoveY == 6 || tryMoveX == 1 || tryMoveX == 6)
            {
               //Console.WriteLine("false");
                return false;
            }
           
            else
            {
               //Console.WriteLine("true");
                return true;
            }
                
        }


        public void CheckMovementOptions(List<ChessPiece> pieces)
            
        {
            
            foreach (var piece in pieces)
            {
                piece.PossibleMovement = new List<string>();
                
                //int lenght = 8;
                int x = piece.PositionX;
                int y = piece.PositionY;

              

                foreach (var direction in piece.Movement)
                {
                   
                    
                    
                   string[] brakeOutCoords = direction.Split(',');
                   var newx = int.Parse(brakeOutCoords[0]);
                   var newy = int.Parse(brakeOutCoords[1]);

                   int turnsInDirection = 0;

                 
                  while (NotOutOfBounds(x, y, newx, newy))
                      
                      
                       {
                           x = x + newx;
                           y = y + newy;

                           turnsInDirection++;

                        
                       }


                       if (turnsInDirection != 0)
                       {
                          /* Console.WriteLine(direction + " hej" + turnsInDirection);
                           Console.ReadLine();*/
                           piece.PossibleMovement.Add(direction + "," + turnsInDirection);

                           CanMove.Add(piece);

                       
                       }
                   


                    
                }
                
                if(piece.PossibleMovement.Count != 0){
                    CanMove.Add(piece);
                    
                }
            }
        }

        public void PrintMovementOptions(List <ChessPiece> pieces)
        {

            //Console.SetCursorPosition(20, 20);
            foreach (var piece in pieces)
            {
                if (piece.PossibleMovement.Count != 0)
                {
                    foreach (var direction in piece.PossibleMovement)
                    {
                        Console.WriteLine(direction);
                    }
                }
            }

            Console.ReadLine();
        }


        public ChessPiece DecidePieceToMove(List <ChessPiece> PickPiece)
        {
           
            SetRandomListPosition(PickPiece);



            return PickPiece[randomListPosition];
        }



       public void DecideDirection(ChessPiece piece){
          /* Console.WriteLine(piece.PossibleMovement[0]);
           Console.WriteLine(piece.PossibleMovement[1]);*/
           Console.ReadLine();
           SetRandomListPosition(piece.PossibleMovement);
           var direction = piece.PossibleMovement[randomListPosition];

           string[] directionCoordinates = direction.Split(',');

           int x = piece.PositionX;
           int y = piece.PositionY;
           int length = int.Parse(directionCoordinates[2]);

           int randomMovementLength = SetRandomNumber(0, length);

           //for (int i = 0; i < randomMovementLength; i++)
           for (int i = 0; i < 1; i++)
           {
               /*Console.SetCursorPosition(12, 12);
               Console.WriteLine(x);
               Console.SetCursorPosition(12, 14);
               Console.WriteLine(y);
               Console.ReadLine();*/

              x = x + int.Parse(directionCoordinates[0]);
              y = y + int.Parse(directionCoordinates[1]);
           }

           DecidedX = x;
           DecidedY = y;
        }

       public int SetRandomNumber(int minValue, int maxValue)
       {

           Random rnd = new Random();
           int randomNumber = rnd.Next(minValue, maxValue);

           return randomNumber;

       }

       public void ClearLists(List<ChessPiece> pieces)
       {
           pieces.Clear();
       }

        public void ClearPoop(List <ChessPiece> pieces){

            foreach (var piece in pieces)
            {
                
                piece.PossibleMovement.Clear();
            }

        }

        internal void StartGame()
        {
             
            

            while (true)
            {
                CheckMovementOptions(whitePieces);
                var pieceToMove = DecidePieceToMove(whitePieces);
                DecideDirection(pieceToMove);
                MovePiece(pieceToMove, DecidedY, DecidedX);
                ClearLists(CanMove);
                ClearPoop(whitePieces);
               

            } // While end ***
            
            



            


        }
        internal void InitiateGame()
        {
            whitePieces = new List<ChessPiece>();
            blackPieces = new List<ChessPiece>();

            for (int i = 2; i < 4; i++)
            {
                Rook R = new Rook();
                R.ID = i;
                R.PositionX = i;
                R.PositionY = 5;
                R.Name = "R";
                
                whitePieces.Add(R);
                

                /*Pawn P = new Pawn();
                P.ID = i;
                P.PositionX = i;
                P.PositionY = 6;
                P.Name = "P";
                P.Movement = -1;
                whitePieces.Add(P);*/
            }
            for (int i = 3; i < 4; i++)
            {
                Rook R = new Rook();
                R.ID = i;
                R.PositionX = i;
                R.PositionY = 1;
                R.Name = "R";
               
                blackPieces.Add(R);
            }
            GameInterface.PrintGameBoard();
            GameInterface.PrintPieces(whitePieces, blackPieces);

            StartGame();
            
        }
        public List<ChessPiece> RemovePiece(List<ChessPiece> pieceList, int x, int y)
        {
            foreach (var piece in pieceList)
            {
                if (piece.PositionX == x && piece.PositionY == y)
                {
                    pieceList.Remove(piece);
                    break;
                }
            }
            return pieceList;
        }






        public void MovePiece(ChessPiece piece, int x, int y)
        {
            RemovePieceFromGui(piece);
            SetPieceNewCoordinates(piece, x, y);
            PrintPiece(piece);
            
        }

        public void RemovePieceFromGui(ChessPiece piece)
        {
            Console.SetCursorPosition(piece.PositionX, piece.PositionY);
            Console.Write(" ");
        }

        public void SetPieceNewCoordinates(ChessPiece piece, int x, int y)
        {
            piece.PositionX = x;
            piece.PositionY = y;
        }

        public void PrintPiece(ChessPiece piece)
        {
            Console.SetCursorPosition(piece.PositionX, piece.PositionY);
            Console.Write(piece.Name);
        }
    }
}
