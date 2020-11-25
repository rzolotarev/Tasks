using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;

namespace MinimumPenaltyPath
{
    class Program
    {
        static int nodesNumber = 0;
        static void Main(string[] args)
        {
            using(var str = new StreamReader("test1.txt")) 
            {
                while(!str.EndOfStream)
                {
                    var line = str.ReadLine();                    
                    string[] nm = line.Split(' ');

                    int n = Convert.ToInt32(nm[0]);
                    nodesNumber = n;
                    int m = Convert.ToInt32(nm[1]);

                    int[][] edges = new int[m][];

                    for (int i = 0; i < m; i++) {
                        edges[i] = Array.ConvertAll(str.ReadLine().Split(' '), edgesTemp => Convert.ToInt32(edgesTemp));
                    }
                    
                    string[] AB = str.ReadLine().Split(' ');                    
                    int A = Convert.ToInt32(AB[0]);

                    int B = Convert.ToInt32(AB[1]);

                    int result = BeautifulPath(edges, A, B);

                    Console.WriteLine(result);
               }
            }
        }

        static int BeautifulPath(int[][] edges, int A, int B)
        {
            var graph = new Node[nodesNumber + 1];
            for(var i = 0; i <= nodesNumber; i++) {
                graph[i] = new Node();
            }   

            for(var i = 0; i < edges.Length; i++)
            {
                graph[edges[i][0]].Adjacent.Add(new Node(edges[i][1], edges[i][2]));
                graph[edges[i][1]].Adjacent.Add(new Node(edges[i][0], edges[i][2]));         
            }
            
            var queue = new Queue<int>();
            graph[A].Penalty = 0;
            graph[A].Path = 0;
            queue.Enqueue(A);
            while(queue.Count > 0)
            {
                var current = queue.Dequeue();                
                foreach(var adj in graph[current].Adjacent)
                {                                         
                    var penalty = graph[current].Penalty | adj.Path;
                    if (penalty < graph[adj.Number].Penalty)
                    {
                        graph[adj.Number].Penalty = penalty;
                        queue.Enqueue(adj.Number);
                    }                    
                }
            }

            return graph[B].Penalty == Int32.MaxValue ? -1 : graph[B].Penalty;            
        }

        class Node 
        {
            public int Number { get; set; }
            public int Path { get; set; }
            public List<Node> Adjacent { get; set; }            
            public int Penalty { get; set; }

            public Node()
            {
                Adjacent = new List<Node>();
                Penalty = Int32.MaxValue;
            }

            public Node(int number, int path)
            {
                Number = number;
                Path = path;             
                Penalty = Int32.MaxValue;   
                Adjacent = new List<Node>();
            }
        }
    }
}
