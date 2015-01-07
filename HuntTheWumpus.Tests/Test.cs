using NUnit.Framework;
using System;
using HuntTheWumpus.Game;

namespace HuntTheWumpus.Tests
{
	[TestFixture ()]
	public class WumpusTests
	{
		[Test ()]
		public void GivenPlayerNotInCaveWhenCurrentRoomRequestedThenNotifyNotInCave ()
		{
			WumpusGame game = new WumpusGame ();
			Assert.AreEqual (0, game.PlayerRoom);
		}

		[Test()]
		public void GivenPlayerNotInRoomWhenRoomAssignedThenRoomReturnedWhenRequested()
		{
			WumpusGame game = new WumpusGame();
			game.PlayerRoom = 5;
			Assert.AreEqual (5, game.PlayerRoom);
		}

		[Test ()]
		public void GivenPlayerInRoomWhenMoveNorthThenInNorthernConnectedRoom()
		{
			WumpusGame game = new WumpusGame ();
			game.ConnectRoomToNorth (9, 8);
			game.PlayerRoom = 9;
			game.MovePlayerNorth ();
			int room = game.PlayerRoom;
			Assert.AreEqual (8, room);
		}

		[Test ()]
		public void TestWumpusIsInRoom()
		{
			var game = new WumpusGame ();
			game.WumpusRoom = 4;
			Assert.AreEqual (4, game.WumpusRoom);
		}

		[Test ()]
		public void TestRoomHasBloodWhenPlayerWithinTwoRoomsOfWumpus()
		{
			var game = new WumpusGame ();
			AddAllRoomsToGame (game);
			game.WumpusRoom = 14;
			Assert.AreEqual (false, game.RoomHasBlood (1));
		}

		private void AddRoomAndConnections(WumpusGame game, int fromRoom, int eastRoom, int southRoom, int westRoom, int northRoom)
		{
			game.ConnectRoomToEast (fromRoom, eastRoom);
			game.ConnectRoomToWest (fromRoom, westRoom);
			game.ConnectRoomToNorth (fromRoom, northRoom);
			game.ConnectRoomToSouth (fromRoom, southRoom);
		}

		private void AddAllRoomsToGame(WumpusGame game)
		{
			AddRoomAndConnections (game, 1, 2, 6, 5, 33);
			AddRoomAndConnections (game, 2, 3, 6, 1, 34);
			AddRoomAndConnections (game, 3, 35, 7, 2, 35);
			AddRoomAndConnections (game, 4, 5, 10, 36, 36);
			AddRoomAndConnections (game, 5, 1, 11, 4, 33);
			AddRoomAndConnections (game, 6, 2, 12, 11, 1);
			AddRoomAndConnections (game, 7, 8, 14, 13, 3);
			AddRoomAndConnections (game, 8, 9, 15, 7, 9);
			AddRoomAndConnections (game, 9, 10, 16, 8, 8);
			AddRoomAndConnections (game, 10, 4, 17, 9, 35);
			AddRoomAndConnections (game, 11, 6, 19, 18, 5);
			AddRoomAndConnections (game, 12, 13, 20, 19, 6);
			AddRoomAndConnections (game, 13, 14, 21, 12, 7);
			AddRoomAndConnections (game, 14, 15, 22, 13, 7);
			AddRoomAndConnections (game, 15, 16, 23, 14, 8);
			AddRoomAndConnections (game, 16, 17, 24, 15, 9);
			AddRoomAndConnections (game, 17, 18, 25, 16, 10);
			AddRoomAndConnections (game, 18, 19, 26, 17, 11);
			AddRoomAndConnections (game, 19, 12, 27, 18, 11);
			AddRoomAndConnections (game, 20, 21, 28, 27, 12);
			AddRoomAndConnections (game, 21, 22, 29, 20, 13);
			AddRoomAndConnections (game, 22, 23, 29, 21, 14);
			AddRoomAndConnections (game, 23, 24, 30, 22, 15);
			AddRoomAndConnections (game, 24, 25, 30, 23, 16);
			AddRoomAndConnections (game, 25, 26, 31, 24, 17);
			AddRoomAndConnections (game, 26, 27, 32, 25, 18);
			AddRoomAndConnections (game, 27, 20, 32, 26, 19);
			AddRoomAndConnections (game, 28, 29, 33, 32, 20);
			AddRoomAndConnections (game, 29, 22, 34, 28, 21);
			AddRoomAndConnections (game, 30, 31, 36, 23, 24);
			AddRoomAndConnections (game, 31, 32, 36, 30, 25);
			AddRoomAndConnections (game, 32, 27, 28, 31, 26);
			AddRoomAndConnections (game, 33, 34, 1, 5, 28);
			AddRoomAndConnections (game, 34, 35, 2, 33, 29);
			AddRoomAndConnections (game, 35, 3, 3, 34, 10);
			AddRoomAndConnections (game, 36, 4, 4, 30, 31);
		}

		public void BrianTestMethod()
		{
		}
	}
}

