using Reader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day14
{
    internal class Program
    {
        static void Main()
        {
            Reader.Reader.SetIn(14);

            int[,] map = new int[400,160];

            int start = 200;

            int MaxY = 0;
            int shift = 500 - start;

            string temp = Console.ReadLine();

            while (temp != null)
            {
                string[] input = temp.Replace(" -> ", " ").Split();

                for (int i = 0; i < input.Length - 1; i++)
                {
                    int[] xy1 = Array.ConvertAll(input[i].Split(','), s => int.Parse(s));
                    int[] xy2 = Array.ConvertAll(input[i+1].Split(','), s => int.Parse(s));

                    int x1 = Math.Min(xy1[0], xy2[0]) - shift;
                    int x2 = Math.Max(xy1[0], xy2[0]) - shift;
                    int y1 = Math.Min(xy1[1], xy2[1]);
                    int y2 = Math.Max(xy1[1], xy2[1]);

                    MaxY = Math.Max(MaxY, y2);

                    // If y1 = y2
                    for (int x = x1; x <= x2; x++)
                    {
                        map[x, y1] = 1;
                    }

                    // If x1 = x2
                    for (int y = y1; y <= y2; y++)
                    {
                        map[x1, y] = 1;
                    }
                }

                temp = Console.ReadLine();
            }

            // Make floor
            for (int x = 0; x < map.GetLength(0); x++)
            {
                map[x, MaxY + 2] = 1;
            }

            int sandX = 500 - shift;
            int sandY = 0;
            int iteration = 0;
            while (true)
            {
                iteration++;
                // Check onder
                if (map[sandX, sandY + 1] == 0)
                {
                    sandY++;
                }
                // Check linksonder
                else if (map[sandX - 1, sandY + 1] == 0)
                {
                    sandX--;
                    sandY++;
                }
                // Check rechtsonder
                else if (map[sandX + 1, sandY + 1] == 0)
                {
                    sandX++;
                    sandY++;
                }
                else if (sandX == 500 - shift && sandY == 0)
                {
                    map[sandX, sandY] = 2;
                    break;
                }
                else
                {
                    map[sandX, sandY] = 2;
                    sandX = 500 - shift;
                    sandY = 0;
                }
            }

            Debug(map, shift, MaxY, true);

            Console.ReadKey();
        }

        static int Debug(int[,] map, int shift, int MaxY, bool draw)
        {
            int count = 0;
            for (int y = 0; y < map.GetLength(1); y++)
            {
                for (int x = 0; x < map.GetLength(0); x++)
                {
                    if (draw && x == 500 - shift && y == 0) Console.Write("+");
                    else if (draw && map[x, y] == 1) Console.Write("#");
                    else if (map[x, y] == 2)
                    {
                        if (draw) Console.Write("o");
                        count++;
                    }
                    else if (draw && y <= MaxY + 1) Console.Write(" ");
                }
                if (draw && y <= MaxY + 2) Console.WriteLine();
            }
            Console.WriteLine($"Amount of sand: {count + 1}");

            return count + 1;
        }
    }
}
