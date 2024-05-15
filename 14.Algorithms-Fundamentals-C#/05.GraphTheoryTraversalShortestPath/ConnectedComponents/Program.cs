using System;
using System.Collections.Generic;
using System.Linq;

namespace ConnectedComponents
{
    public class Program
    {
        private static List<int>[] _graph;
        private static bool[] _visited;

        public static void Main(string[] args)
        {
            _graph = ReadGraph();
            
            FindConnectedComponents();
        }

        private static List<int>[] ReadGraph()
        {
            int n = int.Parse(Console.ReadLine());
            _graph = new List<int>[n];

            for (int i = 0; i < n; i++)
            {
                _graph[i] = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToList();
            }

            return _graph;
        }

        private static void FindConnectedComponents()
        {
            _visited = new bool[_graph.Length];

            for (int startNode = 0; startNode < _graph.Length; startNode++)
            {
                if (!_visited[startNode])
                {
                    Console.Write("Connected component: ");
                    DFS(startNode);
                    Console.WriteLine();
                }
            }
        }

        private static void DFS(int vertex)
        {
            if (!_visited[vertex])
            {
                _visited[vertex] = true;

                foreach (var child in _graph[vertex])
                {
                    DFS(child);
                }

                Console.Write($"{vertex} ");
            }
        }
    }
}