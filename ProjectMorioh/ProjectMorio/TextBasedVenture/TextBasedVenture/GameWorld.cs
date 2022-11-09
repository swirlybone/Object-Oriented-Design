using System;

namespace TextBasedVentures
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
		//private Room _fromRoom;
		//private Room _toRoom;
		private Room _lobby;
		private Room _battletrigger;
		private Room _victorytrigger;
		public Room Battle
		{
			get
			{
				return _trigger;
			}
		}
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
			NotificationCenter.Instance.addObserver("EndGame", EndGame);

			//NotificationCenter.Instance.addObserver("PlayerDidEnterRoom", PlayerWillEnterRoom);
		}

		//ending notification
		public void EndGame(Notification notification)
		{
			Player player = (Player)notification.Object;
			Room room = player.currentRoom;
			if (room == _victorytrigger)
			{
				player.informationMessage("*** You Win! ***");
			}

		}

		/*
		public void PlayerWillEnterRoom(Notification notification)
		{
			Player player = (Player)notification.Object;
			Room room = player.currentRoom;
			if(room == _trigger){
				player.debugMessage("*** The world has changed. ***");
				//New room added, connects a room when trigger room is reached.
				_fromRoom.setExit("west", _toRoom);
				_toRoom.setExit("east", _fromRoom);
			}

			//Statement to print current room
			//Console.WriteLine("The player is now " + player.currentRoom.tag);


		}
		*/
		

		private void createWorld()
		{
			Room mainRoom = new Room("at the main door of the Morioh Mansion");
			Room mainHall = new Room("in the Morioh Mansion main hall");
			Room diningHall = new Room("in the Morioh Mansion dining hall");
			Room kitchen = new Room("in the Morioh Mansion kitchen");
			Room bathRoom = new Room("in the bathroom");
			Room masterRoom = new Room("in the head of the Higashikata Family's Bed Room");
			Room library = new Room("in the Morioh Mansion Library");
			Room storage = new Room("in the Morioh Mansion storage room");
			Room attic = new Room("i the attic");
			Room cellar = new Room("in the Morioh Mansion wine cellar");
			Room trophyRoom = new Room("in the Higashikata-Joestar family Trophy Room");
			Room studyRoom = new Room("in the Morioh Mansion Study room");
			Room lobby = new Room("in the lobby. Use command name to set a name, then when done say 'done'");

			//Exit room leading to victory
			Room outside = new Room("outside of the Morioh Mansion");
			

			//New Room routes
			//connects a room to a door
			Door door = Door.MakeDoor(mainHall,mainRoom, "south","north" );
			door.close();
			//Room routes
			door = Door.MakeDoor(outside, mainRoom, "", "out");
			door.keyclose();
			door = Door.MakeDoor(studyRoom, mainRoom, "west", "east");
			door = Door.MakeDoor(diningHall, mainHall, "south", "north");
			door = Door.MakeDoor(bathRoom, mainHall, "east", "west");
			door = Door.MakeDoor(masterRoom, mainHall, "west", "east");
			door = Door.MakeDoor(kitchen, diningHall, "south", "north");
			door = Door.MakeDoor(diningHall, cellar, "down", "up");
			door = Door.MakeDoor(diningHall, storage, "west", "east");
			door = Door.MakeDoor(library, diningHall, "west", "east");
			door = Door.MakeDoor(attic, library, "down", "up");
			door = Door.MakeDoor(trophyRoom, storage, "west", "east");
			door = Door.MakeDoor(trophyRoom, library, "north", "south");


			

			
			
			

			//Special rooms, assignments to special rooms
			_entrance = mainHall;
			_lobby = lobby;
			_trigger = mainRoom;
			//_victorytrigger = outside;

			TrapRoom tRoom = new TrapRoom();
			library.Delegate = tRoom;

			RiddleRoom rRoom = new RiddleRoom();
			kitchen.Delegate = rRoom;

			RiddleRoom2 rRoom2 = new RiddleRoom2();
			trophyRoom.Delegate = rRoom2;

			RiddleRoom3 rRoom3 = new RiddleRoom3();
			masterRoom.Delegate = rRoom3;

			RiddleRoom4 rRoom4 = new RiddleRoom4();
			studyRoom.Delegate = rRoom4;

			EndRoom eRoom = new EndRoom();
			outside.Delegate = eRoom;

			cellar.Delegate = new EchoRoom();
			//mainHall.Delegate = new Battle();

			

			//Place items
			Item item = new Item();
			item.Name = "crown";
			item.Weight = 0.5f;
			item.BuyValue = 50f;
			item.SellValue = 30f;
			item.Volume = 1f;
			mainHall.drop(item);

			Item item5 = new Item();
			item5.Name = "shinyrock";
			item5.Weight = 9f;
			item5.BuyValue = 50f;
			item5.SellValue = 30f;
			item5.Volume = 1f;
			mainHall.drop(item5);

			Item item6 = new Item();
			item6.Name = "seal";
			item6.Weight = 3f;
			item6.BuyValue = 50f;
			item6.SellValue = 30f;
			item6.Volume = 1f;
			mainHall.drop(item6);

			Item item7 = new Item();
			item7.Name = "wine";
			item7.Weight = .5f;
			item7.BuyValue = 50f;
			item7.SellValue = 30f;
			item7.Volume = 1f;
			cellar.drop(item7);

			Item item8 = new Item();
			item8.Name = "horn";
			item8.Weight = .3f;
			item8.BuyValue = 50f;
			item8.SellValue = 30f;
			item8.Volume = .2f;
			attic.drop(item8);

			Item item9 = new Item();
			item9.Name = "spork";
			item9.Weight = .1f;
			item9.BuyValue = 50f;
			item9.SellValue = 30f;
			item9.Volume = .1f;
			bathRoom.drop(item8);

			Item item10 = new Item();
			item10.Name = "cayde6";
			item10.Weight = 300f;
			item10.BuyValue = 5000000f;
			item8.SellValue = 300000000f;
			item8.Volume = 777f;
			library.drop(item8);


			Item item2 = new Item();
			item2.Name = "sofa";
			item2.Weight = 200f;
			item2.BuyValue = 50f;
			item2.SellValue = 30f;
			item2.Volume = 100f;
			mainRoom.drop(item2);

			Item item3 = new Item();
			item3.Name = "tv";
			item3.Weight = 100f;
			item3.BuyValue = 50f;
			item3.SellValue = 30f;
			item3.Volume = 100f;
			mainHall.drop(item3);

			Item item4 = new Item();
			item2.Name = "diamond";
			item2.Weight = 5f;
			item2.BuyValue = 500f;
			item2.SellValue = 350f;
			item2.Volume = 1f;
			mainRoom.drop(item2);

			//ItemContainer chest = new ItemContainer();
			//hest.Name = "chest";
			//Item other = new Item();
			//other.Name = "gem";
			//other.Weight = 0.5f;
			//chest.put(other);
			//mainHall.drop(chest);

			//Item item2 = new Item();
			//item.Name = "tree";
			//mainHall.drop(item);

			//key needed to beat the game
			//Item key = new Item();
			//item.Name = "key";
			//attic.drop(item);

			//UItem tree = new UItem();
			//tree.Name = "tree";
			//mainHall.drop(tree);


			IItem gold = new Item("gold", 0.1f, 30f, 30f, 0.5f);
			IItem relic = new Item("relic", 0.1f, 50f, 50f, 0.7f);

			IItem goldenhancer = new Item("enhance", 0.7f, 10f, 15f, 0.5f);
			//IItem emerald = new Item("emerald", 0.5f, 6f, 9f);
			//IItem diamond = new Item("diamond", 0.6f, 9f, 12f);

			gold.AddDecorator(goldenhancer);
			//diamond.AddDecorator();
			//mace.AddDecorator(diamond);

			trophyRoom.drop(relic);
			kitchen.drop(gold);
		}


	}
}
