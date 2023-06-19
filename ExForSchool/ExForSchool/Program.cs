using System;

namespace ExForSchool
{
    class Program
    {
        const string strNorm = " ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        const string strMod = "-BCDEFGHIJKLMNOPQRSTUVWXYZAbcdefghijklmnopqrstuvwxyza";

        public static int Pos(string str, char c)
        {
            int val = -1;

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == c)
                    val = i;
            }

            return val;

        }
        static void Main(string[] args)
        {

/*
            string s = "ZAazZ!";
            char[] chars = new char[s.Length];
        
            int index = 0;

            for (int i = 0; i < s.Length; i++)
            {
                index = s[i];
                index += 2;

                chars[i] = Convert.ToChar(index); 

               //Console.WriteLine(index);

            }
*/
            for (int i = 0; i < s.Length; i++)
            {  
                int index = Pos(strNorm, s[i]);

                //int index = strNorm.IndexOf(s[i]);
                                
               // Console.WriteLine(i + " - " + index + " - ");
               
                chars[i] = (index >= 0) ? strMod[index] : s[i];

            }
           
            string outs = new string(chars);

            Console.WriteLine(outs);

        }
    }
}
