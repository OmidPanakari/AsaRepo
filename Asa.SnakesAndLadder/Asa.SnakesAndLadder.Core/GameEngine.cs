using System;
using System.Collections.Generic;
using System.Linq;

namespace Asa.SnakesAndLadder.Core
{
	public class GameEngine
	{
        internal Player CurrentPlayer { get { return _players[_currentPlayer]; } }

        private List<Player> _players;
		private Board _board;

		public const int MAX_PLAYER_ALLOWED = 4;
		public const int MIN_PLAYER_ALLOWED = 2;

		private int _currentPlayer;

		public GameEngine(int width, int height, int ladderCount, int snakeCount)
		{
			_board = new Board(width, height, ladderCount, snakeCount);
			_players = new List<Player>();
		}

		public void AddPlayer(String name, PlayerColor color)
		{
			Player newPlayer = new Player(name, color);
			CheckPlayerValidation(newPlayer);
			_players.Add(newPlayer);
		}

		public void Start()
        {
			_currentPlayer = 0;
        }

        private void CheckPlayerValidation(Player newPlayer)
        {
            if(_players.Any(x => x == newPlayer))
            {
				throw new InvalidOperationException("Duplicate player name or color is not allowed.");
            }
			if(_players.Count == MAX_PLAYER_ALLOWED)
            {
				throw new InvalidOperationException($"Maximum number of players is {MAX_PLAYER_ALLOWED}.");
            }
        }

        internal MoveResult Play(int diceValue)
        {
			MoveResult result = _board.Move(CurrentPlayer.Position, diceValue);
			result.DiceValue = diceValue;
			result.Name = CurrentPlayer.Name;
			result.Color = CurrentPlayer.Color;
			CurrentPlayer.Position = result.NewPosition;
			if(result.IsBitten || result.IsLadderUsed)
			{
				CurrentPlayer.Position = result.UsedShortCut.End;
			}
			_currentPlayer = (_currentPlayer + 1) % _players.Count();
			return result;
        }
    }
}
