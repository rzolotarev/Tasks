using System;
using System.Linq;

namespace COintOnTableDP
{
    class Program
    {

        private static char[][] board;
        static void Main(string[] args)
        {
            string[] nmk = Console.ReadLine().Split(' ');

            int n = Convert.ToInt32(nmk[0]);

            int m = Convert.ToInt32(nmk[1]);

            var k = Convert.ToInt32(nmk[2]);

            board = new char[n][];

            for (int boardItr = 0; boardItr < n; boardItr++)
            {
                string boardItem = Console.ReadLine();
                board[boardItr] = boardItem.ToCharArray();
            }

            Console.WriteLine(coinOnTheTable(m, k, n));
        }

        static int coinOnTheTable(int m, int k, int n)
        {
            var dp = new int[k + 1][][];

            // intialize dp with int.MaxValue
            for (var i = 0; i <= k; i++)
            {
                dp[i] = new int[n][];
                for (var j = 0; j < n; j++)
                    dp[i][j] = Enumerable.Repeat(Int32.MaxValue, m).ToArray();
            }
            for (var i = 0; i <= k; i++)
                dp[i][0][0] = 0;

            for (var time = 1; time <= k; time++)
            {
                for (var i = 0; i < board.Length; i++)
                {
                    for (var j = 0; j < board[i].Length; j++)
                    {
                        if (i == 0 && j == 0)
                            continue;

                        var minimum = dp[time - 1][i][j]; // keep the previous minimum
                        if (i > 0 && board[i - 1][j] != '*')
                            minimum = Math.Min(minimum,
                                dp[time - 1][i - 1][j] + board[i - 1][j] == 'D' ? 0 : 1);
                        if (i < board.Length - 1 && board[i + 1][j] != '*')
                        {
                            minimum = Math.Min(minimum, dp[time - 1][i + 1][j] + board[i + 1][j] == 'U' ? 0 : 1);
                        }
                        if (j > 0 && board[i][j - 1] != '*')
                            minimum = Math.Min(minimum, dp[time - 1][i][j - 1] + board[i][j - 1] == 'R' ? 0 : 1);
                        if (j < board[i].Length - 1 && board[i][j + 1] != '*')
                            minimum = Math.Min(minimum, dp[time - 1][i][j + 1] + board[i][j + 1] == 'L' ? 0 : 1);

                        dp[time][i][j] = minimum;
                    }
                }
            }

            for (var i = 0; i < board.Length; i++)
            {
                for (var j = 0; j < board[i].Length; j++)
                {
                    if (board[i][j] == '*')
                    {
                        return dp[k][i][j];
                    }
                }
            }

            return -1;
        }
    }
}