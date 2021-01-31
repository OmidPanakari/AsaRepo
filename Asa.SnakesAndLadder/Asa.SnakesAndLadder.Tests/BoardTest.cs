using NUnit.Framework;
using Asa.SnakesAndLadder.Core;
using Asa.SnakesAndLadder.UI;
using System;

namespace Asa.SnakesAndLadder.Tests
{
	public class BoardTest
	{
		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public void ErrorIfMoreShortCutsThanPositions()
		{
			Assert.Throws<ArgumentOutOfRangeException>(() => new Board(4, 4, 4, 4));
		}
		
		[Test]
		public void ErrorIfLessThan2Positions()
		{
			Assert.Throws<ArgumentOutOfRangeException>(() => new Board(1, 1, 0, 0));
		}


	}
}