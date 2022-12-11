using Reader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day11
{
    internal class Program
    {
        static void Main()
        {
            Reader.Reader.SetIn(11);

            long monkeyAmount = 8;
            Queue<long>[] queues = new Queue<long>[monkeyAmount];

            for (long i = 0; i < monkeyAmount; i++)
                queues[i] = new Queue<long>();

            string[,] operations = new string[monkeyAmount, 3];
            long[] tests = new long[monkeyAmount];
            long[,] bools = new long[monkeyAmount, 2];

            long[] counts = new long[monkeyAmount];

            long modulo = 1;

            string temp = Console.ReadLine();

            long index = -1;

            while (temp != null)
            {
                string[] input = temp.Trim().Replace(":", "").Replace(",", "").Split();

                switch (input[0])
                {
                    case "Monkey":
                        index++;
                        break;
                    case "Starting":
                        for (long i = 2; i < input.Length; i++)
                        {
                            queues[index].Enqueue(long.Parse(input[i]));
                        }
                        break;
                    case "Operation":
                        operations[index, 0] = input[3];
                        operations[index, 1] = input[4];
                        operations[index, 2] = input[5];
                        break;
                    case "Test":
                        tests[index] = long.Parse(input[3]);
                        break;
                    case "If":
                        if (input[1] == "true")
                        {
                            bools[index, 0] = long.Parse(input[5]);
                        }
                        else
                        {
                            bools[index, 1] = long.Parse(input[5]);
                        }
                        break;
                }

                temp = Console.ReadLine();
            }

            for (int i = 0; i < tests.Length; i++)
            {
                modulo = modulo * tests[i];
            }

            for (long round = 0; round < 10_000; round++)
            {
                if (round % 1000 == 0 || round == 20)
                {
                    Console.WriteLine("Round " + round);
                    for (int i = 0; i < counts.Length; i++)
                    {
                        Console.WriteLine($"Monkey {i} inspected items {counts[i]} times.");
                    }
                }
                for (long i = 0; i < monkeyAmount; i++)
                {
                    while (queues[i].Count > 0)
                    {
                        counts[i]++;
                        long item = queues[i].Dequeue();

                        long sum = 0;

                        switch (operations[i, 1])
                        {
                            case "+":
                                if (operations[i, 0] == "old" && operations[i, 2] == "old")
                                {
                                    sum = item + item;
                                }
                                else if (operations[i, 0] == "old")
                                {
                                    sum = item + long.Parse(operations[i, 2]);
                                }
                                else if (operations[i, 2] == "old")
                                {
                                    sum = item + long.Parse(operations[i, 0]);
                                }
                                break;
                            case "*":
                                if (operations[i, 0] == "old" && operations[i, 2] == "old")
                                {
                                    sum = item * item;
                                }
                                else if (operations[i, 0] == "old")
                                {
                                    sum = item * long.Parse(operations[i, 2]);
                                }
                                else if (operations[i, 2] == "old")
                                {
                                    sum = item * long.Parse(operations[i, 0]);
                                }
                                break;
                        }

                        // Part1  sum = sum / 3;

                        sum = sum % modulo;

                        if (sum % tests[i] == 0)
                        {
                            queues[bools[i,0]].Enqueue(sum);
                        }
                        else
                        {
                            queues[bools[i,1]].Enqueue(sum);
                        }
                    }
                }
            }

            Array.Sort(counts);
            Array.Reverse(counts);

            Console.WriteLine((counts[0] * counts[1]));

            Console.ReadKey();
        }
    }
}
