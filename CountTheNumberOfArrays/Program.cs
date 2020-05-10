using System;

namespace CountTheNumberOfArrays
{
    class Program
    {
        static void Main(string[] args)
        {

            var n = 4;
            var withEndsX = new int[n];
            var withoutEndsX = new int[n];
            var k = 3;
            var x = 2;
            withEndsX[0] = 0; // it starts from 1
            withoutEndsX[0] = 1;

            for (var i = 1; i < n; i++)
            {
                withEndsX[i] = withoutEndsX[i - 1];
                withoutEndsX[i] = withEndsX[i - 1] * (k - 1) + withoutEndsX[i - 1] * (k - 2);
            }

            Console.WriteLine(withEndsX[n - 1]);
        }


    }
}
