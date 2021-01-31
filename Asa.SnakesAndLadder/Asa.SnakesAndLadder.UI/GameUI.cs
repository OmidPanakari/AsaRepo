using Asa.SnakesAndLadder.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asa.SnakesAndLadder.UI
{
    class GameUI
    {
        GameController _gameController;

        private void ReadPlayersData()
        {
            Console.WriteLine("Enter number of players:");
            int playerCount = Convert.ToInt32(Console.ReadLine());
            _gameController.CheckPlayerCount(playerCount);
        }

        private void ReadGameData()
        {
            Console.WriteLine("Enter board width:");
            int width = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter board height:");
            int height = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter number of ladders:");
            int ladderCount = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter number of snakes:");
            int snakeCount = Convert.ToInt32(Console.ReadLine());
            _gameController = new GameController(width, height, ladderCount, snakeCount);
        }

        internal void Start()
        {
            ReadGameData();
            ReadPlayersData();
            Play();
        }

        private void Play()
        {
            MoveResult result;
            do
            {
                Console.Clear();
                PlayerDTO currentPlayer = _gameController.GetCurrentPlayer();
                Console.WriteLine($"Player {currentPlayer.Name} with color {currentPlayer.Color}.");
                Console.Write("Press Enter to play ");
                while (Console.ReadKey(true).Key != ConsoleKey.Enter) ;
                result = _gameController.PlayeTurn();
                ShowResult(result);
                Console.Write("Press Enter to continue...");
                while (Console.ReadKey(true).Key != ConsoleKey.Enter) ;
            } while (!result.IsWinner);
        }

        private void ShowResult(MoveResult result)
        {
            throw new NotImplementedException();
        }
    }
}
