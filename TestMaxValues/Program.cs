using System.Runtime.ConstrainedExecution;
using System;

namespace TestMaxValues
{
    class Program
    {
        static void Main(string[] args)
        {
            var line = "123 123";
            var result = Array.ConvertAll(line.Split(' '), edgesTemp => Convert.ToInt32(edgesTemp));

            foreach (var i in result)
            {

            }
            Console.WriteLine(result.Length);
        }
    }
}