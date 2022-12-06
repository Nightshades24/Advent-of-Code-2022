using Reader;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day6
{
    internal class Program
    {
        static void Main()
        {
            Reader.Reader.SetIn(6);

            string input = Console.ReadLine();

            char[] chars = new char[14];
            int[] counts = new int[14];

            bool done;

            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < chars.Length - 1; j++)
                {
                    chars[j] = chars[j + 1];
                }
                chars[chars.Length - 1] = input[i];

                // PART 1
                //if (chars[0] != chars[1] && chars[0] != chars[2] && chars[0] != chars[3] &&
                //    chars[1] != chars[2] && chars[1] != chars[3] && chars[2] != chars[3] && !chars.Contains('\0'))
                //{
                //    Console.WriteLine(i+1);
                //    break;
                //}

                string s = new string(chars);
                done = true;

                if (!chars.Contains('\0'))
                {

                    for (int j = 0; j < chars.Length; j++)
                    {
                        counts[j] = s.Count(f => f == chars[j]);
                        if (counts[j] > 1)
                        {
                            done = false;
                            break;
                        }
                    }
                    if (done)
                    {
                        Console.WriteLine(i + 1);
                        break;
                    }
                }
                else done = false;
                if (done) break;
            }

            Console.ReadKey();
        }
    }
}
