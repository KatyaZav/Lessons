using System;
using System.Drawing;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;

namespace hw2
{
    internal class task4
    {
        public static void Play()
        {
            int userWinCount = 0, computerWinCount = 0;
            string[] ChooseTypes = new string[] { "орел", "решка" };
            string agreeAnswer = "да", disagreeAnswer = "нет";

            while (true)
            {
                Console.WriteLine("Орел или решка?");

                string userChoose = GetChoose(ChooseTypes[0], ChooseTypes[1]);

                Random random = new Random();
                int answerNumber = random.Next(0, 2);

                Console.WriteLine($"Ваш выбор {userChoose}, мой выбор {ChooseTypes[answerNumber]}");
                if (userChoose == ChooseTypes[answerNumber])
                {
                    userWinCount++;
                    WriteWithColor("Win\n", ConsoleColor.Green);
                }
                else
                {
                    computerWinCount++;
                    WriteWithColor("Loose\n", ConsoleColor.Red);
                }

                Console.WriteLine($"Счет {userWinCount}:{computerWinCount}");
                Console.WriteLine($"Продолжим?");
                string contunierAnswer = GetChoose(agreeAnswer, disagreeAnswer);
                if (contunierAnswer == disagreeAnswer)
                    break;

                Console.Clear();
            }
        }

        public static string GetChoose(string firstAnswer, string secondAnswer)
        {
            string userChoose = Console.ReadLine().ToLower();
            if (userChoose != firstAnswer && userChoose != secondAnswer)
            {
                Console.WriteLine("Didn't found choose");
                return GetChoose(firstAnswer, secondAnswer);
            }
            return userChoose;
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
