using System;

namespace hw3
{
    internal class task1
    {
        public static void Play()
        {
            CoinGenerator generator = new CoinGenerator();
            Player player = new Player();

            const int minCoinDenomination = 1;
            const int maxCoinDenomination = 100;

            const string dropCommand = "выкинуть";
            const string holdCommand = "оставить";


            const string agreeCommand = "да";
            const string disagreeCommand = "нет";

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Вы бросили монетку в фонтан желаний со словами \"Хочу монетку\"");
                Coin coin = generator.CreateCoinWithDenominationInRange(minCoinDenomination, maxCoinDenomination);
                coin.PrintDenomination();

                Console.WriteLine("\n");
                Console.WriteLine($"Желаете {dropCommand} или {holdCommand}?");
                string command = GetChoose(holdCommand, dropCommand);

                switch (command)
                {
                    case holdCommand:
                        if (coin.IsMimic)
                        {
                            Decorator.WriteWithColor("Это мимик!\n", ConsoleColor.Red);
                            player.LoseMoney();
                        }
                        else
                        {
                            Console.WriteLine("Вы убираете монетку в карман.");
                            player.AddCoin(coin);
                        }
                        break;
                    case dropCommand:
                        break;
                    default:
                        Decorator.WriteWithColor("Произошла какая-то ошибка с вводом", ConsoleColor.Red);
                        break;
                }

                player.PrintPlayerMoney();

                Console.WriteLine("Достать монетку из кармана?");
                string exitCommand = GetChoose(disagreeCommand, agreeCommand);
                bool needToLeave = false;

                switch (exitCommand)
                {
                    case disagreeCommand:
                        needToLeave = true;
                        break;
                    case agreeCommand:
                        needToLeave = false;
                        break;
                }

                if (needToLeave)
                    break;
            }
        }

        public static string GetChoose(string firstAnswer, string secondAnswer)
        {
            string userChoose = Console.ReadLine().ToLower();
            if (userChoose != firstAnswer && userChoose != secondAnswer)
            {
                Decorator.WriteWithColor("Didn't found choose\n", ConsoleColor.Red);
                return GetChoose(firstAnswer, secondAnswer);
            }
            return userChoose;
        }
    }

    public class Coin
    {
        public Coin(int denomination, bool isMimik)
        {
            Denomination = denomination;
            IsMimic = isMimik;
        }

        public int Denomination { get; }
        public bool IsMimic { get; }

        public void PrintDenomination()
        {
            Console.Write($"Выпала монетка ценностью ");
            Decorator.WriteWithColor(Denomination.ToString(), ConsoleColor.Green);
        }
    }

    public class CoinGenerator
    {
        public Coin CreateCoinWithDenominationInRange(int minDenomination, int maxDenomination)
        {
            Random random = new Random();

            int randomDenomination = random.Next(minDenomination, maxDenomination + 1);
            int mimicProbability = random.Next(minDenomination, maxDenomination + 1);

            bool isMimik = randomDenomination >= mimicProbability;

            return new Coin(randomDenomination, isMimik);
        }
    }

    public class Player
    {
        public Player(int coinsAmount = 0)
        {
            CoinsAmount = coinsAmount;
        }

        public int CoinsAmount { get; private set; }

        public void LoseMoney()
        {
            Console.WriteLine("Игрок лишается всех денег!");
            CoinsAmount = 0;
        }

        public void AddCoin(Coin coin)
        {
            CoinsAmount += coin.Denomination;
        }

        public void PrintPlayerMoney()
        {
            Console.Write($"У игрока ");
            Decorator.WriteWithColor(CoinsAmount.ToString(), ConsoleColor.Green);
            Console.WriteLine(" монет");
        }
    }

    public static class Decorator
    {
        public static void WriteWithColor(string text, ConsoleColor color)
        {
            ConsoleColor currentConsoleColor = Console.ForegroundColor;

            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ForegroundColor = currentConsoleColor;
        }
    }
}
