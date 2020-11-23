using System;
using UnionSets;
using System.Linq;

namespace JourneyToTheMoon
{
    class Program
    {        
        static void Main(string[] args)
        {            
            var n = 10;
            var astronaut = new int[7][];            
            astronaut[0] = new int[2] {0, 2};
            astronaut[1] = new int[2] {1, 8};
            astronaut[2] = new int[2] {1, 4};
            astronaut[3] = new int[2] {2, 8};
            astronaut[4] = new int[2] {2, 6};
            astronaut[5] = new int[2] {3, 5};
            astronaut[6] = new int[2] {6, 9};
            Console.WriteLine(JourneyToMoon(n, astronaut));
        }

        static int JourneyToMoon(int n, int[][] astronaut) 
        {
            // preparing disjoint set
            var unionSet = new UnionSet(n);             
            for(int i = 0; i < astronaut.Length; i++)            
                unionSet.Union(astronaut[i][0], astronaut[i][1]);
                          
            // symmary of all countries
            var sum = 0;
            var countries = unionSet.Parents.GroupBy(p => p).Select(p => p.Count()).ToList<int>();            
            // foreach(var rank in countries)
            //     Console.WriteLine(rank);
            for(int i = countries.Count() - 1; i > 0; i--)            
                for(int j = i - 1; j >= 0; j--)                
                    sum += countries[i] * countries[j];

            return sum;
        }
    }
}
