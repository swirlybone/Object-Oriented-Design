using System.Collections;
using System.Collections.Generic;
using System;

namespace StarterGame
{

    public interface IRoomDelagate
    {
        //Room that contains delegate
        Room Container { get; set; }
        Door getExit(string exitName);
        string getExits();
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
            MagicWord = "magic";
            NotificationCenter.Instance.addObserver("PlayerWillSayWord", PlayerWillSayWord);
        }

        public string getExits()
        {
            return Container.getExits(this) + "\nYou are trapped in this room until you say the magic word.";
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
            return Container.getExits(this) + "\n<You are in an Echo Room.>\n";
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
                }
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

        }
        public void drop(IItem item)
        {
            itemContainer.put(item);

        }

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
                /*
                Room room = null;
                exits.TryGetValue(exitName, out room);
                return room;
                */
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
                /*
                string exitNames = "Exits: ";
                Dictionary<string, Room>.KeyCollection keys = exits.Keys;
                foreach (string exitName in keys)
                {
                    exitNames += " " + exitName;
                }

                return exitNames;
                */
            }
        }
        public string getExits(IRoomDelagate rDelegate)
        {
            if (rDelegate == Delegate)
            {
                string exitNames = "Exits:";
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
            return "You are " + this.tag + ".\n *** " + this.getExits() + "\n+++ " +this.getItems();
        }
    }
}
