using System;

namespace CurrencyConverter
{
    internal class Program
    {
        public const string Usd = "usd";
        public const string Eur = "eur";
        public const string Rub = "rub";

        static void Main(string[] args)
        {
            float usdToRubRate = 80;
            float eurToUsdRate = 1.2f;
            float rubToEurRate = 90;

            float usdAmount = 0;
            float eurAmount = 0;
            float rubAmount = 0;

            string currencyToBuy;
            string currencyToSell;



            string greetings = "Приветствуем! Для начала работы конвертора валют, введите Ваш баланс\n";

            Console.WriteLine(greetings);
            Console.Write("Количество долларов - ");
            usdAmount = ReadNumberFromKeyboard();
            Console.Write("Количество евро - ");
            eurAmount = ReadNumberFromKeyboard();
            Console.Write("Количество рублей - ");
            rubAmount = ReadNumberFromKeyboard();

            currencyToSell = SelectCurrencyToSale();
            currencyToBuy = SelectCurrencyToBuy(currencyToSell);
            Exchange(currencyToBuy, currencyToSell);

        }

        private static string SelectCurrencyToSale()
        {
            Console.WriteLine("Какую валюту Вы хотите обменять?");
            Console.WriteLine("1 - Доллар, 2 - Евро, 3 - Рубли");
            int selectedNumber = ReadNumberFromKeyboard();

            string saleCurrency;

            switch (selectedNumber)
            {
                case 1:
                    saleCurrency = Usd;
                    break;
                case 2:
                    saleCurrency = Eur;
                    break;
                case 3:
                    saleCurrency = Rub;
                    break;
                default:
                    Console.WriteLine("Такой валюты нет, повторите попытку");
                    saleCurrency = SelectCurrencyToSale();
                    break;
            }

            return saleCurrency;
        }

        private static string SelectCurrencyToBuy(string currencyToSell)
        {
            Console.WriteLine("На какую валюту Вы хотите обменять?");

            if (currencyToSell == Usd)
            {
                Console.WriteLine("1 - Рубли, 2 - евро")
            } else if ()

 

            return buyCurrency;
        }

        private static string Exchange()
        {
            if (currencyToSell )
        }

        private static int ReadNumberFromKeyboard()
        {
            bool isIntValue = int.TryParse(Console.ReadLine(), out int value);
            if (isIntValue == true)
            {
                if (value >= 0)
                {
                    return value;
                }
                else
                {
                    Console.WriteLine("Нельзя вводить отрицательные числа");
                    return ReadNumberFromKeyboard();
                }
            }
            else
            {
                Console.WriteLine("Можно вводить только числа");
                return ReadNumberFromKeyboard();
            }
        }
    }
}
