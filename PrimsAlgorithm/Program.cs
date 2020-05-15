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
            using (var fs = new FileStream("input.txt", FileMode.Open))
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
            var nodes = new Node[n + 1];
            var queue = new MinHeap(n);

            var graph = new List<Node>[n + 1];
            for (var i = 1; i <= n; i++)
            {
                graph[i] = new List<Node>();
                nodes[i] = new Node() { Key = Int32.MaxValue, Vertex = i };
                queue.Enqueue(nodes[i]);
            }

            for (int i = 0; i < edges.Length; i++)
            {
                graph[edges[i][0]].Add(new Node() { Vertex = edges[i][1], Key = edges[i][2] });
                graph[edges[i][1]].Add(new Node() { Vertex = edges[i][0], Key = edges[i][2] });
            }

            var result = 0;
            nodes[start].Key = 0;
            // nodes[start].IsMST = true;

            while (queue.Count > 0)
            {
                var node = queue.Pull();
                Console.WriteLine($"pulled {node.Vertex}- {node.Key}");
                nodes[node.Vertex].IsMST = true; // in MST TREE

                foreach (var adjNode in graph[node.Vertex])
                {
                    if (nodes[adjNode.Vertex].IsMST == true)
                        continue;

                    if (nodes[adjNode.Vertex].Key > adjNode.Key)
                    {
                        nodes[adjNode.Vertex].Key = adjNode.Key; // updated in queue   
                        nodes[adjNode.Vertex].Parent = node.Vertex;
                    }
                }
            }

            for (int i = 1; i <= n; i++)
                result += nodes[i].Key;

            return result;
        }

    }
}