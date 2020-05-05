using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Solution
{

    class Node
    {
        public int Index;
        public int Path;
        public int PrecedingNode;
        public bool Visited;
    }

    // Complete the shortestReach function below.
    static int[] shortestReach(int n, int[][] edges, int s)
    {

        // initializing
        var adjacencyList = new LinkedList<Node>[n];
        var mapList = new Node[n]; // list of shortest paths from starting point to any
        for (var i = 0; i < n; i++)
        {
            adjacencyList[i] = (new LinkedList<Node>());
            mapList[i] = (new Node() { Path = int.MaxValue, PrecedingNode = -1 });
        }
        mapList[s - 1] = new Node() { Path = 0, PrecedingNode = -1 };

        // built adjacency list

        foreach (var currentEdges in edges)
        {
            adjacencyList[currentEdges[0] - 1]
                .AddLast(new Node()
                {
                    Index = currentEdges[1] - 1,
                    Path = currentEdges[2]
                });
            adjacencyList[currentEdges[1] - 1]
                .AddLast(new Node()
                {
                    Index = currentEdges[0] - 1,
                    Path = currentEdges[2]
                });
        }

        var queue = new Queue<int>();
        queue.Enqueue(s - 1); // starting point

        while (queue.Count > 0)
        {
            var i = queue.Dequeue();
            // go through adjacent nodes and calculate the shortes path to any node
            foreach (var adjNode in adjacencyList[i])
            {
                if (adjNode.Path + mapList[i].Path < mapList[adjNode.Index].Path)
                {
                    mapList[adjNode.Index].Path = adjNode.Path + mapList[i].Path;
                    mapList[adjNode.Index].PrecedingNode = i;
                }

                if (mapList[adjNode.Index].Visited == true)
                    continue;

                queue.Enqueue(adjNode.Index);
            }

            mapList[i].Visited = true;
        }

        return mapList.Where(node => node.Path != 0).Select(node => node.Path == Int32.MaxValue ? -1 : node.Path).ToArray();
    }


    static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@"C:\temp\1.txt", true);

        int t = Convert.ToInt32(Console.ReadLine());

        for (int tItr = 0; tItr < t; tItr++)
        {
            string[] nm = Console.ReadLine().Split(' ');

            int n = Convert.ToInt32(nm[0]);

            int m = Convert.ToInt32(nm[1]);

            int[][] edges = new int[m][];

            for (int i = 0; i < m; i++)
            {
                edges[i] = Array.ConvertAll(Console.ReadLine().Split(' '), edgesTemp => Convert.ToInt32(edgesTemp));
            }

            int s = Convert.ToInt32(Console.ReadLine());

            int[] result = shortestReach(n, edges, s);

            textWriter.WriteLine(string.Join(" ", result));
        }

        textWriter.Flush();
        textWriter.Close();
    }
}

