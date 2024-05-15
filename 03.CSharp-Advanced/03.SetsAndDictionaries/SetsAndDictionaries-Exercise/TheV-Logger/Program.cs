using System;
using System.Collections.Generic;
using System.Linq;

namespace TheV_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<List<string>, List<string>>> vloggerDict =
                new Dictionary<string, Dictionary<List<string>, List<string>>>();

            string input = Console.ReadLine();

            while (input != "Statistics")
            {
                string[] tokens = input.Split(" ").ToArray();

                if (tokens[1] == "joined")
                {
                    if (!vloggerDict.ContainsKey(tokens[0]))
                    {
                        vloggerDict.Add(tokens[0], new Dictionary<List<string>, List<string>>());
                        vloggerDict[tokens[0]].Add(new List<string>(), new List<string>());
                    }
                }

                if (tokens[1] == "followed")
                {
                    if (vloggerDict.ContainsKey(tokens[0]) && vloggerDict.ContainsKey(tokens[2]))
                    {
                        if (tokens[0] != tokens[2])
                        {
                            if (!vloggerDict[tokens[2]].FirstOrDefault().Key.Contains(tokens[0]))
                            {
                                vloggerDict[tokens[2]].FirstOrDefault().Key.Add(tokens[0]);
                            }

                            if (!vloggerDict[tokens[0]].FirstOrDefault().Value.Contains(tokens[2]))
                            {
                                vloggerDict[tokens[0]].LastOrDefault().Value.Add(tokens[2]);
                            }
                        }
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"The V-Logger has a total of {vloggerDict.Keys.Count} vloggers in its logs.");

            int index = 1;

            foreach (var vlogger in vloggerDict.OrderByDescending(x => x.Value.FirstOrDefault().Key.Count).ThenBy(y => y.Value.FirstOrDefault().Value.Count))
            {
                Console.WriteLine($"{index}. {vlogger.Key} : {vlogger.Value.FirstOrDefault().Key.Count} followers, {vlogger.Value.FirstOrDefault().Value.Count} following");

                if (index == 1)
                {
                    List<string> tempList = new List<string>();
                    tempList = vlogger.Value.FirstOrDefault().Key.OrderBy(t => t).ToList();

                    foreach (var temp in tempList)
                    {
                        Console.WriteLine($"*  {temp}");
                    }
                }

                index++;
            }
        }
    }
}
