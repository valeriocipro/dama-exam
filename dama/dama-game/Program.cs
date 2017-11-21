using System;
using System.Threading;

namespace dama_game
{
    class Program
    {
        static void Main(string[] args)
        {
            Opponent cr = new Opponent();
            int x, y;

            //creazione p1
            Console.WriteLine("Creating player 1...\n");
            Thread.Sleep(750);
            y = crPlayer();
            var p1 = cr.Opp(y);

            //creazione p2
            Console.WriteLine("\n\nCreating player 2...");
            Thread.Sleep(750);
            x = crPlayer();
            var p2 = cr.Opp(x);

            Console.WriteLine("\n"+p1.Name +" VS "+ p2.Name);
            Console.ReadLine();

            IPlayer toMove = p1;

            int xs, ys, xe, ye;
            var b = new Chessboard(p1, p2);
            do
            {
                try{
                    Console.Clear();
                Console.WriteLine(b.ToString());

                Console.WriteLine("Turn: {0}", toMove.Name);

                Console.WriteLine("Let move from...");
                Console.Write("V:");
                xs = int.Parse(Console.ReadLine());
                Console.WriteLine();
                Console.Write("H:");
                ys = int.Parse(Console.ReadLine());

                Console.WriteLine("Let move to...");
                Console.Write("V:");
                xe = int.Parse(Console.ReadLine());
                Console.WriteLine();
                Console.Write("H:");
                ye = int.Parse(Console.ReadLine());

                b.MovePawn(toMove, xs, ys, xe, ye);

                if (toMove == p1)
                    toMove = p2;
                else
                    toMove = p1;
                }catch(Exception e){
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Press to continue...");
                    Console.ReadLine();
                }

            } while (b.Winner == null);

            Console.WriteLine("Press to simulate legal move (5,1) -> (4,2)...");
            Console.ReadLine();

            b.MovePawn(p2, 5, 1, 4, 2);

            Console.WriteLine(b.ToString());

            Console.WriteLine("Press to simulate play...");
            Console.ReadLine();

            b.SimulatePlay();

            Console.WriteLine("Winner is {0} with score {1}", b.Winner.Name, b.Winner.Score);
            Console.WriteLine("Loser is {0} with score {1}", b.Loser.Name, b.Loser.Score);
        }

        public static int crPlayer()
        {
            int y;
            bool k = false;

            Console.WriteLine("Select difficulty: 1(Easy), 2(Medium), 3(Hard) or a random number to select a real player.");
            Thread.Sleep(750);
            do
            {
                if (!(k = int.TryParse(Console.ReadLine(), out y)))
                    Console.WriteLine("Wrong input, retry.");
            } while (!k);

            return y;
        }
    }
}
