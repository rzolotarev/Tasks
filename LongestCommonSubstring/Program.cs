using System;
using System.Linq;

namespace LongestCommonSubstring {
    class Program {

        static int lcs2 (char[] X, char[] Y, int m, int n) {
            int[, ] L = new int[m + 1, n + 1];

            /* Following steps build L[m+1][n+1]  
            in bottom up fashion. Note 
            that L[i][j] contains length of  
            LCS of X[0..i-1] and Y[0..j-1] */
            for (int i = 0; i <= m; i++) {
                for (int j = 0; j <= n; j++) {
                    if (i == 0 || j == 0)
                        L[i, j] = 0;
                    else if (X[i - 1] == Y[j - 1]) {
                        L[i, j] = L[i - 1, j - 1] + 1;
                    } else
                        L[i, j] = max (L[i - 1, j], L[i, j - 1]);
                }
            }

            var k = m;
            var l = n;
            var trace = new int[L[m, n]];
            var index = L[m, n] - 1;
            while (k > 0 && l > 0) {
                if (X[k - 1] == Y[l - 1]) {
                    trace[index] = X[k - 1];
                    k--;
                    l--;
                    index--;
                    continue;
                }

                if (L[k - 1, l] > L[k, l - 1])
                    k--;
                else
                    l--;
            }

            for (var i = 0; i < trace.Length; i++)
                Console.WriteLine (trace[i]);

            return L[m, n];
        }
        /* Returns length of LCS for X[0..m-1], Y[0..n-1] */
        static int lcs (char[] X, char[] Y, int m, int n) {
            if (m == 0 || n == 0)
                return 0;
            if (X[m - 1] == Y[n - 1])
                return 1 + lcs (X, Y, m - 1, n - 1);
            else
                return max (lcs (X, Y, m, n - 1), lcs (X, Y, m - 1, n));
        }

        /* Utility function to get max of 2 integers */
        static int max (int a, int b) {
            return (a > b) ? a : b;
        }

        static void Main (string[] args) {
            String s1 = "AGGTAB";
            String s2 = "GXTXAYB";

            char[] X = s1.ToCharArray ();
            char[] Y = s2.ToCharArray ();
            int m = X.Length;
            int n = Y.Length;

            Console.WriteLine ("Length of LCS is" + " " +
                lcs2 (X, Y, m, n));
        }
    }
}