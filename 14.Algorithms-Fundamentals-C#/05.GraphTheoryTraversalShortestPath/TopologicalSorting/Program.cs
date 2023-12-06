using System;
using System.Collections.Generic;
using System.Linq;

namespace TopologicalSorting
{
    public class Program
    {
        private static Dictionary<string, List<string>> _graph;
        private static Dictionary<string, int> _dependencies;

        static void Main()
        {
            var readSizeOfGraph = int.Parse(Console.ReadLine());
            _graph = ReadGraph(readSizeOfGraph);
            _dependencies = ExtractDependencies(_graph);
            
            List<string> sorted = SRA();
            
            Console.WriteLine(_dependencies.Count == 0
                ? $"Topological sorting: {string.Join(", ", sorted)}"
                : "Invalid topological sorting");
        }

        private static Dictionary<string, List<string>> ReadGraph(int readSizeOfGraph)
        {
            var result = new Dictionary<string, List<string>>();
            for (int node = 0; node < readSizeOfGraph; node++)
            {
                var inputLineFromConsole = Console.ReadLine().Split("->", StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => x.Trim()).ToArray();
                var key = inputLineFromConsole[0];

                if (inputLineFromConsole.Length == 1)
                    result[key] = new List<string>();
                else
                {
                    var value = inputLineFromConsole[1].Split(", ", StringSplitOptions.RemoveEmptyEntries).ToList();
                    result[key] = value;
                }
            }

            return result;
        }

        private static Dictionary<string, int> ExtractDependencies(Dictionary<string, List<string>> graph)
        {
            var result = new Dictionary<string, int>();

            foreach (var kvp in graph)
            {
                var node = kvp.Key;
                var children = kvp.Value;

                if (!result.ContainsKey(node))
                {
                    result[node] = 0;
                }

                foreach (var child in children)
                {
                    if (!result.ContainsKey(child))
                    {
                        result[child] = 1;
                    }
                    else
                    {
                        result[child]++;
                    }
                }
            }

            return result;
        }

        private static List<string> SRA()
        {
            var result = new List<string>();

            while (_dependencies.Count > 0)
            {
                var nodeToRemove = _dependencies.FirstOrDefault(x => x.Value == 0).Key;

                if (nodeToRemove == null)
                {
                    break;
                }

                _dependencies.Remove(nodeToRemove);
                result.Add(nodeToRemove);
                
                foreach (var child in _graph[nodeToRemove])
                {
                    _dependencies[child] -= 1;
                }
            }

            return result;
        }
    }
}