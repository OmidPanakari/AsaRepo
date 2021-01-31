using System;
using System.Collections.Generic;
using System.Text;

namespace Asa.SnakesAndLadder.Core
{
	public class ShortCut
	{
		public ShortCut(int start, int end)
		{
			Start = start;
			End = end;
		}
		public int Start { get; }
		public int End { get; }

	}
}
