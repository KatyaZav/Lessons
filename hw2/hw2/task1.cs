using System;
using System.Globalization;

namespace hw2
{
    internal class task1
    {
        public static void Play()
        {
            const string exitCommand = "exit";
            const string continuationCommand = "next";

            while (true)
            {
                float totalAmount = 0;

                Console.WriteLine($"Введите цифры, которые хотите суммировать." +
                    $" Для финальной суммы напишите =.");
                
                while (true)
                {
                    string input = Console.ReadLine();

                    if (input == "=")
                        break;

                    float inputNumber;

                    if (float.TryParse(input, NumberStyles.Any,
                        CultureInfo.InvariantCulture, out inputNumber))
                    {
                        totalAmount += inputNumber;
                    }
                    else
                    {
                        Console.WriteLine("Извините, это не число. Попробуйте еще раз.");
                    }
                }

                Console.WriteLine($"Итоговая сумма: {totalAmount}");
                Console.WriteLine($"Желаете продолжить? " +
                    $"\n\t{exitCommand} - выйти" +
                    $"\n\t{continuationCommand} - продолжить");

                bool ExitSelected = false, success = false;

                while (success == false)
                {
                    string commandInput = Console.ReadLine();

                    switch (commandInput.ToLower())
                    {
                        case exitCommand:
                            ExitSelected = true;
                            success = true;
                            break;
                        case continuationCommand:
                            ExitSelected = false;
                            success = true;
                            break;
                        default:
                            Console.WriteLine("Команда не понята. Введите еще раз.");
                            break;
                    }
                }

                if (ExitSelected)
                    break;
                else
                    Console.Clear();
            }
                
        }
    }
}
