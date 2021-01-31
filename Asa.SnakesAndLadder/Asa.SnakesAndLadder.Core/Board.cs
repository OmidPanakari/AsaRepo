using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Asa.SnakesAndLadder.Core
{
	class Board
	{
        public int Width { get; }
        public int Height { get; }

        int _ladderCount;
        int _snakeCount;
        List<ShortCut> _ladders;
        List<ShortCut> _snakes;
        bool[] isOccupied;

        public Board(int width, int height, int ladderCount, int snakeCount)
        {
            Width = width;
            Height = height;
            _ladderCount = ladderCount;
            _snakeCount = snakeCount;
            CheckBoardValidation();
            isOccupied = new bool[Width * Height];
            AddShortCuts();
        }

        private void AddShortCuts()
        {
            AddSnakes();
            AddLadders();
        }

        private void AddLadders()
        {
            _ladders = new List<ShortCut>();
            for(int i = 0; i < _ladderCount; i++)
            {
                int first = GetEmptyPosition();
                isOccupied[first] = true;
                int second = GetEmptyPosition();
                isOccupied[second] = true;
                _ladders.Add(new ShortCut(Math.Min(first, second), Math.Max(first, second)));
            }
        }

        private void AddSnakes()
        {
            _snakes = new List<ShortCut>();
            for (int i = 0; i < _snakeCount; i++)
            {
                int first = GetEmptyPosition();
                isOccupied[first] = true;
                int second = GetEmptyPosition();
                isOccupied[second] = true;
                _snakes.Add(new ShortCut(Math.Max(first, second), Math.Min(first, second)));
            }
        }

        internal MoveResult Move(int position, int diceValue)
        {
            MoveResult result = new MoveResult();
            result.OldPosition = position;
            int nextPosition = Math.Min(position + diceValue, Width * Height);
            result.NewPosition = nextPosition;
            ShortCut ladder = FindLadder(nextPosition);
            if(ladder != null)
            {
                result.IsLadderUsed = true;
                result.UsedShortCut = ladder;
                nextPosition = ladder.End;
            }
            ShortCut snake = FindSnake(nextPosition);
            if (snake != null)
            {
                result.IsBitten = true;
                result.UsedShortCut = snake;
                nextPosition = snake.End;
            }
            if(nextPosition == Width * Height)
            {
                result.IsWinner = true;
            }
            return result;
        }

        private ShortCut FindSnake(int position)
        {
            foreach(ShortCut snake in _snakes)
            {
                if (snake.Start == position)
                    return snake;
            }
            return null;
        }

        private ShortCut FindLadder(int position)
        {
            foreach (ShortCut ladder in _ladders)
            {
                if (ladder.Start == position)
                    return ladder;
            }
            return null;
        }

        private int GetEmptyPosition()
        {
            int emptyCount = isOccupied.Where(x => !x).Count() - 1;
            Random r = new Random();
            int placeCount = r.Next(emptyCount) + 1;
            for(int i = 1; i < Width * Height; i++)
            {
                if (!isOccupied[i])
                    placeCount--;
                if (placeCount == 0)
                    return i;
            }
            throw new InvalidOperationException("It's not possible to find a new empty position.");
        }

        private void CheckBoardValidation()
        {
            if (Width * Height <= 1)
                throw new ArgumentOutOfRangeException("Invalid board size.");
            if (2 * (_ladderCount + _snakeCount) > Width * Height)
                throw new ArgumentOutOfRangeException("The size of the board and number of the ladders and snakes are not compatible.");
        }
    }
}
