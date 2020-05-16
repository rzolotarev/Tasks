using System.Linq;
using System;
using System.Collections.Generic;

namespace MinHeaps
{
    public class Node
    {
        public int Index;
        public int Path;
        public int PrecedingNode;
        public bool Visited;
        public bool InQueue;
    }


    public class MinHeap
    {
        private List<Node> queue = new List<Node>();
        public int Count;

        public void Add(Node node, bool reorder = false)
        {
            if (queue.Count > Count)
                queue[Count] = node;
            else
                queue.Add(node);

            Count++;
            if (reorder)
                Reorder();
        }

        public void Reorder()
        {
            for (var i = Count / 2 - 1; i >= 0; i--)
            {
                if (2 * i + 2 == Count)
                {
                    if (queue[2 * i + 1].Path < queue[i].Path)
                    {
                        var temp = queue[i];
                        queue[i] = queue[2 * i + 1];
                        queue[2 * i + 1] = temp;
                    }
                }
                else
                {

                    if (queue[2 * i + 2].Path < queue[2 * i + 1].Path)
                    {
                        if (queue[2 * i + 2].Path < queue[i].Path)
                        {
                            var temp = queue[i];
                            queue[i] = queue[2 * i + 2];
                            queue[2 * i + 2] = temp;
                        }
                    }
                    else
                    {
                        if (queue[2 * i + 1].Path < queue[i].Path)
                        {
                            var temp = queue[i];
                            queue[i] = queue[2 * i + 1];
                            queue[2 * i + 1] = temp;
                        }
                    }
                }
            }
        }

        public Node Get()
        {
            var min = queue[0];
            queue[0] = queue[Count - 1];
            Count--;
            Reorder();
            return min;
        }
    }
}