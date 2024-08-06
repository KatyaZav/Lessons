using System;
using System.Globalization;

namespace task1
{
    internal class task1
    {
        public static void Play()
        {
            Console.WriteLine("First task started");
            //a
            int a, b, c, d;
            a = b = c = d = 0;
            char e = '0';
            string f = "not 0";
            float g = 0.0f;
            int h = 10;
            int i = 20;
            int j = 30;

            //b
            int example = 0;
            float y = 2.5f;
            int convert = (int)y;
            int mathConvert = (int)MathF.Round(y);

            Console.WriteLine($"{convert}, {mathConvert}");

            //c
            string s = "1234.10";
            float fS = float.Parse(s, CultureInfo.InvariantCulture);
            Console.WriteLine(fS);
            Console.WriteLine("First task ended \n");
        }
    }
}
