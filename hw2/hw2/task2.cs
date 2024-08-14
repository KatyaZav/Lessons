using System;
using System.Globalization;

namespace hw2
{
    internal class task2
    {
        public static void Play()
        {
            Random random = new Random();
            int arraySize = random.Next(1, 101);

            int[] numbersArray = new int[arraySize];

            for (var i = 0; i < arraySize; i++)
            {
                numbersArray[i] = random.Next(10, 21);
            }

            Console.WriteLine($"Размер массива: {arraySize}");

            for (var i = 0; i < numbersArray.Length; i++)
            {
                Console.Write($"{numbersArray[i]} ");
            }


        }
    }
}
