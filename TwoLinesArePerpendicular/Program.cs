using System;
using System.Collections.Generic;

namespace TwoLinesArePerpendicular
{
    class Program
    {
        static void Main(string[] args)
        {
            var point1 = new Point() { X = 0, Y = 3};
            var point2 = new Point() { X = 0, Y = -5 };
            var point3 = new Point() { X = 2, Y = 0 };
            var point4 = new Point() { X = -1, Y = 0 };
            Console.WriteLine(CheckOrtho(point1, point2, point3, point4));

            point1 = new Point() { X = 0, Y = 4 };
            point2 = new Point() { X = 0, Y = -9 };
            point3 = new Point() { X = 2, Y = 0 };
            point4 = new Point() { X = -1, Y = 0 };
            Console.WriteLine(CheckOrtho(point1, point2, point3, point4));

            point1 = new Point() { X = 3, Y = 1 };
            point2 = new Point() { X = -3, Y = -1 };
            point3 = new Point() { X = -1, Y = 3 };
            point4 = new Point() { X = 1, Y = -3 };
            Console.WriteLine(CheckOrtho(point1, point2, point3, point4));
        }

        private static bool CheckOrtho(Point point1, Point point2, Point point3, Point point4)
        {
            var diffX1 = point1.X - point2.X;
            var diffY1 = point1.Y - point2.Y;
            var diffX2 = point3.X - point4.X;
            var diffY2 = point3.Y - point4.Y;
            if (diffX1 == 0)
                return diffY2 == 0 && diffX2 != 0;
            var ls = new LinkedList<int>();
            LinkedListNode<int> p1 = ls.First;
            p1.Next
            ls.AddLast()
            if(diffX2 == 0)
                return diffY1 == 0 && diffX1 != 0;
            
            return (diffY1 * diffY2) / (diffX1 * diffX2) == -1;
        }

        class Point
        {
            public int X { get; set; }
            public int Y { get; set; }
        }
    }
}
