using System;
namespace ChessVer2
{
    interface IPlayer
    {
        System.Collections.Generic.List<string> Coordinates { get; set; }
        string Name { get; set; }
        int PosX { get; set; }
        int PosY { get; set; }
        System.Collections.Generic.List<System.Collections.Generic.List<string>> TurnAvailableMoves { get; set; }
    }
}
