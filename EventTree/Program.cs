using System;
using System.Collections.Generic;

namespace EventTree
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        static int evenForest(int t_nodes, int t_edges, List<int> t_from, List<int> t_to) 
        {
            if (t_nodes % 2 != 0)
                throw new ArgumentException("t_nodes should be even number");

            var graph = new List<int>[t_nodes + 1];
            for(int i = 0; i < t_from.Count; i++) {
                if (graph[t_from[i]] == null)
                    graph[t_from[i]] = new List<int>();

                if (graph[t_to[i]] == null)
                    graph[t_to[i]] = new List<int>();

                graph[t_from[i]].Add(t_to[i]);
                graph[t_to[i]].Add(t_from[i]);
            }

            return 0;
        }
    }
}
