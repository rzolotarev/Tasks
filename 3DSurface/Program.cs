using System;
using System.Collections.Generic;

namespace _3DSurface
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        static int SurfaceArea(int[][] A) 
        {        
            var height = A.Length;
            var width = A[0].Length;
            var topDaownPair = height * width * 2;
            var result = topDaownPair;
          
            var mostTollestH = new int[height];
            var mostTollestW = new int[width];
            FillMax(mostTollestH, mostTollestW, A);

            var currentSum = 0;
            foreach(var item in mostTollestH) {
                currentSum += item;
            }
            result+= 2 * currentSum;
            currentSum = 0;
            foreach(var item in mostTollestW) {
                currentSum += item;
            }

            result+= 2 * currentSum;
            return result;
        }

        static void FillMax(int[] mostTollestH, int[] mostTollestW, int[][] A)
        {
            var height = A.Length;
            var width = A[0].Length;
            var i = height - 1;
            var j = width - 1;
            while ((i | j) > 0) 
            {                
                if (i > 0)
                    i--;
                if (j > 0)
                    j--;

                var max = 0;
                for(var w = 0; w < width; w++){
                    max = Math.Max(A[i][w], max);
                }
                mostTollestH[i] = max;

                max = 0;
                for(var h = 0; h < height; h++){
                    max = Math.Max(A[h][j], max);
                }
                mostTollestW[j] = max;                
            }
        }
    }
}
