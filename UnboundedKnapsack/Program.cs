using System;

namespace UnboundedKnapsack {
    class Program {
        static void Main (string[] args) {
            Console.WriteLine (unboundedKnapsack (22, new int[] { 4, 7 }));
        }

        static int unboundedKnapsack (int k, int[] arr) {
            var dp = new int[k + 1];
            for (var i = 1; i <= k; i++) {
                // variable "i" is capacity
                for (var j = 1; j <= arr.Length; j++) {
                    // are we able to take the item
                    if (i < arr[j - 1])
                        continue;

                    // var remainder = i % arr[j - 1];
                    dp[i] = Math.Max (dp[i], dp[i - arr[j - 1]] + arr[j - 1]);
                }
            }

            return dp[k];
        }

    }
}