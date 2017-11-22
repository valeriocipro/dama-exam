﻿using System;
using System.Collections.Generic;

namespace dama_game
{
    class Program
    {
        static void Main()
        {
            List<string> moveList = new List<string>();
            Opponent cr = new Opponent();
            int x, y;

            //creating p1
            Console.WriteLine("Creating player 1...\n");
            y = crPlayer();
            var p1 = cr.Opp(y);

            //creating p2
            Console.WriteLine("\n\nCreating player 2...");
            x = crPlayer();
            var p2 = cr.Opp(x);

            //changing names if they're equal
            if (p1.Name == p2.Name)
            {
                p1.Name += "(1)";
                p2.Name += "(2)";
            }

            Console.WriteLine("\n"+p1.Name +" VS "+ p2.Name);
            Console.WriteLine("Press any key to start");
            Console.ReadLine();

            IPlayer toMove = p1;
       
            int xs, ys, xe, ye;
            var b = new Chessboard(p1, p2);
            do
            {
                try{
                    Console.Clear();
                Console.WriteLine(b.ToString());

                   
                        if (toMove == p1)
                            Console.WriteLine("Turn: {0}", toMove.Name + " (W)");
                        else if (toMove == p2)
                            Console.WriteLine("Turn: {0}", toMove.Name + " (B)");
                    
                    

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
                   //adding each move to moves history
                    moveList.Add(toMove.Name+" moves from ("+xs+","+ys+") to ("+xe+","+ye+")");

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

            Console.Clear();
            Console.WriteLine(b.ToString());

            //running winning method
            won(b.Winner);


            Console.WriteLine("Press 1 to start a new game, 2 to print the history of the game, 0 to exit");
            int t = int.Parse(Console.ReadLine());
            Console.WriteLine();
            switch (t)
            {
                case 1:
                    Console.Clear();
                    // :) starting a new game :)
                    Main();
                    break;
                case 2:
                    for (int i = 0; i < moveList.Count; i++)
                        Console.WriteLine(moveList[i] + "\n");
                    break;
                case 0:
                    break;
                default:
                    break;
            }

            

            /*Console.WriteLine("Press to simulate legal move (5,1) -> (4,2)...");
            Console.ReadLine();

            b.MovePawn(p2, 5, 1, 4, 2);

            Console.WriteLine(b.ToString());

            Console.WriteLine("Press to simulate play...");
            Console.ReadLine();

            b.SimulatePlay();

            Console.WriteLine("Winner is {0} with score {1}", b.Winner.Name, b.Winner.Score);
            Console.WriteLine("Loser is {0} with score {1}", b.Loser.Name, b.Loser.Score);*/
        }

        public static int crPlayer()
        {
            int y;
            bool k = false;

            Console.WriteLine("Select difficulty: 1(Easy), 2(Medium), 3(Hard) or 0 to select a real player.");
            do
            {
                if (!(k = int.TryParse(Console.ReadLine(), out y)))
                    Console.WriteLine("Wrong input, retry.");
            } while (!k);

            return y;
        }

        public static void won(IPlayer p)
        {
            Console.WriteLine("\nCongratulations "+p.Name+"! You won the game!\n\n\n\n");
        }
    }
}
