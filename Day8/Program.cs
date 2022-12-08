using Reader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day8
{
    internal class Program
    {
        static void Main()
        {
            Reader.Reader.SetIn(8);

            string input = Console.ReadLine();

            int[,] raster = new int[input.Length, 99];
            int ctr = 0;
            while (input != null)
            {
                for (int i = 0; i < input.Length; i++)
                {
                    raster[i, ctr] = input[i] - 48;
                }
                ctr++;
                input= Console.ReadLine();
            }

            int counter = 0;
            int max = 0;

            for (int y = 0; y < raster.GetLength(1); y++)
            {
                for (int x = 0; x < raster.GetLength(0); x++)
                {
                    var check = checkTrees(raster, x, y);
                    if (check.Item1) counter++;
                    max = Math.Max(max, check.Item2);
                }
            }

            Console.WriteLine("Part1: " + counter);
            Console.WriteLine("Part2: " + max);

            Console.ReadKey();
        }

        static (bool, int) checkTrees(int[,] raster, int x, int y)
        {
            bool boven = true;
            bool onder = true;
            bool links = true;
            bool rechts = true;

            int vBoven = 0;
            int vOnder = 0;
            int vLinks = 0;
            int vRechts = 0;

            for (int i = x - 1; i >= 0; i--)
            {
                vLinks++;
                if (raster[i, y] >= raster[x, y])
                {
                    links = false;
                    break;
                }
            }

            for (int i = x + 1; i < raster.GetLength(0); i++)
            {
                vRechts++;
                if (raster[i, y] >= raster[x, y])
                {
                    rechts = false;
                    break;
                }
            }

            for (int i = y - 1; i >= 0; i--)
            {
                vBoven++;
                if (raster[x, i] >= raster[x, y])
                {
                    boven = false;
                    break;
                }
            }

            for (int i = y + 1; i < raster.GetLength(1); i++)
            {
                vOnder++;
                if (raster[x, i] >= raster[x, y])
                {
                    onder = false;
                    break;
                }
            }

            return ((boven || onder || links || rechts), vBoven * vOnder * vLinks * vRechts);
        }
    }
}
