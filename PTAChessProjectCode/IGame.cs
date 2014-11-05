using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTAChessProjectCode
{
    class IGame
    {

        internal void PrintGameBoard()
        {
            Console.Clear();
            
           Console.BackgroundColor = ConsoleColor.DarkGray;
            for (int y = 7; y >= 0; y--)
            {
                Console.Write("        ║" +y);
                
                Console.WriteLine();
            }
            Console.WriteLine(@"════════
abcdefgh");
            Console.ReadLine();
        }

        internal void PrintPieces(List<ChessPiece> whitePieces, List<ChessPiece> blackPieces)
        {
            Console.ForegroundColor = ConsoleColor.White;

            foreach (var piece in whitePieces)
            {
                System.Threading.Thread.Sleep(1);
                Console.SetCursorPosition(piece.PositionX, piece.PositionY);
                Console.Write(piece.Name);
            }
           Console.ForegroundColor = ConsoleColor.Black;

            foreach (var piece in blackPieces)
            {
                System.Threading.Thread.Sleep(1);
                Console.SetCursorPosition(piece.PositionX, piece.PositionY);
                Console.Write(piece.Name);
            }
          //  Console.ForegroundColor = ConsoleColor.White;
            
        }
    }
}
