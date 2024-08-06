using System;
using System.Globalization;

namespace task1
{
    internal class task3
    {
        public static void Play()
        {
            Console.WriteLine("Fird task started");

            Console.Write("Width: ");
            float x = float.Parse(Console.ReadLine(),
                CultureInfo.InvariantCulture);
            Console.Write("Length: ");
            float y = float.Parse(Console.ReadLine(),
                CultureInfo.InvariantCulture);
            Console.Write("Marmelado box square");
            float box = float.Parse(Console.ReadLine(),
                CultureInfo.InvariantCulture);

            Console.WriteLine($"Square is {x*y}, box can be " +
                $"{(int)(x*y/box)}.");

            Console.WriteLine("Fird task ended \n");
        }
    }
}
