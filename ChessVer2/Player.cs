using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessVer2
{
    public class Player
    {
        public List<ChessPiece> PieceList { get; set; }
        public bool IsWhite { get; set; }
        public Player()
        {
            PieceList = new List<ChessPiece>();
            AddWhitePiece("0,-1.1");
        }
        // Försök till att i en metod skapa nya pjäser.
        //public void CreateChessPiece(int x, int y, ChessPiece piece)
        //{
        //    piece = new Pawn(x, y);
        //    piece.id = 1;
        //    PieceList.Add(piece);
        //}
        public void CreateChessPiece(int x, int y, Rook rook)
        {

        }
        public void AddPieceToList(ChessPiece PiecetoAdd)
        {
            PieceList.Add(PiecetoAdd);
        }
        public void AddWhitePiece(string movement)
        {
            Pawn pawn = new Pawn(0, 6, movement);
            pawn.id = 1;
            PieceList.Add(pawn);

            Pawn pawn2 = new Pawn(1, 6, movement);
            pawn.id = 2;
            PieceList.Add(pawn2);

            Pawn pawn3 = new Pawn(2, 6, movement);
            pawn.id = 3;
            PieceList.Add(pawn3);

            Pawn pawn4 = new Pawn(3, 6, movement);
            pawn.id = 4;
            PieceList.Add(pawn4);

            Pawn pawn5 = new Pawn(4, 6, movement);
            pawn.id = 5;
            PieceList.Add(pawn5);

            Pawn pawn6 = new Pawn(5, 6, movement);
            pawn.id = 6;
            PieceList.Add(pawn6);

            Pawn pawn7 = new Pawn(6, 6, movement);
            pawn.id = 7;
            PieceList.Add(pawn7);

            Pawn pawn8 = new Pawn(7, 6, movement);
            pawn.id = 8;
            PieceList.Add(pawn8);

            Rook rook = new Rook(0,7);
            rook.id = 1;
            PieceList.Add(rook);

            Rook rook2 = new Rook(7,7);
            rook.id = 2;
            PieceList.Add(rook2);

            Knight knight = new Knight(1,7);
            knight.id = 1;
            PieceList.Add(knight);

            Knight knight2 = new Knight(6,7);
            knight.id = 2;
            PieceList.Add(knight2);

            Bishop bishop = new Bishop(2,7);
            bishop.id = 1;
            PieceList.Add(bishop);

            Bishop bishop1 = new Bishop(5,7);
            bishop1.id = 2;
            PieceList.Add(bishop1);

            King king = new King(4,7);
            PieceList.Add(king);

            Queen queen = new Queen(3,7);
            PieceList.Add(queen);

        }

       /* public void AddBlackPiece(string movement)
        {
            Pawn pawn = new Pawn(0, 1, movement);
            pawn.id = 1;
            PieceList.Add(pawn);

            Pawn pawn2 = new Pawn(1, 1, movement);
            pawn.id = 2;
            PieceList.Add(pawn2);

            Pawn pawn3 = new Pawn(2, 1, movement);
            pawn.id = 3;
            PieceList.Add(pawn3);

            Pawn pawn4 = new Pawn(3, 1, movement);
            pawn.id = 4;
            PieceList.Add(pawn4);

            Pawn pawn5 = new Pawn(4, 1, movement);
            pawn.id = 5;
            PieceList.Add(pawn5);

            Pawn pawn6 = new Pawn(5, 1, movement);
            pawn.id = 6;
            PieceList.Add(pawn6);

            Pawn pawn7 = new Pawn(6, 1, movement);
            pawn.id = 7;
            PieceList.Add(pawn7);

            Pawn pawn8 = new Pawn(7, 1, movement);
            pawn.id = 8;
            PieceList.Add(pawn8);

            Rook rook = new Rook(0, 0);
            rook.id = 1;
            PieceList.Add(rook);

            Rook rook2 = new Rook(7, 0);
            rook.id = 2;
            PieceList.Add(rook2);

            Knight knight = new Knight(1, 0);
            knight.id = 1;
            PieceList.Add(knight);

            Knight knight2 = new Knight(6, 0);
            knight.id = 2;
            PieceList.Add(knight2);

            Bishop bishop = new Bishop(2, 0);
            bishop.id = 1;
            PieceList.Add(bishop);

            Bishop bishop1 = new Bishop(5, 0);
            bishop1.id = 2;
            PieceList.Add(bishop1);

            King king = new King(4, 0);
            PieceList.Add(king);

            Queen queen = new Queen(3, 0);
            PieceList.Add(queen);

        }*/



        
    }
}
