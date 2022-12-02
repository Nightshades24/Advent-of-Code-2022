using Reader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Day2
{
    internal class Program
    {
        static void Main()
        {
            Reader.Reader.SetIn(2);

            // A X = rock
            // B Y = paper
            // C Z = scissors

            int score1 = 0;
            int score2 = 0;
            string temp = Console.ReadLine();
            string[] input = temp.Split(' ');

            while (temp != null)
            {
                // Part 1
                switch (input[0])
                {
                    case "A":
                        switch (input[1])
                        {
                            case "X":
                                score1 += 3 + 1;
                                break;
                            case "Y":
                                score1 += 6 + 2;
                                break;
                            case "Z":
                                score1 += 0 + 3;
                                break;
                        }

                        break;
                    case "B":
                        switch (input[1])
                        {
                            case "X":
                                score1 += 0 + 1;
                                break;
                            case "Y":
                                score1 += 3 + 2;
                                break;
                            case "Z":
                                score1 += 6 + 3;
                                break;
                        }

                        break;
                    case "C":
                        switch (input[1])
                        {
                            case "X":
                                score1 += 6 + 1;
                                break;
                            case "Y":
                                score1 += 0 + 2;
                                break;
                            case "Z":
                                score1 += 3 + 3;
                                break;
                        }

                        break;

                }

                // Part 2
                switch (input[0])
                {
                    case "A":
                        switch (input[1])
                        {
                            case "X":
                                score2 += 0 + 3;
                                break;
                            case "Y":
                                score2 += 3 + 1;
                                break;
                            case "Z":
                                score2 += 6 + 2;
                                break;
                        }

                        break;
                    case "B":
                        switch (input[1])
                        {
                            case "X":
                                score2 += 0 + 1;
                                break;
                            case "Y":
                                score2 += 3 + 2;
                                break;
                            case "Z":
                                score2 += 6 + 3;
                                break;
                        }

                        break;
                    case "C":
                        switch (input[1])
                        {
                            case "X":
                                score2 += 0 + 2;
                                break;
                            case "Y":
                                score2 += 3 + 3;
                                break;
                            case "Z":
                                score2 += 6 + 1;
                                break;
                        }

                        break;
                }
                        temp = Console.ReadLine();
                if (temp != null) input = temp.Split(' ');
            }

            Console.WriteLine("Total score1: " + score1);
            Console.WriteLine("Total score2: " + score2);
            Console.ReadKey();
        }
    }
}
