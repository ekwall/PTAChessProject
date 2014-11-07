using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessVer2
{
    class MoveData
    {
        private Player PlayerToMove { get; set; }
        private Player PlayerNotToMove { get; set; }
        //private List<ChessPiece> EnemyPlayerPieces { get; set; }
        public List<ChessPiece> PieceThatCanMove { get; set; }
        public List<ChessPiece> PieceThatCanKill { get; set; }

        public List<ChessPiece> EnemyPiecePosition { get; set; }
        public List<string> AllMoves { get; set; }
        
        public MoveData(Player playerToMove, Player playerNotToMove)
        {
            this.PlayerToMove = playerToMove;
            this.PlayerNotToMove = playerNotToMove;
            this.EnemyPiecePosition = playerNotToMove.PieceList;
            AllMoves = new List<string>();
            PieceThatCanMove = new List<ChessPiece>();
            PieceThatCanKill = new List<ChessPiece>();
        }

        public void MakeMove(Player playerToMove)
        {
            SetNewPlayerToMakeMove(playerToMove);
            
            PlayerMakeMove(PlayerToMove);
        }

        private void SetNewPlayerToMakeMove(Player playerToMove)
        {
            this.PlayerToMove = playerToMove;
        }

        public void PlayerMakeMove(Player PlayerToMove)
        {
            ClearTempLists(PieceThatCanMove);
            ClearTempLists(PieceThatCanKill);
            CalculatePieceMovement(PlayerToMove.PieceList);
            ChessPiece pieceToMove = PickPiece(PieceThatCanMove);
            string Coordinates = GetCoordinates(pieceToMove);
            MovePiece(pieceToMove, Coordinates);
        }

        //De pjäser som inte kan rör sig tas bort ur listan PieceThatCanMove, har testkört och sett att det fungerar. 
        //Endast de pjäser som fortfarande har drag kvar återstår i listan.
        private void ClearTempLists(List<ChessPiece> PieceThatCanMove)
        {
            PieceThatCanMove.Clear();
        }

        private void CalculatePieceMovement(List<ChessPiece> PieceList)
        {
            foreach (var piece in PlayerToMove.PieceList)
            {
                piece.TurnAvailableMoves = new List<List<string>>();
                List<string> coordinates = new List<string>();



                foreach (var directions in piece.Coordinates)
                {
                    /*movestried++;
                    Console.SetCursorPosition(20, 14);
                    Console.WriteLine("Calculated {0} move options", movestried);*/

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

                    for (int i = 0; i < pieceMovementLength; i++)
                    {
                        outOfBounds = CheckIfOutOfBounds(currentX, currentY, addX, addY);
                        friendlyAhead = CheckIfFriendlyAhead(currentX, currentY, addX, addY, PieceList);

                        // Om inte pjäsen går out of bounds, OCH det inte finns en friendly pjäs framför...
                        //Lägg till steget till Listan av möjliga rörelser. 
                        if (!outOfBounds && !friendlyAhead)
                        {

                            if (enemyAhead)
                            {

                                PieceThatCanKill.Add(piece);


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

        public bool CheckIfOutOfBounds(int currentX, int currentY, int newX, int newY)
        {
            if (currentX + newX > -1 && currentX + newX < 8 && currentY + newY > -1 && currentY + newY < 8)
            {
                return false;
            }
            /*OOBCounter++;
            Console.SetCursorPosition(20, 18);
            Console.WriteLine("Out Of Bounds tries {0}", OOBCounter);*/
            return true;
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
                    /*count++;
                    Console.SetCursorPosition(20, 16);
                    Console.WriteLine("Friendly piece in the way {0} times", count);
                    System.Threading.Thread.Sleep(100);*/
                    return true;
                }
            }
            return false;
        }

        public ChessPiece PickPiece(List<ChessPiece> pieces)
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

        public int GetRandomNumber(List<string> coords)
        {
            Random rnd = new Random();
            int max = coords.Count + 1;
            int min = 1;
            int randomNumber = rnd.Next(min, max);
            return randomNumber - 1;
        }


        public int GetRandomNumber(List<ChessPiece> pieces)
        {
            Random rnd = new Random();
            int max = pieces.Count + 1;
            int min = 1;
            int randomNumber = rnd.Next(min, max);
            return randomNumber - 1;
        }

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
            pieceToMove.PosX = newX;
            pieceToMove.PosY = newY;

            Console.SetCursorPosition(pieceToMove.PosX, pieceToMove.PosY);
            Console.Write(pieceToMove.Name);
            System.Threading.Thread.Sleep(100);

            foreach (var piece in PlayerToMove.PieceList)
            {
                var tempx = piece.PosX;
                var tempy = piece.PosY;

                foreach (var item in PlayerToMove.PieceList)
                {
                    if (piece != item)
                    {
                        if (item.PosX == tempx && item.PosY == tempy)
                        {

                            /*countSameTile++;
                            Console.SetCursorPosition(20, 20);
                            Console.WriteLine("Same tile {0}.", countSameTile);
                            Console.ReadLine();*/
                            //System.Threading.Thread.Sleep(5000);
                        }
                    }
                }
            }

            foreach (var piece in PlayerToMove.PieceList)
            {
                piece.TurnAvailableMoves.Clear();
            }

        }
    }
}
