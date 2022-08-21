using System;

namespace CurrencyConverter
{
    internal class Program
    {
        public const string Usd = "Доллары";
        public const string Eur = "Евро";
        public const string Rub = "Рубли";

        private static bool _exchangeRubToUsd = false;
        private static bool _exchangeRubToEur = false;
        private static bool _exchangeEurToUsd = false;
        private static bool _exchangeEurToRub = false;
        private static bool _exchangeUsdToEur = false;
        private static bool _exchangeUsdToRub = false;

        private static string _currencyToSell;

        private static float _usdToRubRate = 80f;
        private static float _rubToUsdRate = 1 / _usdToRubRate;
        private static float _eurToUsdRate = 1.2f;
        private static float _usdToEurRate = 1 / _eurToUsdRate;
        private static float _eurToRubRate = 90f;
        private static float _rubToEurRate = 1 / _rubToEurRate;

        private static float _usdAmount = 0;
        private static float _eurAmount = 0;
        private static float _rubAmount = 0;

        static void Main(string[] args)
        {
            string greetings = "Приветствуем! Для начала работы конвертора валют, введите Ваш баланс\n";

            Console.WriteLine(greetings);
            Console.Write("Количество долларов - ");
            _usdAmount = ReadNumberFromKeyboard();
            Console.Write("Количество евро - ");
            _eurAmount = ReadNumberFromKeyboard();
            Console.Write("Количество рублей - ");
            _rubAmount = ReadNumberFromKeyboard();

            SelectCurrencyToSale();
            SelectCurrencyToBuy();
            Exchange();

            Console.WriteLine($"{Usd} - {_usdAmount}, {Rub} - {_rubAmount}, {Eur} - {_eurAmount}");
        }

        private static void SelectCurrencyToSale()
        {
            Console.WriteLine("Какую валюту Вы хотите обменять?");
            Console.WriteLine($"1 - {Usd}, 2- {Eur} 3 - {Rub}");

            bool isSelectCorrectNumber = false;

            while (isSelectCorrectNumber == false)
            {
                int selectedNumber = ReadNumberFromKeyboard();

                switch (selectedNumber)
                {
                    case 1:
                        _currencyToSell = Usd;
                        isSelectCorrectNumber = true;
                        break;
                    case 2:
                        _currencyToSell = Eur;
                        isSelectCorrectNumber = true;
                        break;
                    case 3:
                        _currencyToSell = Rub;
                        isSelectCorrectNumber = true;
                        break;
                    default:
                        Console.WriteLine("Такой валюты нет, повторите попытку");
                        break;
                }
            }
        }

        private static void SelectCurrencyToBuy()
        {
            Console.WriteLine("На какую валюту Вы хотите обменять?");

            bool isSelectCorrectNumber = false;

            while (isSelectCorrectNumber == false)
            {
                if (_currencyToSell == Usd)
                {
                    Console.WriteLine($"1 - {Eur}, 2 - {Rub}");
                    int selectedNumber = ReadNumberFromKeyboard();

                    if (selectedNumber == 1)
                    {
                        _exchangeUsdToEur = true;
                        isSelectCorrectNumber = true;

                    }
                    else if (selectedNumber == 2)
                    {
                        _exchangeUsdToRub = true;
                        isSelectCorrectNumber = true;
                    }
                    else
                    {
                        Console.WriteLine("Такой валюты нет, повторите попытку");
                    }
                }
                else if (_currencyToSell == Eur)
                {
                    Console.WriteLine($"1 - {Usd}, 2 - {Rub}");
                    int selectedNumber = ReadNumberFromKeyboard();

                    if (selectedNumber == 1)
                    {
                        _exchangeEurToUsd = true;
                        isSelectCorrectNumber = true;
                    }
                    else if (selectedNumber == 2)
                    {
                        _exchangeEurToRub = true;
                        isSelectCorrectNumber = true;
                    }
                    else
                    {
                        Console.WriteLine("Такой валюты нет, повторите попытку");
                    }
                }
                else
                {
                    Console.WriteLine($"1 - {Usd}, 2 - {Eur}");
                    int selectedNumber = ReadNumberFromKeyboard();

                    if (selectedNumber == 1)
                    {
                        _exchangeRubToUsd = true;
                        isSelectCorrectNumber = true;
                    }
                    else if (selectedNumber == 2)
                    {
                        _exchangeRubToEur = true;
                        isSelectCorrectNumber = true;
                    }
                    else
                    {
                        Console.WriteLine("Такой валюты нет, повторите попытку");
                    }
                }
            }
        }

        private static void Exchange()
        {
            Console.WriteLine("Сколько Вы хотите обменять?");
            float quantityToTransfer = ReadFloatFromKeyboard();

            if (_exchangeRubToUsd)
            {
                if (_rubAmount >= quantityToTransfer)
                {
                    _usdAmount += quantityToTransfer * _rubToUsdRate;
                    _rubAmount -= quantityToTransfer;
                }
            }
            else if (_exchangeRubToEur)
            {
                if (_rubAmount >= quantityToTransfer)
                {
                    _eurAmount += quantityToTransfer * _rubToEurRate;
                    _rubAmount -= quantityToTransfer;
                }
            }
            else if (_exchangeEurToRub)
            {
                if (_eurAmount >= quantityToTransfer)
                {
                    _rubAmount += quantityToTransfer * _eurToRubRate;
                    _eurAmount -= quantityToTransfer;
                }
            }
            else if (_exchangeEurToUsd)
            {
                if (_eurAmount >= quantityToTransfer)
                {
                    _usdAmount += quantityToTransfer * _eurToUsdRate;
                    _eurAmount -= quantityToTransfer;
                }
            }
            else if (_exchangeUsdToEur)
            {
                if (_usdAmount >= quantityToTransfer)
                {
                    _eurAmount += quantityToTransfer * _usdToEurRate;
                    _usdAmount -= quantityToTransfer;
                }
            }
            else if (_exchangeUsdToRub)
            {
                if (_usdAmount >= quantityToTransfer)
                {
                    _rubAmount += quantityToTransfer * _usdToRubRate;
                    _usdAmount -= quantityToTransfer;
                }
            }
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
        private static float ReadFloatFromKeyboard()
        {
            bool isIntValue = float.TryParse(Console.ReadLine(), out float value);

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
