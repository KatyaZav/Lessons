using System;
using System.Drawing;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;

namespace hw2
{
    internal class task5
    {
        public static void Play()
        {
            const int needAnswersToWin = 3;
            const int maxAttempts = 6;
            const string yesAnswer = "да";
            const string noAnswer = "нет";

            Random random = new Random();

            while (true)
            {              
                string gameMassive = "012345678";
                int attemptsPassed = maxAttempts;
                int placesGuessed = 0;

                while (true)
                {
                    PrintArray(gameMassive);
                    
                    int randomLenght = random.Next(0, gameMassive.Length);
                    int choosedPosition = gameMassive[randomLenght] - '0';
                    //Console.WriteLine("Choosed " + choosedPosition);

                    while (attemptsPassed >= 0)
                    {
                        Console.WriteLine("Введите номер столбца и строки");
                        int selectedСolumn = GetIntInput();
                        int selectedLine = GetIntInput();
                        attemptsPassed--;

                        if (CheckIsRightPlace(selectedСolumn, selectedLine, choosedPosition))
                        {
                            gameMassive = gameMassive.Replace(choosedPosition.ToString(), "");
                            Console.Clear();
                            WriteWithColor("Угадал!\n", ConsoleColor.Green);
                            placesGuessed++;
                            break;
                        }
                        else
                            WriteWithColor("Неть\n", ConsoleColor.Red);
                    }

                    if (placesGuessed >= needAnswersToWin)
                    {
                        Console.Clear();
                        WriteWithColor("Победа! ", ConsoleColor.Green);
                        break;
                    }

                    if (attemptsPassed <= 0)
                    {                        
                        Console.Clear();
                        WriteWithColor("Поражение. ", ConsoleColor.Red);
                        break;
                    }
                }

                Console.WriteLine("Еще раз?");
                string choose = GetChoose(yesAnswer, noAnswer);

                if (choose == noAnswer)
                {
                    Console.Clear();
                    Console.WriteLine("Пока-пока");
                    break;
                }

                Console.Clear();
            }
        }

        public static bool CheckIsRightPlace(int column, int line, int numberIndex)
        {
            var columnIndex = numberIndex % 3 + 1;
            var lineIndex = (numberIndex - numberIndex % 3) /3 + 1;

            return columnIndex == column && lineIndex == line;
        }

        public static void PrintArray(string gameMassive)
        {
            //Console.WriteLine("Current array " + gameMassive);

            char[,] answerArray = new char[3, 3];
            int currentNumber = 0;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {                    
                    if (gameMassive.Contains(currentNumber.ToString()))
                        answerArray[i, j] = 'o';
                    else
                        answerArray[i, j] = 'x';
                    
                    currentNumber++;
                    
                    Console.Write(answerArray[i, j]);
                }
                Console.WriteLine();
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

        public static int GetIntInput()
        {
            string userInput = Console.ReadLine();

            int number;
            if (int.TryParse(userInput, out number))
            {
                if (number > 3 || number < 1)
                {
                    WriteWithColor("Incorrect input. Print number\n", ConsoleColor.Red);
                    return GetIntInput();
                }

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
