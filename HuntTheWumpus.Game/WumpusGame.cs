using System;
using System.Collections.Generic;
using System.Linq;

namespace HuntTheWumpus.Game
{
	public class WumpusGame
	{
		Dictionary<int, Dictionary<string, int>> _connections = new Dictionary<int, Dictionary<string, int>> ();
		List<int> _roomsWithBlood = new List<int>();
		readonly int _roomsWithBloodLevel = 2;
		private int _currentWumpusRoom = 0;

		public int PlayerRoom {	get; set; }
		public int WumpusRoom {	
			get{ return _currentWumpusRoom; }
			set
			{
				_currentWumpusRoom = value;
				_roomsWithBlood.Clear ();
				GetRoomsWithBlood (_currentWumpusRoom, _roomsWithBloodLevel);
			}
		}

		public void ConnectRoomToNorth(int fromRoom, int toRoom)
		{
			ConnectRooms (fromRoom, toRoom, "N");
		}

		public void ConnectRoomToEast(int fromRoom, int toRoom)
		{
			ConnectRooms (fromRoom, toRoom, "E");
		}

		public void ConnectRoomToSouth(int fromRoom, int toRoom)
		{
			ConnectRooms (fromRoom, toRoom, "S");
		}

		public void ConnectRoomToWest(int fromRoom, int toRoom)
		{
			ConnectRooms (fromRoom, toRoom, "W");
		}

		private void ConnectRooms(int fromRoom, int toRoom, string direction)
		{
			Dictionary<string, int> roomConnections = GetRoomConnectionsAndAddIfMissing (fromRoom);
			roomConnections.Add (direction, toRoom);
		}

		private Dictionary<string, int> GetRoomConnectionsAndAddIfMissing(int room)
		{
			Dictionary<string, int> roomConnections;
			if (!_connections.TryGetValue (room, out roomConnections)) {
				roomConnections = new Dictionary<string, int> ();
				_connections.Add (room, roomConnections);
			}
			return roomConnections;
		}

		public void MovePlayerNorth()
		{
			MovePlayer ("N");
		}

		public void MovePlayerEast()
		{
			MovePlayer ("E");
		}

		public void MovePlayerSouth()
		{
			MovePlayer ("S");
		}

		public void MovePlayerWest()
		{
			MovePlayer ("W");
		}

		private void MovePlayer(string direction)
		{
			Dictionary<string, int> roomConnections = GetRoomConnectionsAndAddIfMissing (PlayerRoom);
			int connectedRoom;
			roomConnections.TryGetValue (direction, out connectedRoom);
			PlayerRoom = connectedRoom;
		}

		public bool RoomHasBlood(int room)
		{
			foreach (var r in _roomsWithBlood) {
				if (r == room)
					return true;
			}
			return false;
		}

		private void GetRoomsWithBlood (int room, int connectionLevel)
		{
			var newConnecionLevel = connectionLevel - 1;
			Dictionary<string, int> roomConnections;
			if (_connections.TryGetValue (room, out roomConnections)) {
				foreach(var r in roomConnections.Values)
				{
					_roomsWithBlood.Add(r);
					if(newConnecionLevel > 0)
						GetRoomsWithBlood(room, newConnecionLevel);
				}
			}
		}
	}
}

