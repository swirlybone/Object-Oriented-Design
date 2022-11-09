using System;

namespace TextBasedVentures
{
    class Program
    {
        public static Hero currentPlayer = new Hero();
        
        static void Main(string[] args)
        {
            //debug purposes, but can say what version of the game its in
            Console.WriteLine("Ventures in Morioh-Cho v1.0.1. Patch Where Bugs Were Smashed By The Iron Fist.");
            //Console.WriteLine("A Staff & Shield game.");
            Game game = new Game();
            game.start();
            game.play();
            game.end();
        }
    }
}
