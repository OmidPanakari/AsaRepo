using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Asa.SnakesAndLadder.Core;

namespace Asa.SnakesAndLadder.Tests
{
	public class GameControllerTest
	{
		[SetUp]
		public void SetUp()
		{

		}

		[Test]
		public void ErrorIfMoreThan4Players()
		{
			var game = new GameController(5, 5, 3, 4);
			Assert.Throws<ArgumentOutOfRangeException>(() => game.CheckPlayerCount(5));
		}

		[Test]
		public void ErrorIfLessThan2Players()
		{
			var game = new GameController(5, 5, 3, 4);
			Assert.Throws<ArgumentOutOfRangeException>(() => game.CheckPlayerCount(1));
		}

		[Test]
		public void ErrorIfWrongColor()
		{
			var game = new GameController(5, 5, 3, 4);
			Assert.Throws<ArgumentException>(() => game.AddPlayer("Omid", "Gray"));
		}
	}
}
