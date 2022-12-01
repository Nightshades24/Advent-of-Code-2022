using Reader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1
{
    internal class Program
    {
        static void Main()
        {
            Reader.Reader.SetIn(1);

            int max = 0;
            int count = 0;

            int one = 0;
            int two = 0;
            int three = 0;

            string temp = Console.ReadLine();
            while (temp != null)
            {
                if (temp == "")
                {
                    if (count >= one)
                    {
                        three = two;
                        two = one;
                        one = count;
                    }
                    else if (count >= two)
                    {
                        three = two;
                        two = count;
                    }
                    else if (count >= three)
                    {
                        three = count;
                    }

                    max = Math.Max(max, count);
                    count = 0;
                }
                else
                {
                    count += int.Parse(temp);
                }
                temp = Console.ReadLine();
            }
            Console.WriteLine("Elf with max calories: " + max);
            Console.WriteLine("Sum of top three: " + (one + two + three));

            Console.ReadKey();
        }
    }
}
