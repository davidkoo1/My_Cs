using System;

namespace CountString
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "Test  test      tes1 gh    ";
            int count = 1;


            for (int i = 0; i < s.Length - 1; i++)
            {
                if (s[i] == ' ' && s[i + 1] != ' ')
                {
                    count++;
                }
            }

            Console.WriteLine(count);
        }
    }
}
