using System.IO;
using System;
using System.Collections.Generic;
using MinHeaps;

namespace PrimsAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var fs = new FileStream("", FileMode.Open))
            {
                using (var sr = new StreamReader(fs))
                {
                    string[] nm = sr.ReadLine().Split(' ');

                    int n = Convert.ToInt32(nm[0]);

                    int m = Convert.ToInt32(nm[1]);

                    int[][] edges = new int[m][];

                    for (int i = 0; i < m; i++)
                    {
                        edges[i] = Array.ConvertAll(sr.ReadLine().Split(' '), edgesTemp => Convert.ToInt32(edgesTemp));
                    }

                    int start = Convert.ToInt32(sr.ReadLine());

                    int result = prims(n, edges, start);
                    Console.WriteLine(result);
                }
            }
        }


        // Complete the prims function below.
        static int prims(int n, int[][] edges, int start)
        {
            var mstSet = new bool[n + 1];
            var nodes = new Node[n + 1];
            var queue = new MinHeap<Node>();

            var graph = new List<int>[n + 1];
            for (var i = 1; i <= n; i++)
            {
                graph[i] = new List<int>();
                nodes[i] = new Node() { Parent = -1, Key = Int32.MaxValue, Vertex = i };
                queue.Add(nodes[i]);
            }

            for (int i = 0; i < edges.Length; i++)
            {
                graph[edges[i][0]].Add(edges[i][1]);
                graph[edges[i][1]].Add(edges[i][0]);
            }

            var result = 0;
            mstSet[start] = true;
            nodes[start].Key = 0;

            while (queue.Count > 0)
            {
                var node = queue.Pull();
                mstSet[node.Vertex] = true; // in MST TREE
            }

            return result;
        }

        class Node : IEquatable<Node>
        {
            public int Key { get; set; }
            public int Parent { get; set; }
            public int Vertex { get; set; }
        }
    }
}