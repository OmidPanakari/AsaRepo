using System;
using System.Collections.Generic;
using System.Text;

namespace Asa.SnakesAndLadder.Core
{
    public class GameController
    {
        GameEngine _gameEngine;
        public GameController(int width, int height, int ladderCount, int snakeCount)
        {
            _gameEngine = new GameEngine(width, height, ladderCount, snakeCount);
        }

        public void CheckPlayerCount(int playerCount)
        {
            if (playerCount < GameEngine.MIN_PLAYER_ALLOWED || playerCount > GameEngine.MAX_PLAYER_ALLOWED)
                throw new ArgumentOutOfRangeException($"Number of players should be between {GameEngine.MIN_PLAYER_ALLOWED} and {GameEngine.MAX_PLAYER_ALLOWED}.");
        }

        public PlayerDTO GetCurrentPlayer()
        {
            return _gameEngine.CurrentPlayer.GetData();
        }

        public void AddPlayer(string name, string colorName)
        {
            if (!Enum.TryParse(colorName, true, out PlayerColor color))
            {
                throw new ArgumentException($"{colorName} is not a valid color.");
            }
            _gameEngine.AddPlayer(name, color);
        }

        public MoveResult PlayeTurn()
        {
            return _gameEngine.Play();
        }
        public void Start()
		{
            _gameEngine.Start();
		}
    }
}
