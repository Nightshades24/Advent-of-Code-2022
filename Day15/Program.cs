using Reader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day15
{
    internal class Program
    {
        static void Main()
        {
            Reader.Reader.SetIn(15);

            string temp = Console.ReadLine();

            Dictionary<(long, long),int> positions = new Dictionary<(long, long),int>();


            //long maxVal = 20;
            long maxVal = 4000000;

            // PART 1 SHIT
            //long zoekY = 10;
            long zoekY = 2000000;
            long counter = 0;

            int regel = 0;
            Dictionary<long, List<(long X1, long X2)>> lijnenPerY = new Dictionary<long, List<(long X1, long X2)>>();
            for (int i =  0; i <= maxVal; i++)
            {
                lijnenPerY[i] = new List<(long X1, long X2)>();
            }
            List<(long X1, long X2)> lijnen = new List<(long, long)>();

            while (temp != null)
            {
                regel++;
                string[] input = temp.Replace(",", "").Replace(":", "").Replace("=", " ").Split(' ');

                long sx = int.Parse(input[3]);
                long sy = int.Parse(input[5]);
                long bx = int.Parse(input[11]);
                long by = int.Parse(input[13]);

                positions[(bx, by)] = 1;

                long afstand = Math.Abs(sx - bx) + Math.Abs(sy - by);
                
                for (long y = 0; y < afstand; y++)
                {
                    if (((sy - afstand) + y) >= 0 && ((sy - afstand) + y) <= maxVal) 
                        lijnenPerY[(sy - afstand) + y].Add((sx - y, sx + y));

                    if (((sy + afstand) - y) >= 0 && ((sy + afstand) - y) <= maxVal)
                        lijnenPerY[(sy + afstand) - y].Add((sx - y, sx + y));
                }

                if (sy >= 0 && sy <= maxVal) 
                    lijnenPerY[sy].Add((sx - afstand, sx + afstand));

                // PART 1 SHIT
                for (long y = 0; y <= 2 * afstand; y++)
                {
                    if ((y - afstand + sy) == zoekY)
                    {
                        if (y <= afstand)
                        {
                            for (long x = -y; x <= y; x++)
                            {
                                if (!positions.ContainsKey((sx + x, (y - afstand) + sy)))
                                {
                                    counter++;
                                    positions[(sx + x, (y - afstand) + sy)] = 1;
                                }
                            }
                        }
                        else
                        {
                            long num = 2 * afstand - y;
                            for (long x = -num; x <= num; x++)
                            {
                                if (!positions.ContainsKey((sx + x, (y - afstand) + sy)))
                                {
                                    counter++;
                                    positions[(sx + x, (y - afstand) + sy)] = 1;
                                }
                            }
                        }
                    }
                }

                temp = Console.ReadLine();
            }

            Console.WriteLine("Part1: " + counter);
            long antwoordX = -1;
            long antwoordY = -1;
            for (int i = 0; i < maxVal; i++)
            {
                lijnenPerY[i].Sort();
                long min = lijnenPerY[i][0].X1;
                long max = lijnenPerY[i][0].X2;
                if (min > 0)
                {
                    // hebbes
                    antwoordX = min - 1;
                    antwoordY = i;
                    break;
                }

                for (int j = 1; j < lijnenPerY[i].Count; j++)
                {
                    if (lijnenPerY[i][j].X1 > max)
                    {
                        // hebbes
                        antwoordX = max + 1;
                        antwoordY = i;
                        break;
                    }
                    max = Math.Max(max, lijnenPerY[i][j].X2);
                }

                if (antwoordX != -1) break;

                if (max <= maxVal)
                {
                    // hebbes
                    antwoordX = max + 1;
                    antwoordY = i;
                    break;
                }
            }

            long freq = antwoordX * 4000000 + antwoordY;
            Console.WriteLine("Part2: " + freq);

            Console.ReadKey();
        }
    }
}
