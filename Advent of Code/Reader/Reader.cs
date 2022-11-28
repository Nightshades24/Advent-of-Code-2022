using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Reader
{
    public class Reader
    {
        static void Main()
        {
            Console.WriteLine("Hello world!");
        }

        public static void SetIn(int day)
        {
            string path = "..\\..\\..\\Day" + day + "\\in.txt";
            Console.SetIn(new StreamReader(path));
        }
    }
}
