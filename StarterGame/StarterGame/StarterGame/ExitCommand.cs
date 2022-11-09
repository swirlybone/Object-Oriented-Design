using System;

namespace StarterGame
{
	public class ExitCommand : Command
	{
		public ExitCommand()
		{
			name = "exit";
		}
        override
        public bool execute(Player player)
        {
            if (!this.hasSecondWord())
            {
                player.exit();
            }
            else
            {
                player.warningMessage("\nExit?" +secondWord + "???");
            }
            return false;
        }
    }
}

