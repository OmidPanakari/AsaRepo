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
    }
}
