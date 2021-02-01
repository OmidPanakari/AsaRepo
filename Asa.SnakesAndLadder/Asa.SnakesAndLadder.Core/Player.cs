using System;
using System.Collections.Generic;
using System.Text;

namespace Asa.SnakesAndLadder.Core
{
	internal class Player
	{
		public PlayerColor Color { get; }
		public String Name { get; }
        public int Position { get; set; }
        public Player(string name, PlayerColor color)
		{
			Color = color;
			Name = name;
			Position = 0;
		}

        internal PlayerDTO GetData()
        {
			PlayerDTO playerDTO = new PlayerDTO();
			playerDTO.Name = Name;
			playerDTO.Color = Color;
			return playerDTO;
        }

        internal int RollDice()
        {
			Random r = new Random();
			return r.Next(6) + 1;
        }

		internal MoveResult Move(Board board)
		{
			int diceValue = RollDice();
			MoveResult result = board.Move(Position, diceValue);
			result.DiceValue = diceValue;
			result.Name = Name;
			result.Color = Color;
			Position = result.NewPosition;
			if (result.IsBitten || result.IsLadderUsed)
			{
				Position = result.UsedShortCut.End;
			}
			return result;
		}

		public override bool Equals(object obj)
		{
			if (obj is Player player)
				return Name == player.Name || Color == player.Color;
			else
				return false;
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(this);
		}

		public static bool operator ==(Player first, Player second)
		{
			return first.Equals(second);
		}

		public static bool operator !=(Player first, Player second)
		{
			return !first.Equals(second);
		}

	}
}
