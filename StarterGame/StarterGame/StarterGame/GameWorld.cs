using System;

namespace StarterGame
{
	public class GameWorld
	{
		static private GameWorld _instance = null;
		static public GameWorld Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new GameWorld();
				}
				return _instance;
			}
		}

		
		private Room _entrance;
		//trigger room, designated trigger room/randomizer room
		private Room _trigger;
		private Room _fromRoom;
		private Room _toRoom;
		private Room _lobby;
		public Room Entrance
		{
			get
			{
				return _entrance;
			}
		}
		public Room Lobby
		{
			get
			{
				return _lobby;
			}
		}
		private GameWorld()
		{
			createWorld();
			NotificationCenter.Instance.addObserver("PlayerDidEnterRoom", PlayerWillEnterRoom);
		}

		public void PlayerWillEnterRoom(Notification notification)
		{
			Player player = (Player)notification.Object;
			Room room = player.currentRoom;
			if(room == _trigger){
				player.debugMessage("*** The world has changed. ***");
				//New room added, connects Davidson to Shuscter. Only occurs when reaching cct(trigger room)
				Door door = Door.MakeDoor(_fromRoom, _toRoom, "west", "east");
				//_fromRoom.setExit("west", _toRoom);
				//_toRoom.setExit("east", _fromRoom);
			}

			//Statement to print current room
			//Console.WriteLine("The player is now " + player.currentRoom.tag);


		}

		private void createWorld()
		{
			Room outside = new Room("outside the main entrance of the university");
			Room cctparking = new Room("in the parking lot at CCT");
			Room boulevard = new Room("on the boulevard");
			Room universityParking = new Room("in the parking lot at University Hall");
			Room parkingDeck = new Room("in the parking deck");
			Room cct = new Room("in the CCT building");
			Room theGreen = new Room("in the green in from of Schuster Center");
			Room universityHall = new Room("in University Hall");
			Room schuster = new Room("in the Schuster Center");
			Room davidson = new Room("in the Davidson Center");
			Room lobby = new Room("in the lobby. Use your commands to set up your character.");

			//outside.setExit("west", boulevard);
			//boulevard.setExit("east", outside);
			//connects a room to a door
			Door door = Door.MakeDoor(outside, boulevard, "west", "east");
			//outside.setExit("west", door);
			//boulevard.setExit("east", door);



			door = Door.MakeDoor(boulevard, cctparking, "south", "north");
			//boulevard.setExit("south", cctparking);
			//cctparking.setExit("north", boulevard);

			door = Door.MakeDoor(boulevard, theGreen, "west", "east");
			//boulevard.setExit("west", theGreen);
			//theGreen.setExit("east", boulevard);

			door = Door.MakeDoor(boulevard, universityParking, "north", "south");
			//boulevard.setExit("north", universityParking);
			//universityParking.setExit("south", boulevard);

			door = Door.MakeDoor(cctparking, cct, "west", "east");
			//cctparking.setExit("west", cct);
			//cct.setExit("east", cctparking);

			door = Door.MakeDoor(cct, schuster, "north", "south");
			//cct.setExit("north", schuster);
			//schuster.setExit("south", cct);

			door = Door.MakeDoor(schuster, universityHall, "north", "south");
			//schuster.setExit("north", universityHall);
			//universityHall.setExit("south", schuster);

			door = Door.MakeDoor(schuster, theGreen, "east", "west");
			//schuster.setExit("east", theGreen);
			//theGreen.setExit("west", schuster);

			door = Door.MakeDoor(universityHall, universityParking, "east", "west");
			//universityHall.setExit("east", universityParking);
			//universityParking.setExit("west", universityHall);

			door = Door.MakeDoor(universityParking, parkingDeck, "north", "south");
			//universityParking.setExit("north", parkingDeck);
			//parkingDeck.setExit("south", universityParking);

			door.close();
			

			// Make assignments to special rooms
			_entrance = outside;
			_trigger = cct;
			_fromRoom = schuster;
			_toRoom = davidson;
			_lobby = lobby;

			TrapRoom tRoom = new TrapRoom();
			parkingDeck.Delegate = tRoom;
			//tRoom.Container = parkingDeck;

			//Place items
			Item item = new Item();
			item.Name = "sword";
			item.Weight = 1.5f;
			parkingDeck.drop(item);

			ItemContainer chest = new ItemContainer();
			chest.Name = "chest";
			Item other = new Item();
			other.Name = "gem";
			other.Weight = 0.5f;
			chest.put(other);
			boulevard.drop(chest);

			

			IItem dagger1 = new Item("dagger1",0.1f, 0f, 0f);
			IItem dagger2 = new Item("dagger2", 0.1f, 0f, 0f);
			IItem dagger3 = new Item("dagger3", 0.1f, 0f, 0f);

			IItem gold = new Item("gold", 0.7f, 10f, 15f);
			IItem emerald = new Item("emerald", 0.5f, 6f, 9f);
			IItem diamond = new Item("diamond", 0.6f, 9f, 12f);

			dagger2.AddDecorator(gold);
			dagger3.AddDecorator(emerald);
			dagger3.AddDecorator(diamond);

			outside.drop(dagger1);
			outside.drop(dagger2);
			outside.drop(dagger3);
			universityHall.Delegate = new EchoRoom();
		}
	}
}
