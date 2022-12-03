using Reader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3
{
    internal class Program
    {
        static void Main()
        {
            // Part 1
            Reader.Reader.SetIn(3);

            int sum1 = 0;
            string input = Console.ReadLine();

            while (input != null)
            {
                string fst = input.Substring(0, input.Length / 2);
                string snd = input.Substring(input.Length / 2, input.Length / 2);

                foreach (char letter in fst)
                {
                    if (snd.Contains(letter))
                    {
                        if (char.IsUpper(letter))
                        {
                            sum1 += letter - 38;
                        }
                        else
                        {
                            sum1 += letter - 96;
                        }

                        break;
                    }
                }
                input = Console.ReadLine();
            }

            Console.WriteLine("Sum1: " + sum1);

            //Part 2

            Reader.Reader.SetIn(3);

            int sum2 = 0;
            string one = Console.ReadLine();
            string two = Console.ReadLine();
            string three = Console.ReadLine();

            while (one != null)
            {
                foreach (char letter in one)
                {
                    if (two.Contains(letter) && three.Contains(letter))
                    {
                        if (char.IsUpper(letter))
                        {
                            sum2 += letter - 38;
                        }
                        else
                        {
                            sum2 += letter - 96;
                        }

                        break;
                    }
                }

                one = Console.ReadLine();
                two = Console.ReadLine();
                three = Console.ReadLine();
            }

            Console.WriteLine("Sum2: " + sum2);

            Console.ReadKey();
        }
    }
}
