using System;

namespace SherlockAndCost
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }

        static int Cost(int[] B)
        {
            var n = B.Length;
            var maxDiffs = new int[n, 2];
            maxDiffs[0, 0] = 1;
            maxDiffs[0, 1] = B[0];
            maxDiffs[1, 0] = Math.Abs(B[0] - 1);
            maxDiffs[1, 1] = Math.Max(B[1] - B[0], B[1] - 1);
            for (var i = 2; i < n; i++)
            {
                maxDiffs[i, 0] = Math.Max(maxDiffs[i-1, 0], maxDiffs[i-1,1] + Math.Abs(B[i-1] - 1));
                maxDiffs[i, 1] = Math.Max(maxDiffs[i - 1, 0] + Math.Abs(B[i] - 1), 
                                          maxDiffs[i - 1, 1] + Math.Abs(B[i - 1] - B[i]));
            }

            return Math.Max(maxDiffs[n-1,0], maxDiffs[n-1,1]);
        }
    }
}
