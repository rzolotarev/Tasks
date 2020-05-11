using System;
using System.Collections.Generic;
using System.Linq;

namespace Abreviation {
    class Program {

        private static Dictionary<Tuple<string, string>, int> maxValues =
            new Dictionary<Tuple<string, string>, int> ();
        static void Main (string[] args) {
            var str1 = "AbcDE";
            var str2 = "ABDE";
            str2[str2.Length - 1] = char.;
            var length = abbreviationRecurs (str1, str2);
            Console.WriteLine (length);
            Console.WriteLine (length == str2.Length ? "YES" : "NO");
        }

        static int abbreviationRecurs (string a, string b) {
            // 1. idea of ability to delete the lowercase letters;
            // 2. build the table of all 
            var m = a.Length;
            var n = b.Length;

            if (maxValues.ContainsKey (Tuple.Create (a, b)))
                return maxValues[Tuple.Create (a, b)];

            if (m == 0 || n == 0)
                return 0;

            if (a[m - 1] == b[n - 1]) {
                var maxValue = abbreviationRecurs (a.Substring (0, m - 1), b.Substring (0, n - 1));
                maxValues.TryAdd (Tuple.Create (a, b), maxValue + 1);
                return 1 + maxValue;
            }
            if (!char.IsLower (a[m - 1]))
                return 0;

            if (char.ToUpper (a[m - 1]) == b[n - 1]) {
                var firstSubstring = a.Substring (0, m - 2).Insert (m - 1, char.ToUpper (a[m - 1]));
                var secondSubstring = b.Substring (0, n - 1);
                var equal = abbreviationRecurs (firstSubstring, secondSubstring);
                maxValues.TryAdd (Tuple.Create (firstSubstring, secondSubstring), equal);
                var notEqual = abbreviationRecurs (firstSubstring, b);
                maxValues.TryAdd (Tuple.Create (firstSubstring, b), notEqual);
                return Math.Max (1 + equal, notEqual);
            } else {
                var value = abbreviationRecurs (a.Substring (0, m - 1), b);
                maxValues.TryAdd (Tuple.Create (a.Substring (0, m - 1), b), value);
                return value;
            }
        }

        static string abbreviation (string a, string b) {
            // 1. idea of ability to delete the lowercase letters;
            // 2. build the table of all 
            var aL = a.Length;
            var bL = b.Length;
            var L = new int[aL + 1, bL + 1];
            var capitalLetters = new Dictionary<char, int> ();

            for (int i = 1; i <= aL; i++) {
                if (char.IsUpper (a[i - 1])) {
                    if (capitalLetters.ContainsKey (a[i - 1]))
                        capitalLetters[a[i - 1]]++;
                    else
                        capitalLetters.TryAdd (a[i - 1], 0);
                }

                for (int j = 1; j <= bL; j++) {
                    if (a[i - 1] == b[j - 1]) {
                        L[i, j] = 1 + L[i - 1, j - 1];
                    } else {
                        if (char.ToUpper (a[i - 1]) == b[j - 1])
                            L[i, j] = Math.Max (1 + L[i - 1, j - 1], L[i - 1, j]);
                        else
                            L[i, j] = Math.Max (L[i - 1, j], L[i, j - 1]);
                    }
                }
            }

            for (int i = 0; i < bL; i++) {
                if (capitalLetters.ContainsKey (b[i])) {
                    capitalLetters[b[i]]--;
                    if (capitalLetters[b[i]] == 0)
                        capitalLetters.Remove (b[i]);
                }
            }
            return L[aL, bL] == b.Length && capitalLetters.Count == 0 ? "YES" : "NO";
        }
    }
}