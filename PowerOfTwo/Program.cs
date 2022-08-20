using System;

namespace PowerOfTwo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int baseNumber = 2;
            int exponent = 0;

            Random random = new Random();
            int maximumRandomNumberLimit = 100;
            int number = random.Next(maximumRandomNumberLimit + 1);

            Console.WriteLine("Число - " + number);

            int temporaryNumber = 1;

            while (temporaryNumber <= number)
            {
                temporaryNumber *= baseNumber;
                exponent++;
            }

            int nearestHigherNumber = Convert.ToInt32(Math.Pow(baseNumber, exponent));

            Console.WriteLine("Степень двойки превосходящего числа - " + exponent);
            Console.WriteLine("Превосходящее число " + nearestHigherNumber);
        }
    }
}
