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
using MinHeaps;

class Solution
{
    // Complete the shortestReach function below.
    static int[] shortestReach(int n, int[][] edges, int s)
    {
        // initializing
        var adjacencyList = new LinkedList<Node>[n + 1];
        var mapList = new Node[n + 1]; // list of shortest paths from starting point to any
        var queue = new MinHeap();

        for (var i = 1; i <= n; i++)
        {
            adjacencyList[i] = (new LinkedList<Node>());
            mapList[i] = new Node() { Index = i, Path = int.MaxValue, PrecedingNode = -1 };
            queue.Add(mapList[i]);
        }
        mapList[0] = new Node() { Path = 0 };
        mapList[s].Path = 0;
        queue.Reorder(); // put min into the root of the heap

        foreach (var currentEdges in edges)
        {
            adjacencyList[currentEdges[0]]
                .AddLast(new Node() { Index = currentEdges[1], Path = currentEdges[2] });
            adjacencyList[currentEdges[1]]
                .AddLast(new Node() { Index = currentEdges[0], Path = currentEdges[2] });
        }

        while (queue.Count > 0)
        {
            var i = queue.Get();
            mapList[i.Index].Visited = true;

            // go through adjacent nodes and calculate the shortes path to any node
            foreach (var adjNode in adjacencyList[i.Index])
            {

                if ((long)adjNode.Path + mapList[i.Index].Path < (long)mapList[adjNode.Index].Path)
                {
                    mapList[adjNode.Index].Path = adjNode.Path + mapList[i.Index].Path;
                    mapList[adjNode.Index].PrecedingNode = i.Index;

                    // this node has been "removed" from heap
                    if (mapList[adjNode.Index].Visited == true)
                    {
                        mapList[adjNode.Index].Visited = false;
                        queue.Add(mapList[adjNode.Index], reorder: true);
                        continue;
                    }
                    else
                        // if the node has not been visited, Reoreder is sufficient
                        queue.Reorder();
                }
            }
        }

        return mapList.Where(node => node.Path != 0).Select(node => node.Path == Int32.MaxValue ? -1 : node.Path).ToArray();
    }


    static void Main(string[] args)
    {
        using (var fs = new FileStream("input.txt", FileMode.Open))
        using (var sr = new StreamReader(fs))
        {

            int t = Convert.ToInt32(sr.ReadLine());

            for (int tItr = 0; tItr < t; tItr++)
            {
                string[] nm = sr.ReadLine().Split(' ');

                int n = Convert.ToInt32(nm[0]);

                int m = Convert.ToInt32(nm[1]);

                int[][] edges = new int[m][];

                for (int i = 0; i < m; i++)
                {
                    edges[i] = Array.ConvertAll(sr.ReadLine().Split(' '), edgesTemp => Convert.ToInt32(edgesTemp));
                }

                int s = Convert.ToInt32(sr.ReadLine());

                int[] result = shortestReach(n, edges, s);

                Console.WriteLine(string.Join(" ", result));
            }
        }
    }
}

