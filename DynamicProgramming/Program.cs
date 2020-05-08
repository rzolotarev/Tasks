using System;
using System.Collections.Generic;
using System.Linq;

namespace DynamicProgramming
{
    class Program
    {

        static int GetHeightFromRight(int idx, int[] ranking, int[] candy)
        {
            // 5 cases
            //   2
            // 1   1
            // 2   2
            //   1
            //     3
            //   2
            // 1   
            // 1  
            //   2 
            //     3
            // 1 1 1 
            if (idx == ranking.Length - 1)
            {
                if (ranking[idx - 1] < ranking[idx])
                    candy[idx] = candy[idx - 1] + 1;

                if (ranking[idx - 1] >= ranking[idx])
                    candy[idx] =  1;

                return candy[idx];
            }
                

            if (ranking[idx] > ranking[idx - 1] && ranking[idx] > ranking[idx + 1]) // local max
                candy[idx] = Math.Max(candy[idx - 1], GetHeightFromRight(idx + 1, ranking, candy)) + 1;
            else if (ranking[idx + 1] < ranking[idx])
                candy[idx] = GetHeightFromRight(idx + 1, ranking, candy) + 1;
            else if (ranking[idx - 1] < ranking[idx])
            {
                candy[idx] = candy[idx - 1] + 1;
                GetHeightFromRight(idx + 1, ranking, candy);
            }
            else
            {
                // local min or if neighbors are equal
                candy[idx] = 1;
                GetHeightFromRight(idx + 1, ranking, candy);
            }

            return candy[idx];
        }

        // Complete the candies function below.
        static long candies(int n, int[] arr)
        {
            var distributed = new int[n];
            if (arr[1] >= arr[0])
            {
                distributed[0] = 1;
                GetHeightFromRight(1, arr, distributed);
            }
            else
                distributed[0] = GetHeightFromRight(1, arr, distributed) + 1;
           

            return distributed.Sum(x => x);
        }

        public static void Main(string[] args)
        {
            var n = 10;
            var arr = new int[] {2,
                4,
                2,
                6,
                1,
                7,
                8,
                9,
                2,
                1};
            var distributed = new int[n];
            if (arr[1] >= arr[0])
            {
                distributed[0] = 1;
                GetHeightFromRight(1, arr, distributed);
            }
            else
                distributed[0] = GetHeightFromRight(1, arr, distributed) + 1;


            var a= distributed.Sum(x => x);
        }
    }
}
