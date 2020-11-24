
using System;

namespace UnionSets {

    public class UnionSet
    {
        public int[] Ranks { get; set; }        
        public int[] Parents { get; set; } 
        public int[] Groups { get; set; }       
        public int N { get; set; }

        public UnionSet(int n)
        {
            Ranks = new int[n];            
            Parents = new int[n];            
            Groups = new int[n];
            N = n;
            InitializeParents();
        }

        private void InitializeParents() 
        {
            for(int i = 0; i < N; i++)
            {
                Parents[i] = i;                
                Groups[i] = 1;
            }            
        }

        public int FindRoot(int node)
        {
            if (node != Parents[node])
            {                       
                Parents[node] = FindRoot(Parents[node]);                
            }

            return Parents[node];
        }

        public void Union(int x, int y)
        {
            int xRoot = FindRoot(x);
            int yRoot = FindRoot(y);

            if (xRoot == yRoot)
                return;
            
            if (Ranks[xRoot] > Ranks[yRoot])
            {
                Parents[yRoot] = xRoot;
                Groups[xRoot] += Groups[yRoot];
                Groups[yRoot] = 0;             
            }
            else 
            {
                if (Ranks[xRoot] < Ranks[yRoot]) 
                {
                    Parents[xRoot] = yRoot;
                    Groups[yRoot] += Groups[xRoot];
                    Groups[xRoot] = 0;
                }
                else 
                {
                    Parents[yRoot] = xRoot;
                    Groups[xRoot] += Groups[yRoot];
                    Groups[yRoot] = 0;
                    Ranks[xRoot] = Ranks[xRoot] + 1;
                }
            }                       
        }
    }
}