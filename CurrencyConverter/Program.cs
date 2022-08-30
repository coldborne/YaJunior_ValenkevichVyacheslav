using System;

namespace CurrencyConverter
{
    public enum Currency { RUB, USD, EUR}
    class BanAccount
    {
        public static decimal UsdRub = 64.4m;
        public static decimal EurRub = 70.8m;

        public decimal RUB = 0;
        public decimal USD = 0;
        public decimal EUR = 0;

        public string Name;

        public void ConvertMany(Currency source, Currency target, decimal amount)
        {
            if (source == target)
                return;

            decimal amountRUB;

            switch (source)
            {
                case Currency.RUB:
                    {
                        if (RUB < amount)
                            throw new ArgumentException("Столько денег нет на рублёвом счёте!");
                        else
                        {
                            amountRUB = amount;
                            RUB -= amount;
                        }
                    }
                    break;
                case Currency.USD:
                    {
                        if (USD < amount)
                            throw new ArgumentException("Столько денег нет на долларовом счёте!");
                        else
                        {
                            amountRUB = amount * UsdRub;
                            USD -= amount;
                        }
                    }
                    break;
                case Currency.EUR:
                    {
                        if (EUR < amount)
                            throw new ArgumentException("Столько денег нет на евро-счёте!");
                        else
                        {
                            amountRUB = amount * EurRub;
                            EUR -= amount;
                        }
                    }
                    break;
                default:
                    throw new ArgumentException("Счёта в этой валюте нет!");
            }

            switch (target)
            {
                case Currency.RUB: RUB += amountRUB; 
                    break;
                case Currency.USD: USD += amountRUB / UsdRub; 
                    break;
                case Currency.EUR: EUR += amountRUB / EurRub; 
                    break;
            }
        }

        internal class Program
        {
            public const string Usd = "Доллары";
            public const string Eur = "Евро";
            public const string Rub = "Рубли";

            private static string _currencyToSell;

            private static float _usdToRubRate = 80f;
            private static float _rubToUsdRate = 1 / _usdToRubRate;
            private static float _eurToUsdRate = 1.2f;
            private static float _usdToEurRate = 1 / _eurToUsdRate;
            private static float _eurToRubRate = 90f;
            private static float _rubToEurRate = 1 / _rubToEurRate;

            public const string UsdToEur = "UsdToEur";
            public const string UsdToRub = "UsdToRub";
            public const string EurToUsd = "EurToUsd";
            public const string EurToRub = "EurToRub";
            public const string RubToUsd = "RubToUsd";
            public const string RubToEur = "RubToEur";

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

                Exchange();

                Console.WriteLine($"{Usd} - {_usdAmount}, {Rub} - {_rubAmount}, {Eur} - {_eurAmount}");
            }

            private static void Exchange()
            {
                Console.WriteLine("Какую валюту Вы хотите обменять?");
                Console.WriteLine($"1 - {Usd}, 2- {Eur} 3 - {Rub}");

                bool isSelectCorrectNumber = false;

                while (isSelectCorrectNumber == false)
                {
                    int selectedFirstNumber = ReadNumberFromKeyboard();

                    switch (selectedNumber)
                    {
                        case 1:
                            SelectCurrencyToBuy(Eur, Rub);

                            if (selectedSecondNumber == 1)
                            {
                                conversion = UsdToEur;
                            }
                            else if (selectedSecondNumber == 2)
                            {
                                conversion = UsdToRub;
                            }
                            else
                            {
                                Console.WriteLine("Такой валюты нет, повторите попытку");
                            }

                            isSelectCorrectNumber = true;
                            break;
                        case 2:
                            Console.WriteLine("На какую валюту Вы хотите поменять?");
                            Console.WriteLine($"1- {Usd} 2 - {Rub}");

                            selectedSecondNumber = ReadNumberFromKeyboard();

                            if (selectedSecondNumber == 1)
                            {
                                conversion = EurToUsd;
                            }
                            else if (selectedSecondNumber == 2)
                            {
                                conversion = EurToRub;
                            }

                            isSelectCorrectNumber = true;
                            break;
                        case 3:
                            SelectCurrencyToBuy(Eur, Rub);
                            selectedSecondNumber = ReadNumberFromKeyboard();
                            if (selectedSecondNumber == 1)
                            {
                                conversion = UsdToEur;
                            }
                            else if (selectedSecondNumber == 2)
                            {
                                conversion = UsdToRub;
                            }
                            isSelectCorrectNumber = true;
                            break;
                        default:
                            Console.WriteLine("Такой валюты нет, повторите попытку");
                            break;
                    }


                }
            }

            private static void SelectCurrencyToBuy(string firstCurrencyToChoose, string secondCurrencyToChoose)
            {
                Console.WriteLine("На какую валюту Вы хотите поменять?");
                Console.WriteLine($"1- {firstCurrencyToChoose} 2 - {secondCurrencyToChoose}");

                bool isSelectCorrectNumber = false;

                while (isSelectCorrectNumber == false)
                {
                    string conversion;

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
