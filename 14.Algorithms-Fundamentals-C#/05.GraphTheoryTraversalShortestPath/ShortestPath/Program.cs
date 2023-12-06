using System;
using System.Collections.Generic;
using System.Linq;

namespace ShortestPath
{
    public class Program
    {
        private static List<int>[] _graph;
        private static bool[] _visited;
        private static int[] _parent;

        static void Main()
        {
            var sizeOfGraph = int.Parse(Console.ReadLine());
            var edge = int.Parse(Console.ReadLine());

            _graph = new List<int>[sizeOfGraph + 1];
            _visited = new bool[_graph.Length];
            _parent = new int[_graph.Length];

            for (int node = 0; node < _graph.Length; node++)
            {
                _graph[node] = new List<int>();
            }

            Array.Fill(_parent, -1);

            for (int currentEdge = 0; currentEdge < edge; currentEdge++)
            {
                var inputLineFromConsole = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => int.Parse(x)).ToArray();

                var firstNode = inputLineFromConsole[0];
                var secondNode = inputLineFromConsole[1];

                _graph[firstNode].Add(secondNode);
                _graph[secondNode].Add(firstNode);
            }

            var start = int.Parse(Console.ReadLine());
            var destination = int.Parse(Console.ReadLine());

            BFS(start, destination);
        }

        private static void BFS(int startNode, int destination)
        {
            var queue = new Queue<int>();
            queue.Enqueue(startNode);
            _visited[startNode] = true;

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                if (destination == node)
                {
                    var path = GetPath(destination);
                    Console.WriteLine($"Shortest path length is: {path.Count - 1}");
                    Console.WriteLine(string.Join(" ", path));
                    break;
                }

                foreach (var child in _graph[node])
                {
                    if (!_visited[child])
                    {
                        _parent[child] = node;
                        _visited[child] = true;
                        queue.Enqueue(child);
                    }
                }
            }
        }

        private static Stack<int> GetPath(int destination)
        {
            var path = new Stack<int>();
            var node = destination;
            
            while (node != -1)
            {
                path.Push(node);
                node = _parent[node];
            }

            return path;
        }
    }
}