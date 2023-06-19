using System;

namespace cucumbers
{
    class Cucumber
    {

        static void Output2dArray(int[,] field)
        {
            int rows = field.GetUpperBound(0) + 1;
            int columns = field.Length / rows;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write($"{field[i, j]} ");
                }
                Console.WriteLine();
            }
            //Console.WriteLine("\n");
        }
        static void Main(string[] args)
        {
             int[,] field = { //поле
                            {1, 1, 1, },
                            { 2, 2, 3 },
                            { 4, 4, 5 }
                            };

            int rows = field.GetUpperBound(0) + 1;
            int columns = field.Length / rows;

            Output2dArray(field);
            Console.WriteLine();

            int month = 3;

            int maxGrowth = 5;
            int collected = 0;

            for (int k = 1; k <= month; k++)
            {
                Console.WriteLine(k + " месяц");
                collected = 0;
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        if (field[i, j] == maxGrowth)
                        {
                            field[i, j] = 1;
                            collected++;

                        }
                        else
                        {
                            field[i, j] += 1;
                        }
                    }

                }
                Output2dArray(field);
                Console.WriteLine(collected);
                Console.WriteLine();
            }

        }
    }
}
