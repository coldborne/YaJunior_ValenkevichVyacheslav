using System;
using System.Collections.Generic;

namespace QueueAtStore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> purchaseAmounts = new Queue<int>();
            int amountOfMoneyInStore = 0;

            purchaseAmounts = AddElements(purchaseAmounts);

            while (purchaseAmounts.Count > 0)
            {
                Display(purchaseAmounts, amountOfMoneyInStore);

                amountOfMoneyInStore += purchaseAmounts.Dequeue();

                Console.ReadKey();
                Console.Clear();
            }

            Console.WriteLine("Необработанных покупок не осталось");
            Console.WriteLine("Деньги в кассе - " + amountOfMoneyInStore);
        }

        private static Queue<int> AddElements(Queue<int> purchaseAmounts)
        {
            int numberOfItemsInQueue = 5;
            Random random = new Random();
            int maxNumberOfRandom = 100;

            for (int i = 0; i < numberOfItemsInQueue; i++)
            {
                purchaseAmounts.Enqueue(random.Next(maxNumberOfRandom) + 1);
            }

            return purchaseAmounts;
        }

        private static void Display(Queue<int> purchaseAmounts, int amountOfMoneyInStore)
        {
            Console.WriteLine("Все необработанные покупки от первой до последней");

            foreach (int purchaseAmount in purchaseAmounts)
            {
                Console.WriteLine(purchaseAmount);
            }

            Console.WriteLine("Сумма следующей покупки - " + purchaseAmounts.Peek());
            Console.WriteLine("Деньги в кассе - " + amountOfMoneyInStore);
        }
    }
}
