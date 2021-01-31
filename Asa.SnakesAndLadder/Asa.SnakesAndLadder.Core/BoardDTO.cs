using System;
using System.Collections.Generic;
using System.Text;

namespace Asa.SnakesAndLadder.Core
{
	class BoardDTO
	{
		public int Height { get; set; }
		public int Width { get; set; }
		public IEnumerable<ShortCut> Snakes { get; set; }
		public IEnumerable<ShortCut> Ladders { get; set; }
	}
}
