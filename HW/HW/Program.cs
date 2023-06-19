using System;
using System.Linq;

namespace HW
{
    class Program
    {
        static void A_Z()
        {
            for (char i = 'A'; i <= 'Z'; i++)
            {
                Console.WriteLine(i + " - " + (int)i);
            }

            Console.WriteLine();

            for (char i = '0'; i <= '9'; i++)
            {
                Console.WriteLine(i + " - " + (int)i);
            }
        }


        static void Main(string[] args)
        {

           // A_Z();

            string om = "";
            

            do
            {
               Console.Clear();

                Console.WriteLine("Input number");
                int number = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Input system number");
                int systemNumber = Convert.ToInt32(Console.ReadLine());


                int a = 0;
                char[] arr = new char[1000];

                int i = 0;
                string res = "";
                string ch = "";

                while (number > 0)
                {
                    // Console.WriteLine(a + " " + number);
                    ch = Convert.ToString(number);

                    a = number % systemNumber;
                    arr[i] = (a > 9) ? Convert.ToChar(a + 55) : Convert.ToChar(a + 48);
                    i++;
                    number /= systemNumber;
                }
                //Console.WriteLine(ch);

                Array.Reverse(arr);


                res = string.Join("", arr);
                int index = res.IndexOf(ch);
                if (index > -1)
                    Console.WriteLine(res.Substring(index));
                else
                    Console.WriteLine(res);

                Console.WriteLine("One more? y/n");
                om = Console.ReadLine();
            } while (om == "y");
            

        }
    }
}
