using System.Collections;
using System.Collections.Generic;
using System;

namespace TextBasedVentures
{
    public interface IRoomDelagate
    {
        //Room that contains delegate
        Room Container { get; set; }
        Door getExit(string exitName);
        string getExits();
    }

    public class EndRoom : IRoomDelagate
    {
        public Room Container { get; set; }
        //public string MagicWord { set; get; }
        public Door getExit(string exitName)
        {
            return null;
        }

        public EndRoom()
        {

        }

        public string getExits()
        {
            return Container.getExits(this) + "\n*** You Win! ***"  + "\nMission Accomplished, you left the Morioh Mansion. You can type 'quit' to leave.";
        }

    }


    public class TrapRoom : IRoomDelagate
    {
        public Room Container { get; set; }
        public string MagicWord { set; get; }
        public Door getExit(string exitName)
        {
            //Every time you want to get an exit, it returns the container, the room you're in or room where IRoomDelegate is set
            return null;
        }
 
        public TrapRoom()
        {
            MagicWord = "pac-man";
            NotificationCenter.Instance.addObserver("PlayerWillSayWord", PlayerWillSayWord);
        }

        public string getExits()
        {
            return Container.getExits(this) + "\nYou are trapped in this room until you solve the puzzle.\n\nWho am I? I am an iconic staple in gaming, however overlooked in modern times." +
                "I run from ghost, however the fruit grant me strength to devour.";
        }
        public void PlayerWillSayWord(Notification notification)
        {
            Player player = (Player)notification.Object;
            if(player.currentRoom == Container)
            {
                string word = (string)notification.userInfo["word"];
                if(word != null)
                {
                    if(word.Equals(MagicWord))
                    {
                        player.informationMessage("\nThe trap is lifted.\n");
                        //Where the delegate removes itself, back to null.
                        Container.Delegate = null;
                    }
                }
            }
        }

    }

    public class RiddleRoom : IRoomDelagate
    {
        public Room Container { get; set; }
        public string MagicWord { set; get; }
        public Door getExit(string exitName)
        {
            //Every time you want to get an exit, it returns the container, the room you're in or room where IRoomDelegate is set
            return null;
        }

        public RiddleRoom()
        {
            MagicWord = "mario";
            NotificationCenter.Instance.addObserver("PlayerWillSayWord", PlayerWillSayWord);
        }

        public string getExits()
        {
            return Container.getExits(this) + "\nYou are trapped in this room until you solve the puzzle.\n\nWho am I? The princess is gone again and so my brother and I team" +
                " up once more to save her. I used to be a plumber til I fell in a green pipe. The mushrooms give me strength to grow.";
        }
        public void PlayerWillSayWord(Notification notification)
        {
            Player player = (Player)notification.Object;
            if (player.currentRoom == Container)
            {
                string word = (string)notification.userInfo["word"];
                if (word != null)
                {
                    if (word.Equals(MagicWord))
                    {
                        player.informationMessage("\nThe trap is lifted.\n");
                        //Where the delegate removes itself, back to null.
                        Container.Delegate = null;
                    }
                }
            }
        }

    }

    public class RiddleRoom2 : IRoomDelagate
    {
        public Room Container { get; set; }
        public string MagicWord { set; get; }
        public Door getExit(string exitName)
        {
            //Every time you want to get an exit, it returns the container, the room you're in or room where IRoomDelegate is set
            return null;
        }

        public RiddleRoom2()
        {
            MagicWord = "pokemon";
            NotificationCenter.Instance.addObserver("PlayerWillSayWord", PlayerWillSayWord);
        }

        public string getExits()
        {
            return Container.getExits(this) + "\nYou are trapped in this room until you solve the puzzle.\n\nWho am I? Once there were 151 of me to collect, but more iterations of me brought" +
                " many new creatures. With a ball you can control all of these monsters.";
        }
        public void PlayerWillSayWord(Notification notification)
        {
            Player player = (Player)notification.Object;
            if (player.currentRoom == Container)
            {
                string word = (string)notification.userInfo["word"];
                if (word != null)
                {
                    if (word.Equals(MagicWord))
                    {
                        player.informationMessage("\nThe trap is lifted.\n");
                        //Where the delegate removes itself, back to null.
                        Container.Delegate = null;
                    }
                }
            }
        }

    }

    public class RiddleRoom3 : IRoomDelagate
    {
        public Room Container { get; set; }
        public string MagicWord { set; get; }
        public Door getExit(string exitName)
        {
            //Every time you want to get an exit, it returns the container, the room you're in or room where IRoomDelegate is set
            return null;
        }

        public RiddleRoom3()
        {
            MagicWord = "sonic";
            NotificationCenter.Instance.addObserver("PlayerWillSayWord", PlayerWillSayWord);
        }

        public string getExits()
        {
            return Container.getExits(this) + "\nYou are trapped in this room until you solve the puzzle.\n\nWho am I? I'm blue and can travel at the speed of light" +
                " I get mistaken for a cat or porcupine.";
        }
        public void PlayerWillSayWord(Notification notification)
        {
            Player player = (Player)notification.Object;
            if (player.currentRoom == Container)
            {
                string word = (string)notification.userInfo["word"];
                if (word != null)
                {
                    if (word.Equals(MagicWord))
                    {
                        player.informationMessage("\nThe trap is lifted.\n");
                        //Where the delegate removes itself, back to null.
                        Container.Delegate = null;
                    }
                }
            }
        }

    }

