using Reader;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day7
{
    internal class Program
    {
        static void Main()
        {
            Reader.Reader.SetIn(7);

            string temp = Console.ReadLine();
            Stack<string> currentDir = new Stack<string>();
            Dictionary<string, (string, int)> files = new Dictionary<string, (string, int)>();
            Dictionary<string, int> sizes = new Dictionary<string, int>();


            while (temp != null)
            {
                bool ls = false;

                string[] input = temp.Split();
                if (input[1] == "cd" && input[2] != "..")
                {
                    currentDir.Push(input[2]);
                }
                else if (input[1] == "ls")
                {
                    ls = true;

                    int sum = 0;
                    string dirs = "";

                    string file = Console.ReadLine();
                    while (file != null && !file.Contains('$'))
                    {
                        string[] split = file.Split();
                        if (split[0] == "dir") dirs += split[1] + " ";
                        else sum += int.Parse(split[0]);
                        file = Console.ReadLine();
                    }

                    string[] dirArray = currentDir.ToArray();
                    Array.Reverse(dirArray);
                    string key = "";
                    for (int i = 0; i < dirArray.Length; i++)
                    {
                        key += dirArray[i] + " ";
                    }
                    files.Add(key, (dirs, sum));
                    temp = file;
                }
                else currentDir.Pop();

                if (!ls) temp = Console.ReadLine();
            }

            int result = 0;
            foreach (var item in files)
            {
                Queue<string> searchDir = new Queue<string>();
                int size = 0;
                size += item.Value.Item2;

                string[] dirs = item.Value.Item1.Split();
                for (int i = 0; i < dirs.Length; i++)
                {
                    if (dirs[i] != "")
                    {                        
                        searchDir.Enqueue(item.Key + dirs[i] + " ");
                    }
                }

                while (searchDir.Count > 0)
                {
                    string dir = searchDir.Dequeue();
                    var contains = files[dir];
                    size += contains.Item2;
                    if (contains.Item1 != "")
                    {
                        string[] enqueueDirs = contains.Item1.Split();
                        for (int j = 0; j < enqueueDirs.Length; j++)
                        {
                            if (enqueueDirs[j] != "") searchDir.Enqueue(dir + enqueueDirs[j] + " ");
                        }
                    }
                }

                sizes.Add(item.Key, size);
                if (size <= 100000) result += size;
            }
            Console.WriteLine("Part1: " + result);

            int unusedSpace = 70000000 - sizes["/ "];

            List<int> deletes = new List<int>();
            foreach (var item in sizes)
            {
                if (unusedSpace + item.Value >= 30000000) deletes.Add(item.Value);
            }

            deletes.Sort();
            Console.WriteLine("Part2: " + deletes.First());

            Console.ReadKey();
        }
    }
}
