using System;
using System.Collections.Generic;

namespace CombinationsOfKFromN
{
    class Program
    {
        private static Dictionary<Pair, int> cache = new Dictionary<Pair, int>();

        static void Main(string[] args)
        {
            var number = Combinations(100, 5);
            Console.WriteLine($"number of combinations {number}");
        }

        private static int Combinations(int n, int k)
        {
            if (n < k)
                return 0;

            if (n == k)
                return 1;
            if (k == 1)
                return n;

            var pair = new Pair() {K = k, N = n};
            if (cache.ContainsKey(pair))
                return cache[pair];

            var withFixedElement = Combinations(n-1, k-1);
            cache.TryAdd(new Pair() { K = k - 1, N = n - 1}, withFixedElement);
            var withoutFixedElement = Combinations(n - 1, k);
            cache.TryAdd(new Pair() { K = k, N = n - 1 }, withoutFixedElement);
            return withoutFixedElement + withFixedElement;
        }

        struct Pair
        {
            public int N { get; set; }
            public int K { get; set; }
        }
    }
}
