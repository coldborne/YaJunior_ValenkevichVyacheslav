using System;

namespace PowerOfTwo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int maximumRandomNumberLimit = 100;
            int number = random.Next(maximumRandomNumberLimit + 1);

            Console.WriteLine("Число - " + number);

            int numberCopy = number;
            int powerOfTwo = 0;

            while (numberCopy > 0)
            {
                numberCopy /= 2;
                powerOfTwo++;
            }

            int nearestHigherNumber = Convert.ToInt32(Math.Pow(2, powerOfTwo));

            Console.WriteLine("Степень двойки превосходящего числа - " + powerOfTwo);
            Console.WriteLine("Превосходящее число " + nearestHigherNumber);
        }
    }
}
