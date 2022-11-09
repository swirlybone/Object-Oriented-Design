using System;

namespace TextBasedVentures
{
	public class WarpCommand : Command
	{

		public WarpCommand() : base()
		{
			this.name = "warp";
		}

		override
		public bool execute(Player player)
		{
			if (this.hasSecondWord())
			{
				player.outputMessage("\nI cannot warp to " + this.secondWord + "");
			}
			else
			{
				player.port();
			}
			return false;
		}
	}
}
