using System.IO;
using System.Linq;
using System.Collections.Generic;
using System;

namespace BFS
{
    class Program
    {

        static void Main(string[] args)
        {
            using (var fs = new FileStream("inputtxt", FileMode.Open))
            {
                using (var streamReader = new StreamReader(fs))
                {
                    int q = Convert.ToInt32(streamReader.ReadLine());

                    for (int qItr = 0; qItr < q; qItr++)
                    {
                        string[] nm = streamReader.ReadLine().Split(' ');

                        int n = Convert.ToInt32(nm[0]);

                        int m = Convert.ToInt32(nm[1]);

                        int[][] edges = new int[m][];

                        for (int i = 0; i < m; i++)
                        {
                            var line = streamReader.ReadLine();
                            edges[i] = Array.ConvertAll(line.Split(' '), edgesTemp => Convert.ToInt32(edgesTemp));
                        }

                        int s = Convert.ToInt32(streamReader.ReadLine());

                        int[] result = bfs(n, m, edges, s);

                        Console.WriteLine(result);
                    }
                }
            }
        }


        // Complete the bfs function below.
        static int[] bfs(int n, int m, int[][] edges, int s)
        {
            var visitedNodes = new HashSet<int>(n);
            var graph = new List<int>[n + 1];
            for (var i = 0; i < n + 1; i++)
                graph[i] = new List<int>();
            for (int i = 0; i < m; i++)
            {
                if (edges[i].Length == 1)
                    continue;

                graph[edges[i][0]].Add(edges[i][1]);
                graph[edges[i][1]].Add(edges[i][0]);
            }

            var result = new int[n - 1];
            for (var i = 0; i < n - 1; i++)
                result[i] = -1;

            var queue = new Queue<int>();
            queue.Enqueue(s);
            var pathesMap = new Dictionary<int, int>();
            pathesMap.Add(s, 0);
            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                visitedNodes.Add(node);

                var path = pathesMap[node] + 6;

                foreach (var adjacent in graph[node])
                {
                    if (visitedNodes.Contains(adjacent))
                        continue;

                    if (pathesMap.ContainsKey(adjacent))
                        continue;
                    else
                        pathesMap.Add(adjacent, path);

                    if (adjacent < s)
                        result[adjacent - 1] = path;
                    else
                        result[adjacent - 2] = path;

                    queue.Enqueue(adjacent);
                }
            }

            return result;
        }
    }
}
