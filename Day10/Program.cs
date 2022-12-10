using Reader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day10
{
    internal class Program
    {
        static void Main()
        {
            Reader.Reader.SetIn(10);

            int signalstrength = 0;
            int X = 1;
            int cycle = 0;
            bool add = false;
            string answer = "";

            string temp = Console.ReadLine();

            while (temp != null)
            {
                if (cycle % 40 == (X-1) || cycle % 40 == X || cycle % 40 == (X + 1))
                {
                    answer += "#";
                }
                else
                {
                    answer += ".";
                }

                cycle++;
                
                if (cycle == 20 || cycle == 60 || cycle == 100 || cycle == 140 || cycle == 180 || cycle == 220)
                {
                    //Console.WriteLine($"During the {cycle}th cycle, register X has the value {X}, so the signal strength is {cycle} * {X} = " + (cycle * X));
                    signalstrength += cycle * X;
                }


                string[] input = temp.Split(' ');

                if (input[0] == "noop")
                {
                    temp = Console.ReadLine();
                }
                else if (input[0] == "addx" && !add)
                {
                    add = true;
                }
                else if (input[0] == "addx" && add)
                {
                    add = false;
                    X += int.Parse(input[1]);
                    temp = Console.ReadLine();
                }

            }


            Console.WriteLine("Part1: " + signalstrength);
            Console.WriteLine("\nPart2:");
            for (int i = 0; i < 240; i++)
            {
                if (i % 40 == 0) Console.WriteLine();
                Console.Write(answer[i]);
            }

            Console.ReadKey();
        }
    }
}
