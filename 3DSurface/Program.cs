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
          
            var mostTollestH = new List<int>();
            var mostTollestW = new List<int>();
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

        static void FillMax(List<int> mostTollestH, List<int> mostTollestW, int[][] A)
        {
            var height = A.Length;
            var width = A[0].Length;
            var i = 0;
            var j = 0;
            while (i < height && j < width) 
            {
                var max = 0;
                for(var w = 0; w < width; w++){
                    max = Math.Max(A[i][w], max);
                }

                mostTollestH.Add(max);
                max = 0;
                for(var h = 0; h < height; h++){
                    max = Math.Max(A[h][j], max);
                }
                mostTollestW.Add(max);
                i++;
                j++;
            }
        }
    }
}
