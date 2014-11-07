using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ChessVer2
{   
    class Game
    {
        private int OOBCounter, count, movestried, CountRndOne, CountRndTwo, countSameTile;
        public List<ChessPiece> PieceThatCanMove { get; set; }
        public List<string> AllMoves { get; set; }
        public List<ChessPiece> CanKill { get; set; }
        public Player player;
        //public List<ChessPiece> PieceList { get; set; }
       // public Player blackPlayer;       
        public Game()
        {
            player = new Player();
        }
        public void Start()
        {
            CanKill = new List<ChessPiece>();
            AllMoves = new List<string>();
            InitateGame();
            StartGame();
            
        }

        // This method controls the initiatiation of the game
        public void InitateGame()
        {
            

            // skicka till player
            CreatePieces();

            // skicka till projekt print gui
            PrintBoard();
            SetupPieces();



          

            PrintPieceOnBoard(player.PieceList);

        }

        public void StartGame()
        {
            while (true)
            {
                ClearTempLists(PieceThatCanMove);

                GenerateMoveOptions(player.PieceList);
                ChessPiece pieceToMove = PickPiece(PieceThatCanMove);
                string Coordinates = GetCoordinates(pieceToMove);
                MovePiece(pieceToMove, Coordinates);
            }
        }
        //De pjäser som inte kan rör sig tas bort ur listan PieceThatCanMove, har testkört och sett att det fungerar. 
        //Endast de pjäser som fortfarande har drag kvar återstår i listan.
        private void ClearTempLists(List<ChessPiece> pieces)
        {
            pieces.Clear(); 
        }
        //private void ClearTempLists()
        //{
            //pieces.Clear();
        //}

        /* ********** INITIATE GAME BELOW ********************** */

       

        public void CreatePieces()
        {
            
            PieceThatCanMove = new List<ChessPiece>();

        }

        public void PrintBoard()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {

                }
                Console.WriteLine("        " + i);

            }
            Console.WriteLine("01234567");
        }

        public void SetupPieces()
        {
           //  Rook rook = new Rook(0,7);
           //  rook.id = 1;
           //  PieceList.Add(rook);

           //  /*Rook rook2 = new Rook(7,7);
           //  rook.id = 1;
           //  PieceList.Add(rook2);*/

           //  Knight knight = new Knight(6,7);
           //  knight.id = 2;
           //  PieceList.Add(knight);

           //  King king = new King(2, 2);
           //  PieceList.Add(king);

           //  Queen queen = new Queen(3, 7);
           //  PieceList.Add(queen);

           // /*Knight knight2 = new Knight(1,7);
           // knight.id = 3;
           // PieceList.Add(knight2);

           // Bishop bishop = new Bishop(2,7);
           // PieceList.Add(bishop);

           // Bishop bishop2 = new Bishop(5,7);
           // PieceList.Add(bishop2);


           // Queen queen = new Queen(3,7);
           // PieceList.Add(queen);

           //Queen queen = new Queen(3,7);
           // PieceList.Add(queen);*/


            


          //Pawn pawn5=new Pawn(4,6);
          //  PieceList.Add(pawn5);

          //  Pawn pawn6=new Pawn(5,6);
          //  PieceList.Add(pawn6);

          //  Pawn pawn7=new Pawn(6,6);
          //  PieceList.Add(pawn7);
            
          //  Pawn pawn8=new Pawn(7,6);
          //  PieceList.Add(pawn8);
            

        }

        public void PrintPieceOnBoard(List <ChessPiece> PieceList)
        {

            foreach (var piece in PieceList)
            {
                Console.SetCursorPosition(piece.PosX, piece.PosY);
                Console.Write(piece.Name);
            }
            Console.SetCursorPosition(10, 10);
        }

        /*
        public void PrintPieceOnBoard(<ChessPiece> PieceList)
        {

            foreach (var piece in PieceList)
            {
                Console.SetCursorPosition(piece.PosX, piece.PosY);
                Console.Write(piece.Name);
            }
            Console.SetCursorPosition(10, 10);
        }*/




        /* ################### INITATE GAME END ########################## */

