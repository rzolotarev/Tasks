using System.Linq;
using System;

namespace MinHeaps
{
    public class Node
    {
        public int Key { get; set; }
        public int Vertex { get; set; }
        public bool IsMST { get; set; }
        public int Parent { get; set; }
    }

    public class MinHeap
    {
        private Node[] nodes;
        public MinHeap(int n)
        {
            nodes = new Node[n + 1];
            nodes[0] = new Node() { IsMST = true, Vertex = -1, Key = Int32.MaxValue };
        }

        public void Enqueue(Node node)
        {
            nodes[node.Vertex] = node;
        }

        public int Count
        {
            get
            {
                return nodes.Where(n => !n.IsMST).Count();
            }
        }

        public Node Pull()
        {
            var min = nodes.Where(n => !n.IsMST).OrderBy(n => n.Key).Take(1).Single();
            return min;
        }
    }
}