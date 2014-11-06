using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ChessVer2
{   
    class Game
    {
        private int OOBCounter = 0;
        private int count = 0;
        private int movestried = 0;
        public List<ChessPiece> PieceList { get; set; }

        public List<ChessPiece> CanKill { get; set; }

        

        
        public void Start()
        {
            CanKill = new List<ChessPiece>();
            InitateGame();
            StartGame();
            
        }

        // This method controls the initiatiation of the game
        public void InitateGame()
        {
            CreatePlayers();
            CreatePieces();
            PrintBoard();
            SetupPieces();
            PrintPieceOnBoard(PieceList);

        }

        public void StartGame()
        {
            while (true)
            {
                GenerateMoveOptions(PieceList);
                ChessPiece pieceToMove = PickPiece(PieceList);
                string Coordinates = GetCoordinates(pieceToMove);
                MovePiece(pieceToMove, Coordinates);
            }
        }

        /* ********** INITIATE GAME BELOW ********************** */

        public void CreatePlayers()
        {
            Player whitePlayer = new Player();
            Player blackPlayer = new Player();
            //Player playerOne = new Player();
            //TODO: Create piece list.
        }

        public void CreatePieces()
        {
            PieceList = new List<ChessPiece>();
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
            Rook rook = new Rook(0,7);
            rook.id = 1;
            PieceList.Add(rook);

            Rook rook2 = new Rook(7,7);
            rook.id = 1;
            PieceList.Add(rook2);

            Knight knight = new Knight(6,7);
            knight.id = 2;
            PieceList.Add(knight);

            Knight knight2 = new Knight(1,7);
            knight.id = 3;
            PieceList.Add(knight2);

            Bishop bishop = new Bishop(2,7);
            PieceList.Add(bishop);

            Bishop bishop2 = new Bishop(5,7);
            PieceList.Add(bishop2);

            Queen queen = new Queen(3,7);
            PieceList.Add(queen);

            Pawn pawn = new Pawn(0,6);
            PieceList.Add(pawn);

            Pawn pawn2 = new Pawn(1, 6);
            PieceList.Add(pawn2);

            Pawn pawn3 = new Pawn(2, 6);
            PieceList.Add(pawn3);

            Pawn pawn4 = new Pawn(3, 6);
            PieceList.Add(pawn4);

            Pawn pawn5=new Pawn(4,6);
            PieceList.Add(pawn5);

            Pawn pawn6=new Pawn(5,6);
            PieceList.Add(pawn6);

            Pawn pawn7=new Pawn(6,6);
            PieceList.Add(pawn7);
            
            Pawn pawn8=new Pawn(7,6);
            PieceList.Add(pawn8);
            
        }

        public void PrintPieceOnBoard(List<ChessPiece> PieceList)
        {

            foreach (var piece in PieceList)
            {
                Console.SetCursorPosition(piece.PosX, piece.PosY);
                Console.Write(piece.Name);
            }
            Console.SetCursorPosition(10, 10);
        }

        /* ################### INITATE GAME END ########################## */

/* ********************** START GAME BELOW ************************** */



        public string GetCoordinates(ChessPiece pieceToMove)
        {
            int randNumber = GetRandomNumber(pieceToMove.TurnAvailableMoves[0]);

            string Coords = pieceToMove.TurnAvailableMoves[0][randNumber];

            return Coords;
        }

        public void MovePiece(ChessPiece pieceToMove, string coordinates)
        {
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
        }

        public int GetRandomNumber(List<string> coords)
        {
            Random rnd = new Random();
            
            int max = coords.Count;
            int min = 0;
            if (max == min)
            {
                return 0;
            }
            int randomNumber = rnd.Next(min, max);
            return randomNumber;
        }
        

        public int GetRandomNumber(List<ChessPiece> pieces)
        {
            Random rnd = new Random();
            int max = pieces.Count;
            int min = 0;
            int randomNumber = rnd.Next(min, max);
            return randomNumber;
        }

        public ChessPiece PickPiece(List <ChessPiece> pieces)
        {
            int randomNumber = GetRandomNumber(pieces);
            return pieces[randomNumber];
        }

        private void GenerateMoveOptions(List<ChessPiece> PieceList)
        {
            CalculatePieceMovement(PieceList);
        }

        private void CalculatePieceMovement(List<ChessPiece> PieceList)
        {
            foreach (var piece in PieceList)
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
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                 piece.TurnAvailableMoves.Add(coordinates);
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

                if (friendlyX == toMoveX && friendlyX == toMoveY)
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
