using System;
using System.Linq;

namespace CoinOnTable {
    class Program {
        private static int k;

        private static char[][] board;

        private static int[][] costs;

        static void Main (string[] args) {
            string[] nmk = Console.ReadLine ().Split (' ');

            int n = Convert.ToInt32 (nmk[0]);

            int m = Convert.ToInt32 (nmk[1]);

            k = Convert.ToInt32 (nmk[2]);

            board = new char[n][];

            for (int boardItr = 0; boardItr < n; boardItr++) {
                string boardItem = Console.ReadLine ();
                board[boardItr] = boardItem.ToCharArray ();
            }

            costs = new int[n][];
            for (int i = 0; i < costs.Length; i++) {
                costs[i] = Enumerable.Repeat (Int32.MaxValue, m).ToArray ();
            }

            int result = solve (); //coinOnTheTable (m, k, board);

            Console.WriteLine (result);
        }

        private static int solve () {
            dfs (0, 0, 0, 0);

            for (int i = 0; i < board.Length; i++) {
                for (int j = 0; j < board[i].Length; j++) {
                    Console.Write (costs[i][j]);
                    Console.Write (' ');
                }
                Console.WriteLine ();
            }

            for (int i = 0; i < board.Length; i++) {
                for (int j = 0; j < board[i].Length; j++) {
                    if (board[i][j] == '*') {
                        int minCost = costs[i][j];
                        return minCost == Int32.MaxValue ? -1 : minCost;
                    }
                }
            }

            return -1;
        }

        /// Cost - number of changes
        /// time - length
        ///
        private static void dfs (int i, int j, int cost, int time) {

            if (!inBoard (i, j) || cost >= costs[i][j]) {
                return;
            }

            costs[i][j] = cost;

            if (board[i][j] == '*') {
                return;
            }
            if (time == k) {
                return;
            }

            dfs (i - 1, j, board[i][j] == 'U' ? cost : cost + 1, time + 1);

            dfs (i, j - 1, board[i][j] == 'L' ? cost : cost + 1, time + 1);

            dfs (i + 1, j, board[i][j] == 'D' ? cost : cost + 1, time + 1);

            dfs (i, j + 1, board[i][j] == 'R' ? cost : cost + 1, time + 1);
        }

        private static bool inBoard (int i, int j) {
            var result = i >= 0 && i < board.Length && j >= 0 && j < board[i].Length;
            Console.WriteLine ($"({i},{j}) in Bound {result} ");
            return result;
        }
    }
}