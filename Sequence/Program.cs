using System;

namespace Sequence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int currentNumber = 5;
            int endNumber = 96;
            int iteratorStep = 7;

            //Цикл for выбран, так как мы знаем, с какого значения цикл начинается, знаем, насколько нужно повышать итератор, а также каким число закончить цикл
            for (; currentNumber <= endNumber; currentNumber += iteratorStep)
            {
                Console.WriteLine(currentNumber);
            }
        }
    }
}
