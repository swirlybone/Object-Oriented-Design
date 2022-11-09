using System.Collections;
using System.Collections.Generic;
using System;

namespace StarterGame
{
	public class Game
	{
		Player player;
		Parser parser;
		bool playing;

		//command design
		Queue<Command> commandQueue;


		public Game()
		{
			playing = false;
			parser = new Parser(new CommandWords());
			player = new Player(GameWorld.Instance.Lobby);
			Dictionary<string, object> userInfo = new Dictionary<string, object>();
			userInfo["state"] = new ParserCharacterState();
			NotificationCenter.Instance.postNotification(new Notification("PlayerWillEnterState", player, userInfo));
			commandQueue = new Queue<Command>();


			/*
			//moves to parking deck from the start
			GoCommand gc = new GoCommand();
			gc.secondWord = "west";
			commandQueue.Enqueue(gc);
			gc = new GoCommand();
			gc.secondWord = "west";
			commandQueue.Enqueue(gc);
			gc = new GoCommand();
			gc.secondWord = "west";
			commandQueue.Enqueue(gc);
			gc = new GoCommand();
			gc.secondWord = "south";
			commandQueue.Enqueue(gc);

			*/
		}


		/**
	 *  Main play routine.  Loops until end of play.
	 */
		public void play()
		{

			// Enter the main command loop.  Here we repeatedly read commands and
			// execute them until the game is over.

			bool finished = false;
			while (!finished)
			{
				Console.Write("\n" + player.Name + ">");
				Command command = parser.parseCommand(Console.ReadLine());
				if (command == null)
				{
					player.warningMessage("I don't understand...");
				}
				else
				{
					finished = command.execute(player);
				}
			}
		}


		public void start()
		{
			playing = true;
			player.informationMessage(welcome());
			processCommandQueue();
		}

		public void end()
		{
			playing = false;
			player.informationMessage(goodbye());
		}

		public string welcome()
		{
			return "Welcome to the World of CSU!\n\n The World of CSU is a new, incredibly boring adventure game.\n\nType 'help' if you need help." + player.currentRoom.description();
			
		}

		public string goodbye()
		{
			return "\nThank you for playing, Goodbye. \n";
		}

		public void processCommandQueue()
		{
			while(commandQueue.Count > 0)
			{
				Command command = commandQueue.Dequeue();
				player.outputMessage(">" + command);
				command.execute(player);
			}
		}

	}
}
