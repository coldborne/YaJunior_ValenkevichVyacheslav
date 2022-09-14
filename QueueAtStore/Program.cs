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

            Process(ref purchaseAmounts, ref amountOfMoneyInStore);

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

        private static void Process(ref Queue<int> purchaseAmounts, ref int amountOfMoneyInStore)
        {
            while (purchaseAmounts.Count > 0)
            {
                Display(ref purchaseAmounts, ref amountOfMoneyInStore);

                amountOfMoneyInStore += purchaseAmounts.Dequeue();

                Console.ReadKey();
                Console.Clear();
            }
        }

        private static void Display(ref Queue<int> purchaseAmounts, ref int amountOfMoneyInStore)
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
