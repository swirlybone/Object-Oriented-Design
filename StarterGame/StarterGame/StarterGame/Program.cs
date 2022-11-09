using System;

namespace StarterGame
{
    class Program
    {
        static void Main(string[] args)
        {
            //debug purposes, but can say what version of the game its in
            //Console.WriteLine("Hello World!");
            Game game = new Game();
            game.start();
            game.play();
            game.end();
        }
    }
}
