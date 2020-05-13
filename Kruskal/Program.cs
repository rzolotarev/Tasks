using System.IO;
using System.Linq;
using System.Collections.Generic;
using System;

namespace Kruskal
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var fs = new FileStream("Input.txt", FileMode.Open))
            {
                using (var sr = new StreamReader(fs))
                {
                    string[] gNodesEdges = sr.ReadLine().TrimEnd().Split(' ');

                    int gNodes = Convert.ToInt32(gNodesEdges[0]);
                    int gEdges = Convert.ToInt32(gNodesEdges[1]);

                    List<int> gFrom = new List<int>();
                    List<int> gTo = new List<int>();
                    List<int> gWeight = new List<int>();

                    for (int i = 0; i < gEdges; i++)
                    {
                        string[] gFromToWeight = sr.ReadLine().TrimEnd().Split(' ');

                        gFrom.Add(Convert.ToInt32(gFromToWeight[0]));
                        gTo.Add(Convert.ToInt32(gFromToWeight[1]));
                        gWeight.Add(Convert.ToInt32(gFromToWeight[2]));
                    }

                    int res = kruskals(gNodes, gFrom, gTo, gWeight);

                    Console.WriteLine(res);
                }
            }
        }
        public static int kruskals(int gNodes, List<int> gFrom, List<int> gTo, List<int> gWeight)
        {
            var edges = new Edge[gFrom.Count];
            for (var i = 0; i < gFrom.Count; i++)
                edges[i] = new Edge() { From = gFrom[i], To = gTo[i], Weight = gWeight[i] };
            // sort by weights
            Array.Sort(edges, new EdgeComparator());

            var subsets = new Subset[gNodes + 1];
            for (var i = 1; i <= gNodes; i++)
            {
                subsets[i] = new Subset();
                subsets[i].Parent = i;
                subsets[i].Rank = 0;
            }

            var minSpanTreeNodes = gNodes - 1;
            var includedEdges = 0;
            var index = -1;
            var resultSum = 0;
            // TODO: could be that there is no connected node
            while (includedEdges < minSpanTreeNodes)
            {
                index++;
                var edge = edges[index];
                var subsetFrom = FindSubset(subsets, edge.From);
                var subsetTo = FindSubset(subsets, edge.To);

                // there is a loop
                if (subsetFrom == subsetTo)
                    continue;

                Union(subsets, subsetFrom, subsetTo);
                resultSum += edge.Weight;
                includedEdges++;
            }

            return resultSum;
        }

        private static int FindSubset(Subset[] subsets, int node)
        {
            if (subsets[node].Parent == node)
                return node;

            return FindSubset(subsets, subsets[node].Parent);
        }

        private static void Union(Subset[] subsets, int from, int To)
        {
            if (subsets[from].Rank == subsets[To].Rank)
            {
                subsets[To].Parent = from;
                subsets[from].Rank++;
                return;
            }

            if (subsets[from].Rank < subsets[To].Rank)
                subsets[from].Parent = To;
            else
                subsets[To].Parent = from;
        }
        public class Subset
        {
            public int Parent { get; set; }
            public int Rank { get; set; }
        }

        public class Edge
        {
            public int From { get; set; }
            public int To { get; set; }
            public int Weight { get; set; }
        }

        public class EdgeComparator : IComparer<Edge>
        {
            public int Compare(Edge x, Edge y)
            {
                return x.Weight.CompareTo(y.Weight);
            }
        }
    }
}
