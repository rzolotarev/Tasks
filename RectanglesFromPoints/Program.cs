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
                    // order doesn't matter because we always have ordered pair
                    // never (2,1)
                    if (point1.X == point2.X && point1.Y < point2.Y)
                    {
                        var pair = new PairY(point1.Y, point2.Y);
                        pairSet.TryAdd(pair, 0);
                        pairSet[pair]++;
                        // calculating number of all combinations of vertical pairs
                        // C(n,k) = C(n-1, k) + C(n-1, k-1)
                        // C(n, 2) = C(n-1, 2) + C(n-1, 1)
                        // C(n-1, 1) = number of found verticle lines
                        number += (pairSet[pair] - 1);
                    }
                }

            return number;
        }

        private static int GetNumberOfRectanglesEventWithDifferentX(List<Point> points)
        {

            return 0;
        }

        private static bool CheckRectangular()
        {
            return false;
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
