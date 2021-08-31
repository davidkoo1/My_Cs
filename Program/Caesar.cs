using System;
using System.Linq;

namespace Caesar
{
    class Program
    {
        static string FirstMethod(string s)
        {
            const string strNorm = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            const string strMod = "bcdefghijklmnopqrstuvwxyzaZABCDEFGHIJKLMNOPQRSTUVWXY9876543210";

            char[] chars = new char[s.Length];

            for (int i = 0; i < s.Length; i++)
            {
                int index = strNorm.IndexOf(s[i]);
                chars[i] = index >= 0 ? strMod[index] : s[i];

            }

            string outs = new string(chars);

            return outs;
        }

        static string SecondMethodUseLinq(string s)
        {
            int numere = '9' + '0';
            string outputString = string.Join("", s.Select(ch => (ch >= 'a' && ch < 'z') ? 
            (char)(ch + 1) : (ch > 'A' && ch <= 'Z') ? 
            (char)(ch - 1) : (ch == 'z') ? (char)'a' : (ch == 'A') ? (char)'Z' : (Char.IsDigit(ch))
            ? (char)(Char.IsDigit(ch) ? numere - ch : ch + 1) : ch));

            return outputString;
        }
        static void Main(string[] args)
        {
            string s = "MA1995$#riz73";

            Console.WriteLine(s);
            Console.WriteLine(FirstMethod(s));

            Console.WriteLine();

            Console.WriteLine(s);
            Console.WriteLine(SecondMethodUseLinq(s));
        }
    }
}
/*
 Input: MA1995$#riz73
Output: LZ8004$#sja26
 */