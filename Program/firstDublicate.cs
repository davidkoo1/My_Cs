using System;
using System.Collections.Generic;

namespace firstDublicate
{
    class Program
    {
        static int[] arr = { 2, 1, 3, 5, 3, 2 };
        
        static int firstDublicate1(int[] a)
        {
            int min_second_index = a.Length;
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = i+1; j < a.Length; j++)
                {
                    if(a[i] == a[j])
                    {
                        min_second_index = Math.Min(min_second_index, j);
                    }
                }
            }
            if (min_second_index == a.Length) return -1;
            else return a[min_second_index];
        }
        
        static int firstDublicate2(int[] a)
        {
            List<int> seen = new List<int>();
            for (int i = 0; i < a.Length; i++)
            {
                if (seen.Contains(a[i]))
                {
                    return a[i];
                }
                else
                {
                    seen.Add(a[i]);
                }
            }
            return -1;
        }

        static int firstDublicate3(int[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                if (a[Math.Abs(a[i]) - 1] < 0)
                    return Math.Abs(a[i]);
                else
                    a[Math.Abs(a[i]) - 1] = -a[Math.Abs(a[i] - 1)];
            }
            return -1;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(firstDublicate1(arr));
            Console.WriteLine();
            Console.WriteLine(firstDublicate2(arr));
            Console.WriteLine();
            Console.WriteLine(firstDublicate3(arr));
        }
    }
}
