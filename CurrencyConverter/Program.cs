using System;

namespace CurrencyConverter
{
    internal class Program
    {
        public const string Usd = "Доллары";
        public const string Eur = "Евро";
        public const string Rub = "Рубли";

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
            Console.Write("Количество рублей - ");
            _rubAmount = ReadNumberFromKeyboard();
            Console.Write("Количество долларов - ");
            _usdAmount = ReadNumberFromKeyboard();
            Console.Write("Количество евро - ");
            _eurAmount = ReadNumberFromKeyboard();

            Console.WriteLine("Какую валюту Вы хотите обменять?");
            Console.WriteLine($"1 - {Rub}, 2- {Usd} 3 - {Eur}");

            bool isSelectCorrectNumber = false;
            int selectedFirstCurrency = 0;
            int selectedSecondCurrency = 0;

            while (isSelectCorrectNumber == false)
            {
                selectedFirstCurrency = ReadNumberFromKeyboard();

                if (selectedFirstCurrency > 0 && selectedFirstCurrency < 4)
                {
                    isSelectCorrectNumber = true;
                }
                else
                {
                    Console.WriteLine("Неверно, попробуйте ещё раз");
                }
            }

            isSelectCorrectNumber = false;

            Console.WriteLine("На какую валюту Вы хотите поменять?");
            Console.WriteLine($"1 - {Rub}, 2- {Usd} 3 - {Eur}");

            while (isSelectCorrectNumber == false)
            {
                selectedSecondCurrency = ReadNumberFromKeyboard();

                if (selectedSecondCurrency > 0 && selectedSecondCurrency < 4)
                {
                    isSelectCorrectNumber = true;
                }
                else
                {
                    Console.WriteLine("Неверно, попробуйте ещё раз");
                }
            }

            Console.WriteLine("Сколько хотите обменять?");
            float amount = ReadFloatFromKeyboard();

            Convert(selectedFirstCurrency, selectedSecondCurrency, amount);

            Console.WriteLine($"{Rub} - {_rubAmount}, {Usd} - {_usdAmount}, {Eur} - {_eurAmount}");
        }

        public static void Convert(int selectedFirstCurrency, int selectedSecondCurrency, float amount)
        {
            ChangeAmountOfFirstCurrency(ref selectedFirstCurrency, ref amount);

            switch (selectedSecondCurrency)
            {
                case 1:
                    if (selectedFirstCurrency == 2)
                    {
                        _rubAmount += amount * _usdToRubRate;
                    }
                    else if (selectedFirstCurrency == 3)
                    {
                        _rubAmount += amount * _eurToRubRate;
                    }
                    else
                    {
                        _rubAmount += amount;
                    }
                    break;
                case 2:
                    if (selectedFirstCurrency == 1)
                    {
                        _usdAmount += amount * _rubToUsdRate;
                    }
                    else if (selectedFirstCurrency == 3)
                    {
                        _usdAmount += amount * _eurToUsdRate;
                    }
                    else
                    {
                        _usdAmount += amount;
                    }
                    break;
                case 3:
                    if (selectedFirstCurrency == 1)
                    {
                        _eurAmount += amount * _rubToEurRate;
                    }
                    else if (selectedFirstCurrency == 2)
                    {
                        _eurAmount += amount * _usdToEurRate;
                    }
                    else
                    {
                        _eurAmount += amount;
                    }
                    break;
            }
        }

        private static void ChangeAmountOfFirstCurrency(ref int selectedFirstCurrency, ref float amount)
        {
            switch (selectedFirstCurrency)
            {
                case 1:
                    {
                        if (_rubAmount < amount)
                        {
                            Console.WriteLine("Столько денег нет на рублёвом счёте!");
                        }
                        else
                        {
                            _rubAmount -= amount;
                        }
                    }
                    break;
                case 2:
                    {
                        if (_usdAmount < amount)
                        {
                            Console.WriteLine("Столько денег нет на долларовом счёте!");
                        }
                        else
                        {
                            _usdAmount -= _usdAmount;
                        }
                    }
                    break;
                case 3:
                    {
                        if (_eurAmount < amount)
                        {
                            Console.WriteLine("Столько денег нет на евро счёте!");
                        }
                        else
                        {
                            _eurAmount -= amount;
                        }
                    }
                    break;
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
