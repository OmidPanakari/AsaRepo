using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Asa.SnakesAndLadder.Core;

namespace Asa.SnakesAndLadder.Tests
{
	public class GameEngineTest
	{
		[SetUp]
		public void SetUp()
		{

		}

		[Test]
		public void ErrorIfDuplicateName()
		{
			var game = new GameEngine(5, 5, 3, 4);
			game.AddPlayer("Omid", PlayerColor.Blue);
			Assert.Throws<InvalidOperationException>(() => game.AddPlayer("Omid", PlayerColor.Green));
		}

		[Test]
		public void ErrorIfDuplicateColor()
		{
			var game = new GameEngine(5, 5, 3, 4);
			game.AddPlayer("Omid", PlayerColor.Blue);
			Assert.Throws<InvalidOperationException>(() => game.AddPlayer("Ali", PlayerColor.Blue));
		}

		[Test]
		public void ErrorIfMoreThan4Player()
		{
			var game = new GameEngine(5, 5, 3, 4);
			game.AddPlayer("Omid", PlayerColor.Blue);
			game.AddPlayer("Ali", PlayerColor.Green);
			game.AddPlayer("Hamed", PlayerColor.Red);
			game.AddPlayer("Mahdi", PlayerColor.Yellow);
			Assert.Throws<InvalidOperationException>(() => game.AddPlayer("Hossein", PlayerColor.Purple));
		}


	}
}
