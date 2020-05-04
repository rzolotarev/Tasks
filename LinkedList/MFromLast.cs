using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedList
{
    public class MFromLast
    {

        public void Run()
        {
            var m = int.Parse(Console.ReadLine());
            var elements = Console.ReadLine();
            var array = elements.Split(' ');
            var linkedList = new LinkedList<int>();
            foreach (var item in array)
                linkedList.AddLast(int.Parse(item));

            if (array.Length < m)
            {
                Console.WriteLine("NIL");
                return;
            }

            LinkedListNode<int> p1 = linkedList.First;
            LinkedListNode<int> p2 = linkedList.First;
            for (var i = 0; i < m - 1; i++)
                p2 = p2.Next;


            while (p2.Next != null)
            {
                p1 = p1.Next;
                p2 = p2.Next;
            }

            Console.WriteLine(p1);
        }
    }
}