    public class RiddleRoom4 : IRoomDelagate
    {
        public Room Container { get; set; }
        public string MagicWord { set; get; }
        public Door getExit(string exitName)
        {
            //Every time you want to get an exit, it returns the container, the room you're in or room where IRoomDelegate is set
            return null;
        }

        public RiddleRoom4()
        {
            MagicWord = "microsoft";
            NotificationCenter.Instance.addObserver("PlayerWillSayWord", PlayerWillSayWord);
        }

        public string getExits()
        {
            return Container.getExits(this) + "\nYou are trapped in this room until you solve the puzzle.\n\nWho am I? Once owned by Bill Gates, now someone else." +
                "I gave the world a game console with a X on it.";
        }
        public void PlayerWillSayWord(Notification notification)
        {
            Player player = (Player)notification.Object;
            if (player.currentRoom == Container)
            {
                string word = (string)notification.userInfo["word"];
                if (word != null)
                {
                    if (word.Equals(MagicWord))
                    {
                        player.informationMessage("\nThe trap is lifted.\n");
                        //Where the delegate removes itself, back to null.
                        Container.Delegate = null;
                    }
                }
            }
        }

    }





    //second delegate, a trap room that echoes
    public class EchoRoom : IRoomDelagate
    {
        public Room Container { get; set; }
        public EchoRoom()
        {
            NotificationCenter.Instance.addObserver("PlayerDidSayWord", PlayerDidSayWord);
        }
        public Door getExit(string exitName)
        {
            return Container.getExit(exitName, this);
        }
        public string getExits()
        {
            return Container.getExits(this) + "\nYou are in an echo room.\n";
        }
        public void PlayerDidSayWord(Notification notification)
        {
            Player player = (Player)notification.Object;
            if(player.currentRoom == Container)
            {
                string word = (string)notification.userInfo["word"];
                if(word !=null)
                {
                    player.informationMessage("... " + word + "... " + word + "..." + word);
                    player.informationMessage("get out...get out...GET OUT.");
                }
            }
        }
    }

    
    public class Battle : IRoomDelagate
    {
        public Room Container { get; set; }
        public Door getExit(string exitName)
        {
            //Encounters.FirstEncounter();
            //return Container.getExit(exitName, this);
            return null;
        }

        public string getExits()
        {
            Encounters.FirstEncounter();

            return Container.getExits(this) + "\n<Battle complete.>\n";
            
        }
        public void PlayerDidSayWord(Notification notification)
        {
            Player player = (Player)notification.Object;
            if (player.currentRoom == Container)
            {
                
            }
        }
    }

    public class Key : IRoomDelagate
    {
        public Room Container { get; set; }
        public Door getExit(string exitName)
        {
            
            return Container.getExit(exitName, this);
        }
        public string getExits()
        {
            //Encounters.FirstEncounter();

            return Container.getExits(this);
            
        }
        public void PlayerDidSayWord(Notification notification)
        {
            Player player = (Player)notification.Object;
            if (player.currentRoom == Container)
            {
               
            }
        }
    }


    public class Room
    {
        private Dictionary<string, Door> exits;
        private string _tag;
        public string tag
        {
            get
            {
                return _tag;
            }
            set
            {
                _tag = value;
            }
        }
        private IRoomDelagate _delegate;
        public IRoomDelagate Delegate
        {
            get
            {
                return _delegate;
            }
            set
            {
                _delegate = value;
                if(_delegate != null)
                {
                    _delegate.Container = this;
                }
            }
        }

        private IItemContainer itemContainer;
        //private IUItemContainer uitemContainer;

        public Room() : this("No Tag")
        {

        }
        //designated constructor
        public Room(string tag)
        {
            exits = new Dictionary<string, Door>();
            this.tag = tag;
            _delegate = null;
            itemContainer = new ItemContainer();
            //uitemContainer = new UItemContainer();

        }
        public void drop(IItem item)
        {
            itemContainer.put(item);

        }
        /*
        public void place(IUItem uitem)
        {
            uitemContainer.put(uitem);
        }
        */

        public IItem pickup(string itemName)
        {
            return itemContainer.remove(itemName);
        }

        public void setExit(string exitName, Door door)
        {
            exits[exitName] = door;
        }

        public string getItems()
        {
            return itemContainer.contents();
        }

        public Door getExit(string exitName)
        {
            if(_delegate != null)
            {
                return _delegate.getExit(exitName);
            }
            else
            {
                return getExit(exitName, null);
            }
        }
        
        public Door getExit(string exitName, IRoomDelagate rDelegate)
        {
            if(rDelegate == Delegate)
            {
                Door door = null;
                exits.TryGetValue(exitName, out door);
                return door;
            }
            else
            {
                return null;
            }
        }

        public string getExits()
        {
            if(_delegate != null)
            {
                return _delegate.getExits();
            }
            else
            {
                return getExits(null);
            }
        }
        public string getExits(IRoomDelagate rDelegate)
        {
            if (rDelegate == Delegate)
            {
                string exitNames = "Exit Doors:";
                Dictionary<string, Door>.KeyCollection keys = exits.Keys;
                foreach(string exitName in keys)
                {
                    exitNames += " " + exitName;
                }
                return exitNames;
            }
            else
            {
                return "???";
            }
        }

        public string description()
        {
            return "You are " + this.tag + ".\n " + this.getExits() + "\n " +this.getItems();
        }
    }

}
