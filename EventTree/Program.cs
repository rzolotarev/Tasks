using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace EventTree
{
    class Program
    {
        static void Main(string[] args)
        {
                using(var strReader = new StreamReader("test.txt"))
                {
                        string[] tNodesEdges = strReader.ReadLine().TrimEnd().Split(' ');

                        int tNodes = Convert.ToInt32(tNodesEdges[0]);
                        int tEdges = Convert.ToInt32(tNodesEdges[1]);

                        List<int> tFrom = new List<int>();
                        List<int> tTo = new List<int>();

                        for (int i = 0; i < tEdges; i++) {
                            string[] tFromTo = strReader.ReadLine().TrimEnd().Split(' ');

                            tFrom.Add(Convert.ToInt32(tFromTo[0]));
                            tTo.Add(Convert.ToInt32(tFromTo[1]));
                        }

                        int res = evenForest(tNodes, tEdges, tFrom, tTo);
                        Console.WriteLine(res);                        
                }
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


            var visited = new bool[t_nodes + 1];
            var dependentVertices = new int[t_nodes + 1];         
            visited[1] = true;

            var result = 0;
            TraverseGraph(graph, 1, visited, dependentVertices);
            foreach(var i in dependentVertices){
                Console.WriteLine(i);
            }
            result = dependentVertices.Where(x => x != 0 && x % 2 == 0).Count();
            return result - 1;
        }

        static void TraverseGraph(List<int>[] graph, int node, bool[] visited, int[] dependentVertices)
        {
            visited[node] = true;

            foreach(var vertex in graph[node]) {
                if (visited[vertex])
                    continue;
                                
                TraverseGraph(graph, vertex, visited, dependentVertices);
                dependentVertices[node] += dependentVertices[vertex];                
                // return;                
            }
            dependentVertices[node] += 1;            
        }
    }
}
