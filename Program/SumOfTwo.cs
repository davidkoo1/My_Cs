using System;
using System.Collections.Generic;

namespace SumOfTwo
{

    class Program
    {                                                //exemple
        static int[] a = { 0, 0, -5, 30212 };       //{ 1, 2, 3 };
        static int[] b = { -10, 40, -3, 9 };       //{ 10, 20, 30, 40 };
        static int v = -8;                        //42

        //My methods
        static bool sumOfTwo_My(int[] a, int[] b, int v)
        {
            bool answer = false;
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = 0; j < b.Length; j++)
                {
                    if (a[i] + b[j] == v)
                    {
                        answer = true;
                        break;
                    }

                }
            }
            return answer;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(sumOfTwo_My(a, b, v));

            Console.WriteLine();

            Console.WriteLine(SumOfTwo_yt(a, b, v));
            Console.WriteLine();

            Console.WriteLine(SumOfTwo_yt2(a, b, v));
        }

        //YouTube Methods
        static bool SumOfTwo_yt(int[] a, int[] b, int v)
        {
            
            for (int i = 0; i < a.Length; i++)
            {
                int needed_value = v - a[i];
                for (int j = 0; j < b.Length; j++)
                {
                    if (b[j] == needed_value)
                    {
                        return true;
                    }

                }
            }
            return false;
        }

        static bool SumOfTwo_yt2(int[] a, int[] b, int v)
        {
            List<int> differences = new List<int>();
            for (int i = 0; i < a.Length; i++)
            {
                int difference = v - a[i];
                differences.Add(difference);
            }

            for (int i = 0; i < b.Length; i++)
            {
                if (differences.Contains(b[i])) return true; 
            }
            return false;
        }
    }

}
