using System;

namespace Console3D
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = 120;
            int height = 30;
            float aspect = (float)width / height;
            float pixelAspect = 11.0f / 24.0f;
            string gradient = " .a@";
            int gradientSize = gradient.Length - 2;

            char[] screen = new char[width * height + 1];
            screen[width * height] = '\0';

            for (int t = 0; t < 10000; t++){
                for (int i = 0; i < width; i++){
                    for (int j = 0; j < height; j++){
                        //screen[i + j * width] = '@';
                        float x = (float)i / width * 2.0f - 1.0f;
                        float y = (float)j / height * 2.0f - 1.0f;
                        x *= aspect * pixelAspect;
                        x += (float)Math.Sin(t * 0.001);
                        char pixel = ' ';
                        if (x * x + y * y < 0.5) pixel = '@';
                        screen[i + j * width] = pixel;
                    }
                }
                Console.Write(screen);
            }
            Console.ReadKey();
        }
    }
}
