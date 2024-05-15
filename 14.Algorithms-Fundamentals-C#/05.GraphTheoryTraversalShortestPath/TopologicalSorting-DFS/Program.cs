using System;
using System.Collections.Generic;
using System.Linq;

namespace TopologicalSorting_DFS
{
    public class Program
    {
        private static Dictionary<string, List<string>> graph;
        private static Stack<string> sorted;
        private static HashSet<string> visited;
        private static HashSet<string> cycles;
        private static bool hasCycle = false;
        
        static void Main()
        {
            var readSizeOfGraph = int.Parse(Console.ReadLine());
            graph = ReadGraph(readSizeOfGraph);
            sorted = new Stack<string>();
            visited = new HashSet<string>();
            cycles = new HashSet<string>();

            foreach (var node in graph.Keys)
            {
                DFS(node);
            }

            Console.WriteLine(!hasCycle ? $"Topological sorting: {string.Join(", ", sorted)}" : "Invalid topological sorting");
        }
        
        private static Dictionary<string, List<string>> ReadGraph(int readSizeOfGraph)
        {
            var result = new Dictionary<string, List<string>>();
            
            for (int node = 0; node < readSizeOfGraph; node++)
            {
                var inputLineFromConsole = Console.ReadLine().Split("->", StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToArray();
                var key = inputLineFromConsole[0];

                if (inputLineFromConsole.Length == 1)
                {
                    result[key] = new List<string>();
                }
                else
                {
                    var value = inputLineFromConsole[1].Split(", ", StringSplitOptions.RemoveEmptyEntries).ToList();
                    result[key] = value;
                }
            }
            return result;
        }
        
        private static void DFS(string node)
        {
            if (cycles.Contains(node))
            {
                hasCycle = true;
                return;
            }

            if (visited.Contains(node))
            {
                return;
            }

            cycles.Add(node);
            visited.Add(node);
            
            foreach (var child in graph[node])
            {
                DFS(child);
            }

            sorted.Push(node);
            cycles.Remove(node);
        }
    }
}