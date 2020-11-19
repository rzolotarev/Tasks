using System;
using System.Collections.Generic;

namespace RoadAndLibraries
{
    class Program
    {
        static void Main(string[] args)
        {
            var cities = new int[3][];
            cities[0] = new int[2];
            cities[1] = new int[2];
            cities[2] = new int[2];
            cities[0][0] = 1;
            cities[0][1] = 2;
            cities[1][0] = 3;
            cities[1][1] = 1;
            cities[2][0] = 2;
            cities[2][1] = 3;          
            Console.WriteLine(RoadsAndLibraries(3, 2, 1, cities));
        }

        static long RoadsAndLibraries(int n, int c_lib, int c_road, int[][] cities) {            
            if (c_lib <= c_road)
                return n * c_lib;
        
            var adjCities = new Dictionary<int, List<int>>();
            for(int i = 1; i < n + 1; i++) {
                adjCities[i] = new List<int>();
            }

            for(int i = 0; i < cities.Length; i++) {
                adjCities[cities[i][0]].Add(cities[i][1]);
                adjCities[cities[i][1]].Add(cities[i][0]);
            }

            var min = 0;
            var visited = new bool[n + 1];
            for(int i = 1; i < n + 1; i++){
                if (visited[i])
                    continue;
                var verticis = Dfs(i, adjCities, visited);

                Console.WriteLine(verticis);
                min += (verticis - 1) * c_road + c_lib;
            }

            return min;
        }

        static int Dfs(int vertex, Dictionary<int, List<int>> cities, bool[] visited) {
            var verticies = 0;
            var stack = new Stack<int>();
            stack.Push(vertex);
            while(stack.Count > 0) {       
                var curNode = stack.Pop();     
                foreach(var node in cities[curNode]){                   
                    if (!visited[node]) {                         
                        stack.Push(node);                             
                    }
                }
                
                if (visited[curNode])
                    continue;

                visited[curNode] = true;
                verticies += 1;                                         
            }

            return verticies;
        }
    }
}
