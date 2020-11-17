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
            var topDownPair = height * width * 2; // calculated two areas
            var result = topDownPair;

            for(int i = 0; i < height; i++) {
                result += (A[i][0] + A[i][width - 1]);
                for(int j = 1; j < width; j++){
                    result += Math.Abs(A[i][j] - A[i][j-1]);
                }
            }
            
            for(int j = 0; j < width; j++) {
                result += (A[0][j] + A[height - 1][j]);
                for(int i = 1; i < height; i++){
                    result += Math.Abs(A[i][j] - A[i-1][j]);
                }
            }            
            
            return result;
        }        
    }
}
