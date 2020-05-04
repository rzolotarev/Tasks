using System;

namespace Knapska01
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] val = {10, 40, 30, 50};
            int[] wt = {5, 4, 6, 3};
            var capacity = 10;
            Console.WriteLine($"Max value {GetMaxValue(capacity, val, wt)}");
        }

        private static int GetMaxValue(int capacity, int[] values, int[] weights)
        {
            int[,] maxValues = new int[values.Length + 1, capacity + 1]; // exists 0 line and column as starting point
            // default values are zero, hence we can skip initializing of line and column indexed by 0
            for (var itemIndex = 1; itemIndex <= values.Length; itemIndex++)
            {
                for (int currentCapacity = 1; currentCapacity <= capacity; currentCapacity++)
                {
                    var maxValueWithoutCurrentItem = maxValues[itemIndex - 1, currentCapacity];

                    var maxValueWithCurrentItem = 0; 
                    var itemWeight = weights[itemIndex - 1];
                    var itemValue = values[itemIndex - 1];
                    // check the ability to take
                    if (currentCapacity >= itemWeight)
                        maxValueWithCurrentItem = itemValue + maxValues[itemIndex - 1, currentCapacity - itemWeight];

                    maxValues[itemIndex, currentCapacity] = Math.Max(maxValueWithoutCurrentItem, maxValueWithCurrentItem);
                }    
            }

            return maxValues[values.Length, capacity];
        }
    }
}
