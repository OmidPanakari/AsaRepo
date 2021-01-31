using System;
using System.Collections.Generic;
using System.Text;

namespace Asa.SnakesAndLadder.Core
{
    public class MoveResult
    {
        public MoveResult()
        {
            IsWinner = false;
            IsBitten = false;
            IsLadderUsed = false;
            UsedShortCut = null;
        }
        public int DiceValue { get; set; }
        public int OldPosition { get; set; }
        public int NewPosition { get; set; }
        public string Name { get; set; }
        public PlayerColor Color { get; set; }
        public bool IsWinner { get; set; }
        public bool IsBitten { get; set; }
        public bool  IsLadderUsed { get; set; }
        public ShortCut UsedShortCut { get; set; }
    }
}
