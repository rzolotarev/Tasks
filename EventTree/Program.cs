using System;

namespace EventTree
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        static int evenForest(int t_nodes, int t_edges, List<int> t_from, List<int> t_to) 
        {
            if (t_nodes % 2 != 0)
                throw new ArgumentException("t_nodes should be even number");

            var graph = new List<int>[](t_nodes);
            
        }
    }
}
