﻿using System;

namespace Aquarium
{
    public static class UserUtils
    {
        private static Random s_random = new Random();

        public static int GenerateRandomValue(int startValue, int endValue)
        {
            return s_random.Next(startValue, endValue);
        }

        public static int GenerateRandomValue(int endValue)
        {
            return s_random.Next(endValue);
        }

        public static int ReadInt(int maxValue)
        {
            int minValue = 0;
            int userInputValue = 0;
            bool isInputRight = false;

            while (isInputRight == false)
            {
                string userInput = Console.ReadLine();

                isInputRight = int.TryParse(userInput, out userInputValue);

                if (isInputRight == false)
                {
                    Console.WriteLine("Можно вводить только целые числа");
                }
                else
                {
                    if (userInputValue <= minValue || userInputValue > maxValue)
                    {
                        Console.WriteLine("Число должно быть больше 0 и меньше/равно " + maxValue);
                        isInputRight = false;
                    }
                }
            }

            return userInputValue;
        }
    }
}