/* ********************** START GAME BELOW ************************** */



        public string GetCoordinates(ChessPiece pieceToMove)
        {
            string Coords;
           
            try
            {
                int randNumber = GetRandomNumber(pieceToMove.TurnAvailableMoves[0]);
                Coords = pieceToMove.TurnAvailableMoves[0][randNumber];
            }
            catch (Exception exc)
            {
                
                throw;
            }


            

           
                
            
            //string Coords = pieceToMove.TurnAvailableMoves[0][randNumber];

            return Coords;
        }

        public void MovePiece(ChessPiece pieceToMove, string coordinates)
        {
            /* Console.SetCursorPosition(0, 17);
             Console.WriteLine(pieceToMove.Name);
             foreach (var item in pieceToMove.TurnAvailableMoves[0][0])
             {
                
                 Console.WriteLine(item);
             }
             Console.ReadLine();*/
            

            string[] newCoordX = coordinates.Split(',');
            string[] newCoordY = newCoordX[1].Split('.');
            int newX = int.Parse(newCoordX[0]);
            int newY = int.Parse(newCoordY[0]);
           
            Console.SetCursorPosition(pieceToMove.PosX, pieceToMove.PosY);
            Console.Write(" ");
            pieceToMove.PosX=newX;
            pieceToMove.PosY = newY;

            Console.SetCursorPosition(pieceToMove.PosX, pieceToMove.PosY);
            Console.Write(pieceToMove.Name);
            System.Threading.Thread.Sleep(100);

            foreach (var piece in player.PieceList)
            {
                var tempx = piece.PosX;
                var tempy = piece.PosY;

                foreach (var item in player.PieceList)
                {
                    if(piece!=item)
                    {
                        if(item.PosX == tempx && item.PosY == tempy )
                        {
                            
                            countSameTile++;
                            Console.SetCursorPosition(20, 20);
                            Console.WriteLine("Same tile {0}.", countSameTile);
                            Console.ReadLine();
                            //System.Threading.Thread.Sleep(5000);
                        }
                    }
                }
            }

            foreach (var piece in player.PieceList)
            {
                piece.TurnAvailableMoves.Clear();
            }

        }

        public int GetRandomNumber(List<string> coords)
        {
            Random rnd = new Random();

            

            int max = coords.Count+1;
            int min = 1;
            int randomNumber = rnd.Next(min, max);

            /*Console.SetCursorPosition(0, 12);
            Console.WriteLine("               ");
            Console.WriteLine("               ");
            Console.WriteLine("               ");

            Console.SetCursorPosition(0, 12);
            Console.WriteLine("max: {0}", max);
            Console.WriteLine("min: {0}", min);
            Console.WriteLine("RND: {0}", randomNumber);
            Console.ReadLine();

            Console.SetCursorPosition(20, 22);
            Console.WriteLine("First random: {0}. secon random: {1}.",CountRndOne, CountRndTwo);*/
           

            
            return randomNumber-1;
        }
        

        public int GetRandomNumber(List<ChessPiece> pieces)
        {
            Random rnd = new Random();
            int max = pieces.Count+1;
            int min = 1;
            int randomNumber = rnd.Next(min, max);
            return randomNumber-1;
        }

        // TODO: Här i finns ett fel.
        // Pjäs (bonde) som nåt slutet på brädet och inte får en riktning tilldelat
        // Kan fortfarande väljas. Då kraschar appen då det inte finns en position att flytta till. 
        public ChessPiece PickPiece(List <ChessPiece> pieces)
        {
            int randomNumber = 0;
            
            bool nullNumber = true;

            while (nullNumber)
            {
                randomNumber = GetRandomNumber(pieces);

                if (pieces[randomNumber].TurnAvailableMoves.Count == 0)
                {

                    nullNumber = true;
                }
                if (pieces[randomNumber].TurnAvailableMoves.Count > 0)
                {
                    nullNumber = false;
                }

                
                
            }
            return pieces[randomNumber];
            

            
        }

        private void GenerateMoveOptions(List<ChessPiece> PieceList)
        {
            CalculatePieceMovement(player.PieceList);
        }

        private void CalculatePieceMovement(List<ChessPiece> PieceList)
        {
            foreach (var piece in player.PieceList)
            {
                piece.TurnAvailableMoves = new List<List<string>>();
                List<string> coordinates = new List<string>();

                

                foreach (var directions in piece.Coordinates)
	            {
                    movestried++;
                    Console.SetCursorPosition(20, 14);
                    Console.WriteLine("Calculated {0} move options", movestried);

                    var currentX = piece.PosX;
                    var currentY = piece.PosY;
                    

                    string[] getDirectionX = directions.Split(',');

                    string[] getDirectionYAndLength = getDirectionX[1].Split('.');


                    var addX = int.Parse(getDirectionX[0]);

                    var addY = int.Parse(getDirectionYAndLength[0]);

                    var pieceMovementLength = int.Parse(getDirectionYAndLength[1]);

                   

                    var outOfBounds = false;
                    var friendlyAhead = false;
                    var enemyAhead = false;

                    

                    //while (true)
                    for (int i = 0; i < pieceMovementLength; i++)
                    {
                        outOfBounds = CheckIfOutOfBounds(currentX, currentY, addX, addY);
                        friendlyAhead = CheckIfFriendlyAhead(currentX, currentY, addX, addY, PieceList);

                        // Om inte pjäsen går out of bounds, OCH det inte finns en friendly pjäs framför...
                        //Lägg till steget till Listan av möjliga rörelser. 
                        if(!outOfBounds && !friendlyAhead)
                        {
                            
                            if(enemyAhead)
                            {

                                CanKill.Add(piece);
                                

                            }

                            currentX = currentX + addX;
                            currentY = currentY + addY;
                            var addCoordinate = currentX + "," + currentY;
                            coordinates.Add(addCoordinate);
                            AllMoves.Add(addCoordinate);
                        }
                        else
                        {
                            break;
                        }
                    }
                }

                // Check if there is a coordinate to add. If there is, add the piece movements to list TurnAvailableMoves
                // This statement prevents the app to crash if a piece cannot move but is choosen to try to move.
                // As the piece that cannot move do not contain a "TurnAvailableMoves" list, another piece is picked.
                if (coordinates.Count >= 1)
                {
                    piece.TurnAvailableMoves.Add(coordinates);
                    PieceThatCanMove.Add(piece);                   
                }

                //TODO: ska en ny lista som innehåller alla pjäser som kan gå åt ett håll.
               // om ingen riktning sparas, lägg till i ny lista:
            }

        }

        public bool CheckIfFriendlyAhead(int currentX, int currentY, int addX, int addY, List<ChessPiece> friendyPieces)
        {
            int toMoveX = currentX + addX;
            int toMoveY = currentY + addY;

            int friendlyX;
            int friendlyY;
            foreach (var piece in friendyPieces)
            {
                friendlyX = piece.PosX;
                friendlyY = piece.PosY;

                if (friendlyX == toMoveX && friendlyY == toMoveY)
                {
                    count++;
                    Console.SetCursorPosition(20, 16);
                    Console.WriteLine("Friendly piece in the way {0} times", count);
                    System.Threading.Thread.Sleep(100);
                    return true;
                }
            }
            return false;
        }

      

        private bool MatchCoordinate(int x, int y, int newX, int newY)
        {
            if (x == newX && y == newY)
            {
                return true;
            }
            return false;
        }

        public bool CheckIfOutOfBounds(int currentX, int currentY, int newX, int newY)
        {
            if (currentX + newX > -1 && currentX + newX < 8 && currentY + newY >-1 && currentY + newY < 8)
            {
               return false;
            }
            OOBCounter++;
            Console.SetCursorPosition(20, 18);
            Console.WriteLine("Out Of Bounds tries {0}", OOBCounter);
            return true;
        }

        

        

        

        

        

        

        
    }
}
