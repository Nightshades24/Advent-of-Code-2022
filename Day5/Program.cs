using Reader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Day5
{
    internal class Program
    {
        static void Main()
        {
            Reader.Reader.SetIn(5);

            string[] towers = new string[9];

            string input = Console.ReadLine();
            while (!input.Contains("1"))
            {
                if (input[1] != ' ') towers[0] += (input[1]);
                if (input[5] != ' ') towers[1] += (input[5]);
                if (input[9] != ' ') towers[2] += (input[9]);
                if (input[13] != ' ') towers[3] += (input[13]);
                if (input[17] != ' ') towers[4] += (input[17]);
                if (input[21] != ' ') towers[5] += (input[21]);
                if (input[25] != ' ') towers[6] += (input[25]);
                if (input[29] != ' ') towers[7] += (input[29]);
                if (input[33] != ' ') towers[8] += (input[33]);

                input = Console.ReadLine();
            }

            while (!input.Contains("move"))
                input = Console.ReadLine();

            for (int i = 0; i < towers.Length; i++)
            {
                char[] charArray = towers[i].ToCharArray();
                Array.Reverse(charArray);
                towers[i] = new string(charArray);
            }

            while (input != null)
            {
                string[] move = input.Split();
                Stack<char> crates = new Stack<char>();
                int from = int.Parse(move[3]) - 1;
                int to = int.Parse(move[5]) - 1;

                for (int i = 0; i < int.Parse(move[1]); i++)
                {
                    // PART1: char crate = towers[from][towers[from].Length - 1];
                    crates.Push(towers[from][towers[from].Length - 1]);

                    // PART1: towers[to] += crate;
                    towers[from] = towers[from].Remove(towers[from].Length - 1);
                }

                for (int i = 0; i < int.Parse(move[1]); i++)
                {
                    char crate = crates.Pop();

                    towers[to] += crate;
                }
                input = Console.ReadLine();
            }

            string result = "";
            for (int i = 0; i < towers.Length; i++)
            {
                result += towers[i][towers[i].Length - 1];
            }

            Console.WriteLine(result);

            Console.ReadKey();
        }
    }
}
