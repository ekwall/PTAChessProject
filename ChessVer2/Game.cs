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
        GUI gui;
        public int countMoves = 1;
        public Player playerOne;
        public Player playerTwo;
        public MoveData moveData;
             
        public Game()
        {
            //playerOne = new Player();
            gui = new GUI();
            
        }
        public void Start()
        {
           InitateGame();
           StartGame();
        }

        // This method controls the initiatiation of the game
        public void InitateGame()
        {
            CreatePlayers();
            PrintBoard();
            PrintPieceOnBoard(playerOne.PieceList);
            PrintPieceOnBoard(playerTwo.PieceList);
            SetPlayerTurn();
            var playerToBegin = FetchPlayerToBegin();
            var playerNotMovin = FetchPlayerNotMoving();
            CreateMoveLogic(playerToBegin, playerNotMovin);

        }

        public void CreateMoveLogic(Player playerToBegin, Player playerNotMovin)
        {
            moveData = new MoveData(playerToBegin, playerNotMovin);

        }

        public Player FetchPlayerToBegin()
        {
            if (playerOne.MyTurn == true)
            {
                return playerOne;
            }
            else
            {
                return playerTwo;
            }
        }

        public Player FetchPlayerNotMoving()
        {
            if (playerOne.MyTurn == false)
            {
                return playerOne;
            }
            else
            {
                return playerTwo;
            }
        }

        public void CreatePlayers()
        {
            bool playerWhite = true;
            bool playerBlack = false;
            bool myTurn = false;

            playerOne = new Player(playerWhite, myTurn);
            playerTwo = new Player(playerBlack, myTurn);
            
        }

        public void SetPlayerTurn()
        {
            playerOne.MyTurn = true;
        }

        public void StartGame()
        {
            while (true)
            {
                var playerToMakeMove = CheckPlayerTurn();
                moveData.MakeMove(playerToMakeMove);
                countMoves++;
                SwitchPlayerTurn(playerToMakeMove);
             }
        }

        public Player CheckPlayerTurn()
        {
            if (playerOne.MyTurn == true)
            {
                return playerOne;
            }
            else
            {
                return playerTwo;
            }
        }

        public void SwitchPlayerTurn(Player playerMadeMove)
        {
            if(countMoves%2 == 1)
            {
                playerOne.MyTurn = true;
                playerTwo.MyTurn = false;
            }
            else
            {
                playerTwo.MyTurn = true;
                playerOne.MyTurn = false;
            }

            /*if (playerOne.MyTurn == true)
            {
                playerOne.MyTurn = false;
                playerTwo.MyTurn = true;
                
            }
            else if (playerOne.MyTurn == false)
            {
                playerTwo.MyTurn = false;
                playerTwo.MyTurn = true;
                
            }*/
        }

        
        /* ********** INITIATE GAME BELOW ********************** */

       public void PrintBoard()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {

                }
                Console.WriteLine("        " + '\u2502' + i);

            }
            Console.Write('\u2500');
            Console.Write('\u2500'); 
            Console.Write('\u2500'); 
            Console.Write('\u2500'); 
            Console.Write('\u2500');
            Console.Write('\u2500');
            Console.Write('\u2500');
            Console.Write('\u2500');
            Console.Write('\u2518');
            Console.WriteLine();
            Console.WriteLine("01234567");
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

       
        /* ################### INITATE GAME END ########################## */

/* ********************** START GAME BELOW ************************** */

 
        private bool MatchCoordinate(int x, int y, int newX, int newY)
        {
            if (x == newX && y == newY)
            {
                return true;
            }
            return false;
        }
    }
}
