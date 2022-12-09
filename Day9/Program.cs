using Reader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Day9
{
    internal class Program
    {
        static void Main()
        {
            Reader.Reader.SetIn(9);

            (int x, int y) head = (0, 0);
            (int x, int y) one = (0, 0);
            (int x, int y) two = (0, 0);
            (int x, int y) three = (0, 0);
            (int x, int y) four = (0, 0);
            (int x, int y) five = (0, 0);
            (int x, int y) six = (0, 0);
            (int x, int y) seven = (0, 0);
            (int x, int y) eight = (0, 0);
            (int x, int y) tail = (0, 0);

            Dictionary<(int, int), int> positions = new Dictionary<(int, int), int>();
            Dictionary<(int, int), int> positions2 = new Dictionary<(int, int), int>();
            positions.Add((0, 0), 0);

            string temp = Console.ReadLine();

            while (temp != null)
            {
                string[] move = temp.Split(' ');

                for (int i = 0; i < int.Parse(move[1]); i++)
                {
                    /*DrawSituation(head,
                                  one,
                                  two,
                                  three,
                                  four,
                                  five,
                                  six,
                                  seven,
                                  eight,
                                  tail);

                    Console.ReadKey();*/

                    switch (move[0])
                    {
                        case "L":
                            head = (head.x - 1, head.y);
                            one = UpdateTail(head, one);
                            two = UpdateTail(one, two);
                            three = UpdateTail(two, three);
                            four = UpdateTail(three, four);
                            five = UpdateTail(four, five);
                            six = UpdateTail(five, six);
                            seven = UpdateTail(six, seven);
                            eight = UpdateTail(seven, eight);
                            tail = UpdateTail(eight, tail);
                            break;
                        case "R":
                            head = (head.x + 1, head.y);
                            one = UpdateTail(head, one);
                            two = UpdateTail(one, two);
                            three = UpdateTail(two, three);
                            four = UpdateTail(three, four);
                            five = UpdateTail(four, five);
                            six = UpdateTail(five, six);
                            seven = UpdateTail(six, seven);
                            eight = UpdateTail(seven, eight);
                            tail = UpdateTail(eight, tail);
                            break;
                        case "U":
                            head = (head.x, head.y + 1);
                            one = UpdateTail(head, one);
                            two = UpdateTail(one, two);
                            three = UpdateTail(two, three);
                            four = UpdateTail(three, four);
                            five = UpdateTail(four, five);
                            six = UpdateTail(five, six);
                            seven = UpdateTail(six, seven);
                            eight = UpdateTail(seven, eight);
                            tail = UpdateTail(eight, tail);
                            break;
                        case "D":
                            head = (head.x, head.y - 1);
                            one = UpdateTail(head, one);
                            two = UpdateTail(one, two);
                            three = UpdateTail(two, three);
                            four = UpdateTail(three, four);
                            five = UpdateTail(four, five);
                            six = UpdateTail(five, six);
                            seven = UpdateTail(six, seven);
                            eight = UpdateTail(seven, eight);
                            tail = UpdateTail(eight, tail);
                            break;
                    }
                    if (!positions.ContainsKey(one))
                        positions.Add(one, 0);
                    if (!positions2.ContainsKey(tail))
                        positions2.Add(tail, 0);
                }

                temp = Console.ReadLine();
            }

            Console.WriteLine("Part1: " + positions.Keys.ToArray().Length);
            Console.WriteLine("Part2: " + positions2.Keys.ToArray().Length);

            Console.ReadKey();
        }

        static void DrawSituation(
            (int x, int y) head,
            (int x, int y) one,
            (int x, int y) two,
            (int x, int y) three,
            (int x, int y) four,
            (int x, int y) five,
            (int x, int y) six,
            (int x, int y) seven,
            (int x, int y) eight,
            (int x, int y) tail)
        {
            string[,] map = new string[60, 40];
            map[15, 15] = "s";
            map[15 + tail.x, 15 + tail.y] = "9";
            map[15 + eight.x, 15 + eight.y] = "8";
            map[15 + seven.x, 15 + seven.y] = "7";
            map[15 + six.x, 15 + six.y] = "6";
            map[15 + five.x, 15 + five.y] = "5";
            map[15 + four.x, 15 + four.y] = "4";
            map[15 + three.x, 15 + three.y] = "3";
            map[15 + two.x, 15 + two.y] = "2";
            map[15 + one.x, 15 + one.y] = "1";
            map[15 + head.x, 15 + head.y] = "H";

            for (int y = map.GetLength(1) - 1; y >= 0; y--)
            {
                for (int x = 0; x < map.GetLength(0); x++)
                {
                    if (map[x, y] == null) Console.Write(".");
                    else Console.Write(map[x, y]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        static (int, int) UpdateTail((int x, int y) head, (int x, int y) tail)
        {
            (int, int) newTail = (tail.x, tail.y);

            bool links = tail.x - head.x > 1;
            bool rechts = tail.x - head.x < -1;
            bool boven = tail.y - head.y < -1;
            bool onder = tail.y - head.y > 1;

            if (boven && links)
            {
                newTail = (head.x + 1, head.y - 1);
            }
            else if (boven && rechts)
            {
                newTail = (head.x - 1, head.y - 1);
            }
            else if (onder && links)
            {
                newTail = (head.x + 1, head.y + 1);
            }
            else if (onder && rechts)
            {
                newTail = (head.x - 1, head.y + 1);
            }
            else if (links)
            {
                newTail = (head.x + 1, head.y);
            }
            else if (rechts)
            {
                newTail = (head.x - 1, head.y);
            }
            else if (boven)
            {
                newTail = (head.x, head.y - 1);
            }
            else if (onder)
            {
                newTail = (head.x, head.y + 1);
            }

            return (newTail);
        }
    }
}
