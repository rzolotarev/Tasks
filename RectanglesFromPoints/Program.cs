using System;
using System.Collections.Generic;

namespace RectanglesFromPoints
{
    class Program
    {
        static void Main(string[] args)
        {
            var points = new List<Point>()
            {
                new Point(0,0),
                new Point(0,1),
                new Point(0,2),
                new Point(1,0),
                new Point(1,1),
                new Point(1,2),
                new Point(2,0),
                new Point(2,1),
                new Point(2,2)
            };

            var number = GetNumberOfRectangles(points);
            Console.WriteLine($"{number} of rectangles");
        }

        private static int GetNumberOfRectangles(List<Point> points)
        {
            var number = 0;
            var pairSet = new Dictionary<PairY, int>(); 
            foreach (var point1 in points)
                foreach (var point2 in points)
                {
                    if (point1.X == point2.X && point1.Y < point2.Y)
                    {
                        var pair = new PairY(point1.Y, point2.Y);
                        pairSet.TryAdd(pair, 0);
                        number += pairSet[pair]; // calculating number of all combinations of vertical pairs
                        pairSet[pair]++;
                    }
                }

            return number;
        }


        struct PairY
        {
            private int Y1 { get; set; }
            private int Y2 { get; set; }

            public PairY(int y1, int y2)
            {
                Y1 = y1;
                Y2 = y2;
            }
        }
        
        class Point
        {
            public int X { get; set; }
            public int Y { get; set; }

            public Point(int x, int y)
            {
                X = x;
                Y = y;
            }
        }
    }
}
