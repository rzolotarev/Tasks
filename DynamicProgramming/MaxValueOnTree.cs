using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicProgramming
{
    class MaxValueOnTree
    {
        static int[] dp = new int[100];

        // function for dfs traversal and to  
        // store the maximum value in []dp  
        // for every node till the leaves 
        static void dfs(int[] weights, List<int>[] vertices,
                        int currentNode, int parentNode)
        {

            // initially dp[u] is always a[u] since a starts from zero
            dp[currentNode] = weights[currentNode - 1];

            // stores the maximum value from nodes 
            int maximum = 0;

            // traverse the tree 
            foreach (int child in vertices[currentNode])
            {

                // if child is parent, then we continue 
                // without recursing further 
                if (child == parentNode)
                    continue;

                // call dfs for further traversal 
                dfs(weights, vertices, child, currentNode);

                // store the maximum of previous visited  
                // node and present visited node 
                maximum = Math.Max(maximum, dp[child]);
            }

            // add the maximum value returned 
            // to the parent node 
            dp[currentNode] += maximum;
        }

        // function that returns the maximum value 
        static int maximumValue(int[] weights,
                                List<int>[] vertices)
        {
            dfs(weights, vertices, 1, 0);
            return dp[1];
        }

        // Driver Code 
        public static void Calculate()
        {

            // Driver Code 
            int n = 14;

            // adjacency list 

            List<int>[] v = new List<int>[n + 1];

            for (int i = 0; i < v.Length; i++)
                v[i] = new List<int>();

            // create undirected edges 
            // initialize the tree given in the diagram 
            v[1].Add(2); v[2].Add(1);
            v[1].Add(3); v[3].Add(1);
            v[1].Add(4); v[4].Add(1);
            v[2].Add(5); v[5].Add(2);
            v[2].Add(6); v[6].Add(2);
            v[3].Add(7); v[7].Add(3);
            v[4].Add(8); v[8].Add(4);
            v[4].Add(9); v[9].Add(4);
            v[4].Add(10); v[10].Add(4);
            v[5].Add(11); v[11].Add(5);
            v[5].Add(12); v[12].Add(5);
            v[7].Add(13); v[13].Add(7);
            v[7].Add(14); v[14].Add(7);

            // values of node 1, 2, 3....14 
            int[] wieghts = { 3, 2, 1, 10, 1, 3, 9,
                    1, 5, 3, 4, 5, 9, 8 };

            // function call 
            Console.WriteLine(maximumValue(wieghts, v));
        }
    }
}
