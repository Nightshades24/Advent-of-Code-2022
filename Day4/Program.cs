using Reader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4
{
    internal class Program
    {
        static void Main()
        {
            Reader.Reader.SetIn(4);

            
            int counter1 = 0;
            int counter2 = 0;
            string temp = Console.ReadLine();
            string[] input = temp.Split(',');
            
            while (temp != null)
            {
                int[] pair1 = Array.ConvertAll(input[0].Split('-'), s => int.Parse(s));
                int[] pair2 = Array.ConvertAll(input[1].Split('-'), s => int.Parse(s));

                if (pair1[0] <= pair2[0] && pair1[1] >= pair2[1])
                {
                    counter1++;
                }
                else if (pair1[0] >= pair2[0] && pair1[1] <= pair2[1])
                {
                    counter1++;
                }
                else if (pair1[0] <= pair2[0] && pair2[0] <= pair1[1])
                {
                    counter2++;
                }
                else if (pair2[0] <= pair1[0] && pair1[0] <= pair2[1])
                {
                    counter2++;
                }
                else if (pair1[0] <= pair2[1] && pair2[1] <= pair1[1])
                {
                    counter2++;
                }
                else if (pair2[0] <= pair1[1] && pair1[1] <= pair2[1])
                {
                    counter2++;
                }

                temp = Console.ReadLine();
                if (temp != null) input = temp.Split(',');
            }
            Console.WriteLine("Part1: " + counter1);
            Console.WriteLine("Part2: " + (counter1 + counter2));

            Console.ReadKey();
        }
    }
}
