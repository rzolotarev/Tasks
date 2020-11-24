using System;
using System.Linq;
using System.Collections.Generic;

namespace MinimumPenaltyPath
{
    class Program
    {
        static void Main(string[] args)
        {
            var edges = new int[4][];
            edges[0] = new int[3] {1, 2, 1};
            edges[1] = new int[3] {1, 2, 1000};
            edges[2] = new int[3] {2, 3, 3};
            edges[3] = new int[3] {1, 3, 100};
            Console.WriteLine(BeautifulPath(edges, 1, 3));
        }

        static int BeautifulPath(int[][] edges, int A, int B)
        {
            var graph = new List<Node>[edges.Length + 1];
            for(var i = 0; i < edges.Length; i++)
            {
                if (graph[edges[i][0]] == null)                
                    graph[edges[i][0]] = new List<Node>();

                if (graph[edges[i][1]] == null)                
                    graph[edges[i][1]] = new List<Node>();

                graph[edges[i][0]].Add(new Node(edges[i][1], edges[i][2]));
                graph[edges[i][1]].Add(new Node(edges[i][0], edges[i][2]));         
            }

            var visited = new bool[graph.Length];
            var queue = new Queue<int>();
            queue.Enqueue(A);
            while(queue.Count > 0) 
            {
                var current = queue.Dequeue();
                var i = 0;
                while(i < graph[current].Count)
                {
                    if (graph[current][i].Number == B)
                    {

                    }
                }
            }

            return -1;
        }

        class Node 
        {
            public int Number { get; set; }
            public int Path { get; set; }
            public List<Node> Adjacent { get; set; }
            public bool Visited { get; set; }

            public Node()
            {
                Adjacent = new List<Node>();
            }

            public Node(int number, int path)
            {
                Number = number;
                Path = path;
                Adjacent = new List<Node>();
            }
        }
    }
}
