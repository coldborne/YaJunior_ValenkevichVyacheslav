using System;

namespace Pictures
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int picturesCount = 52;
            int picturesInRowCount = 3;

            int filledRowsCount = picturesCount / picturesInRowCount;
            int picturesInIncompleteRow = picturesCount % picturesInRowCount;

            Console.WriteLine("Количество заполненных рядов");
            Console.WriteLine(filledRowsCount);

            Console.WriteLine("Количество картинок в незаполненном ряду");
            Console.WriteLine(picturesInIncompleteRow);
        }
    }
}
