using System;
using System.Collections.Generic;
using System.Linq;

namespace SongsQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] songNames = Console.ReadLine().Split(", ").ToArray();

            Queue<string> songQueue = new Queue<string>(songNames);

            while (true)
            {
                if (songQueue.Count == 0)
                {
                    Console.WriteLine($"No more songs!");
                    break;
                }

                string[] commandInput = Console.ReadLine().Split(" ").ToArray();

                switch (commandInput[0])
                {
                    case "Play":

                        if (songQueue.Count > 0)
                        {
                            songQueue.Dequeue();
                        }

                        break;
                    case "Add":
                        string temp = string.Empty;
                        temp = string.Join(" ", commandInput);
                        temp = temp.Substring(4);

                        if (!songQueue.Contains(temp))
                        {
                            songQueue.Enqueue(temp);
                        }
                        else
                        {
                            Console.WriteLine($"{temp} is already contained!");
                        }

                        break;
                    case "Show":
                        Console.WriteLine(string.Join(", ", songQueue));

                        break;
                }
            }
        }
    }
}
