using System;

namespace Abreviation {
    class Program {
        static void Main (string[] args) {
            var str1 = "AbcDE";
            var str2 = "ABDE";
            var length = abbreviationRecurs (str1, str2);
            Console.WriteLine (length);
            Console.WriteLine (length == str2.Length ? "YES" : "NO");
        }

        static int abbreviationRecurs (string a, string b) {
            // 1. idea of ability to delete the lowercase letters;
            // 2. build the table of all 
            var m = a.Length;
            var n = b.Length;

            if (m == 0 || n == 0)
                return 0;

            if (a[m - 1] == b[n - 1])
                return 1 + abbreviationRecurs (a.Substring (0, m - 1), b.Substring (0, n - 1));

            if (!char.IsLower (a[m - 1]))
                return 0;

            if (char.ToUpper (a[m - 1]) == b[n - 1]) {
                return Math.Max (1 + abbreviationRecurs (a.Substring (0, m - 1), b.Substring (0, n - 1)), abbreviationRecurs (a.Substring (0, m - 1), b));
            } else {
                return abbreviationRecurs (a.Substring (0, m - 1), b);
            }
        }
        // static string abbreviation (string a, string b) {
        //     // 1. idea of ability to delete the lowercase letters;
        //     // 2. build the table of all 
        //     var aL = a.Length;
        //     var bL = b.Length;
        //     var L = new int[aL + 1, bL + 1];

        //     var potentialUpperCase = new int[1,1];
        //     for(int i = 1; i <= aL; i++){

        //     }
        // }
    }
}