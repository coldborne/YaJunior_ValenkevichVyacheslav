using System;

namespace CrystalShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int goldForOneCrystal = 4;
            int crystalAmount = 0;

            Console.WriteLine("Введите количества Вашего золота");
            bool isIntValue = int.TryParse(Console.ReadLine(), out int goldAmount);

            if (!isIntValue)
            {
                Console.WriteLine("Можно вводить только числа");
            }

            crystalAmount = goldAmount / goldForOneCrystal;
            goldAmount %= goldForOneCrystal;

            Console.WriteLine($"Куплено кристаллов - {crystalAmount}\nУ Вас осталось золота - {goldAmount}");
        }
    }
}
