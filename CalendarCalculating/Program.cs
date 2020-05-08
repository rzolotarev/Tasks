using System;
using System.Collections.Generic;

namespace CalendarCalculating
{
    class Program
    {
        static void Main(string[] args)
        {
            var k = 3;
            var arr = new int[] {1, 3, 5, 7, 9};


            Console.WriteLine(getMinimumCost(k, arr));
        }


        class Comparer : IComparer<int>
        {
            public int Compare(int x, int y)
            {
                return y.CompareTo(x);
            }
        }

        // Complete the getMinimumCost function below.
        static int getMinimumCost(int k, int[] c)
        {
            Array.Sort(c, new Comparer());

            var iterNumber = c.Length / k + c.Length % k == 0 ? 0 : 1; // number of group purchasing
            var previousPurchased = 0;
            var sum = 0;
            var i = 0;
            while (i <= iterNumber)
            {
                var start = i * k;
                var end = Math.Min(c.Length, k * (i + 1));

                for (var j = start; j < end; j++)
                {
                    sum += c[j] * (1 + previousPurchased);
                }

                previousPurchased++;
                i++;
            }

            return sum;
        }
    }
}
