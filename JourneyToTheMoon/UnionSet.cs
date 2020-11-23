
using System;

namespace UnionSets {

    public class UnionSet
    {
        public int[] Ranks { get; set; }
        public int[] Parents { get; set; }        
        public int N { get; set; }

        public UnionSet(int n)
        {
            Ranks = new int[n];
            Parents = new int[n];            
            N = n;
            InitializeParents();
        }

        private void InitializeParents() 
        {
            for(int i = 0; i < N; i++)
            {
                Parents[i] = i;                
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
                for(var i = 0; i < N; i++)
                {
                    if (Parents[i] == yRoot)
                        Parents[i] = xRoot;
                }             
            }
            else 
            {
                if (Ranks[xRoot] < Ranks[yRoot]) 
                {
                    Parents[xRoot] = yRoot;
                    for(var i = 0; i < N; i++)
                    {
                        if (Parents[i] == xRoot)
                            Parents[i] = yRoot;
                    }              
                }
                else 
                {
                    Parents[yRoot] = xRoot;
                    for(var i = 0; i < N; i++)
                    {
                        if (Parents[i] == yRoot)
                            Parents[i] = xRoot;
                    }
                    Ranks[xRoot] = Ranks[xRoot] + 1;         
                }
            }                       
        }
    }
}