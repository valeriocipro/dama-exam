using System;

namespace dama_game
{
    class Program
    {
        static void Main(string[] args)
        {
            var p1 = new Player("Matteo");
            var p2 = new PlayerMediumComputer("CPU1");

            var b = new Chessboard(p1, p2);
            Console.WriteLine(b.ToString());

            Console.WriteLine("Press to simulate legal move (5,1) -> (4,2)...");
            Console.ReadLine();

            b.MovePawn(p2, 5,1,4,2);

            Console.WriteLine(b.ToString());

            Console.WriteLine("Press to simulate play...");
            Console.ReadLine();

            b.SimulatePlay();

            Console.WriteLine("Winner is {0} with score {1}", b.Winner.Name,b.Winner.Score);
            Console.WriteLine("Loser is {0} with score {1}", b.Loser.Name, b.Loser.Score);
        }
    }
}
