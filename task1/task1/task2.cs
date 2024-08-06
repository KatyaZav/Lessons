using System;
using System.Globalization;

namespace task1
{
    internal class task2
    {
        public static void Play()
        {
            Console.WriteLine("Second task started");
                        
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Your name?");
            var name = Console.ReadLine();
            Console.WriteLine("Your age?");
            var age = Console.ReadLine();
            Console.WriteLine("Your id?");
            var id = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Access is denied. Your id ({id}) not founded. \n" +
                $"Sorry, {name}, {2024 - int.Parse(age)} year born");

            Console.ResetColor();
            Console.WriteLine("Second task ended \n");
        }
    }
}
