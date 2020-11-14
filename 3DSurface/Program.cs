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
            var innerSurface = FillMax(mostTollestH, mostTollestW, A);
            result += innerSurface;            
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

        static int FillMax(int[] mostTollestH, int[] mostTollestW, int[][] A)
        {
            var height = A.Length;
            var width = A[0].Length;
            var i = height;
            var j = width;
            var innerSurface = 0;
            while ((i | j) > 0) 
            {                
                if (i > 0)
                    i--;
                if (j > 0)
                    j--;

                var max = 0;
                for(var w = 0; w < width; w++)
                {
                    if ( w > 0 && w < width - 1 && mostTollestH[i] == 0)
                    {
                        if (A[i][w -1] > A[i][w] && A[i][w + 1] > A[i][w])
                            innerSurface += 2 * (Math.Min(A[i][w + 1], A[i][w - 1]) - A[i][w]);
                    }
                    max = Math.Max(A[i][w], max);
                }
                mostTollestH[i] = max;

                max = 0;
                for(var h = 0; h < height; h++)
                {
                    if ( h > 0 && h < height - 1 && mostTollestW[j] == 0)
                    {
                        if (A[h - 1][j] > A[h][j] && A[h + 1][j] > A[h][j])
                            innerSurface += 2 * (Math.Min(A[h - 1][j], A[h + 1][j]) - A[h][j]);
                    }
                    max = Math.Max(A[h][j], max);
                }
                mostTollestW[j] = max;
            }

            return innerSurface;
        }
    }
}
