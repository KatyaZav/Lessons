using System;
using System.Drawing;
using System.Globalization;

namespace hw2
{
    internal class task3
    {
        public static void Play()
        {
            Console.WriteLine("Введите длинну массива");
            int arrayLength = GetIntInput();
            Console.WriteLine("Введите ширину массива");
            int arrayWidth = GetIntInput();
            int[,] numbersArray = new int[arrayLength, arrayWidth];

            for (var i = 0; i < arrayLength; i++)
            {
                for (var j = 0; j < arrayWidth; j++)
                {
                    Console.WriteLine($"Чему равен элемент массива на {i} {j}");
                    numbersArray[i, j] = GetIntInput();
                }
            }

            int maxNumber = numbersArray[0, 0];
            for (var i = 0; i < arrayLength; i++)
            {
                for (var j = 0; j < arrayWidth; j++)
                {
                    if (maxNumber < numbersArray[i,j])
                        maxNumber = numbersArray[i, j];
                }
            }

            Console.Clear();
            WriteWithColor($"Наибольшее число массива равно {maxNumber}\n", ConsoleColor.Green);
            for (var i = 0; i < arrayLength; i++)
            {
                for (var j = 0; j < arrayWidth; j++)
                {
                    Console.Write($"{numbersArray[i, j]} ");
                }
                Console.WriteLine();
            }
        }

        public static int GetIntInput()
        {
            string userInput = Console.ReadLine();

            int number;
            if (int.TryParse(userInput, out number))
            {
                WriteWithColor("Number getted\n", ConsoleColor.Green);
                return number;
            }
            else
            {
                WriteWithColor("Incorrect input. Print number\n", ConsoleColor.Red);
                return GetIntInput();
            }
        }

        public static void WriteWithColor(string text, ConsoleColor color)
        {
            ConsoleColor currentConsoleColor = Console.ForegroundColor;

            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ForegroundColor = currentConsoleColor;
        }
    }
}
