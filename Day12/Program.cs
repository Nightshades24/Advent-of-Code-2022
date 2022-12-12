using Reader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day12
{
    internal class Program
    {
        static void Main()
        {
            Reader.Reader.SetIn(12);

            (int, int) start = (0, 0);
            (int, int) end = (0, 0);
            int[,] grid = new int[154, 41];
            //int[,] grid = new int[8, 5];

            string input = Console.ReadLine();

            int y = 0;
            while (input != null)
            {
                for (int x = 0; x < input.Length; x++)
                {
                    if (input[x] == 'S')
                    {
                        start = (x, y);
                        grid[x, y] = 97;
                    }
                    else if (input[x] == 'E')
                    {
                        end = (x, y);
                        grid[x, y] = 122;
                    }
                    else grid[x, y] = input[x];
                }
                y++;
                input = Console.ReadLine();
            }

            int min = 1000000;

            Console.WriteLine("Part1: " + BFS(grid, start, end));

            for (int x = 0; x < grid.GetLength(0); x++)
                for (y = 0; y < grid.GetLength(1); y++)
                {
                    if (grid[x, y] == 'a') 
                        min = Math.Min(min, BFS(grid, (x, y), end));
                }

            Console.WriteLine("Part2: " + min);

            Console.ReadKey();
        }

        static int BFS(int[,] grid, (int, int) start, (int, int) end)
        {
            int[,] steps = new int[154, 41];
            //int[,] steps = new int[8, 5];
            for (int x = 0; x < grid.GetLength(0); x++)
                for (int y = 0; y < grid.GetLength(1); y++)
                    steps[x, y] = -1;

            Queue<(int, int)> queue = new Queue<(int, int)>();

            queue.Enqueue(start);
            steps[start.Item1, start.Item2] = 0;

            while (queue.Count > 0)
            {
                (int x, int y) coord = queue.Dequeue();

                // Links
                if (coord.x - 1 >= 0 && grid[coord.x - 1, coord.y] - grid[coord.x, coord.y] <= 1)
                {
                    if (steps[coord.x - 1, coord.y] == -1 || steps[coord.x, coord.y] + 1 < steps[coord.x - 1, coord.y])
                    {
                        steps[coord.x - 1, coord.y] = steps[coord.x, coord.y] + 1;
                        queue.Enqueue((coord.x - 1, coord.y));
                    }
                }
                // Omhoog
                if (coord.y - 1 >= 0 && grid[coord.x, coord.y - 1] - grid[coord.x, coord.y] <= 1)
                {
                    if (steps[coord.x, coord.y - 1] == -1 || steps[coord.x, coord.y] + 1 < steps[coord.x, coord.y - 1])
                    {
                        steps[coord.x, coord.y - 1] = steps[coord.x, coord.y] + 1;
                        queue.Enqueue((coord.x, coord.y - 1));
                    }
                }
                // Rechts
                if (coord.x + 1 < grid.GetLength(0) && grid[coord.x + 1, coord.y] - grid[coord.x, coord.y] <= 1)
                {
                    if (steps[coord.x + 1, coord.y] == -1 || steps[coord.x, coord.y] + 1 < steps[coord.x + 1, coord.y])
                    {
                        steps[coord.x + 1, coord.y] = steps[coord.x, coord.y] + 1;
                        queue.Enqueue((coord.x + 1, coord.y));
                    }
                }
                // Omlaag
                if (coord.y + 1 < grid.GetLength(1) && grid[coord.x, coord.y + 1] - grid[coord.x, coord.y] <= 1)
                {
                    if (steps[coord.x, coord.y + 1] == -1 || steps[coord.x, coord.y] + 1 < steps[coord.x, coord.y + 1])
                    {
                        steps[coord.x, coord.y + 1] = steps[coord.x, coord.y] + 1;
                        queue.Enqueue((coord.x, coord.y + 1));
                    }
                }
            }

            if (steps[end.Item1, end.Item2] != -1)
                return steps[end.Item1, end.Item2];
            else return 1000000;
        }
    }
}
