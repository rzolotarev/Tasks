using System;

namespace SubstringAndSum
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "1234";

            var sumOfDigit = new int[s.Length];
            sumOfDigit[0] = s[0]-'0';
            var totalSum = sumOfDigit[0];

            for (var i = 1; i < s.Length; i++)
            {
                // 1
                // 1, 2, 12
                // 1, 2, 12, 3, 23, 123  = 3*3 + (2 + 12)* 10 = s[i]*(i + 1) + 10* sumOfDigit[i-1];
                sumOfDigit[i] = (i + 1) * (s[i] - '0') + 10 * sumOfDigit[i - 1];
                totalSum += sumOfDigit[i];
            }

            Console.WriteLine(totalSum);
        }

        static int substrings(string num)
        {

            int n = num.Length;

            // allocate memory equal to 
            // length of string 
            var sumofdigit = new long[n];

            // initialize first value 
            // with first digit 
            sumofdigit[0] = num[0] - '0';
            var res = (long)sumofdigit[0];

            // loop over all digits 
            // of string 

            var mod = 1000000007;
            for (int i = 1; i < n; i++)
            {
                int numi = num[i] - '0';

                // update each sumofdigit 
                // from previous value 
                sumofdigit[i] = (((i + 1) * numi) + (10 * sumofdigit[i - 1])) % mod;

                // add current value 
                // to the result 
                res = (res + sumofdigit[i]) % mod;
            }

            return (int)(res);
        }
    }
}
