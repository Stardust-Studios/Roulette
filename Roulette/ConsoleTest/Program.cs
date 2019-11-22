using System;
using System.Collections.Generic;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> players = new List<string>(new string[] { "Sam", "Ethan", "Nate", "David", "Ken" });
            Roulette(players);
            Console.ReadKey();
        }
        private static string Roulette(List<string> players)
        {
            Random rng = new Random();
            int roundCount = 1;
            int index = 0;
            int bullet = rng.Next(6);
            string dead = "";
            while (true)
            {
                Console.Write("Round {0}: ", roundCount);
                PrintStringList(players);

                if (index == players.Count - 1) index = 0;
                else index++;

                if (bullet == 0)
                {
                    dead = players[index];
                    players.RemoveAt(index);
                    Console.WriteLine("{0} died!", dead);
                    bullet = rng.Next(7);
                    if (index == 0) index = -1;
                    else index -= 2;
                    if (players.Count == 1)
                    {
                        Console.WriteLine("{0} wins!", players[0]);
                        return players[0];
                    }
                }
                else
                {
                    Console.WriteLine("Everyone is alive!");
                    bullet--;
                }

                roundCount++;
                Console.WriteLine();
            }
        }
        private static void PrintStringList(List<string> list)
        {
            foreach (string value in list)
            {
                if (value == list[list.Count - 1]) Console.Write(value);
                else Console.Write(value + "\t");
            }
            Console.WriteLine();
        }
    }
}
