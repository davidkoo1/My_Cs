using System;

namespace RotateImage_90_d
{
    class Program
    {
        public static int[,] matrix = { 
                            {1, 2, 3, },
                            { 4, 5, 6 },
                            { 7, 8, 9 }
                            };

        public static int rows = matrix.GetUpperBound(0) + 1;
        public static int columns = matrix.Length / rows;

        static void Output2dArray(int[,] field)
        {
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

        static int[,] rotateImage(int[,] matrix)
        {
            int N = matrix.Length;

            for (int i = 0; i < rows; i++)
            {
                for (int j = i; j < columns; j++)
                {
                    int temp = matrix[i, j];
                    matrix[i, j] = matrix[j, i];
                    matrix[j, i] = temp;
                }

            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < (columns / 2); j++)
                {
                    int temp = matrix[i, j];
                    matrix[i, j] = matrix[i, columns - 1 - j];
                    matrix[i, columns - 1 - j] = temp;
                }

            }

            return matrix;
        }
        static void Main(string[] args)
        {

            Output2dArray(matrix);
            Console.WriteLine();

            rotateImage(matrix);
            


            Output2dArray(matrix);
            Console.WriteLine();

        }
    }
}
