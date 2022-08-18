using System;

namespace Sequence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int currentNumber = 5;
            int endNumber = 96;

            //Цикл while выбран, так как нам неважно, сколько раз выполнится цикл, нам лишь нужно показать условие выхода из цикла
            while(currentNumber <= endNumber)
            {
                Console.WriteLine(currentNumber);
                currentNumber+=7;
            }
        }
    }
}
