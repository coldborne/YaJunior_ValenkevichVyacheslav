using System;

namespace Pictures
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int picturesCount = 52;
            int picturesInRow = 3;

            int filledRows = picturesCount / picturesInRow;
            int picturesInIncompleteRow = picturesCount % picturesInRow;

            Console.WriteLine("Количество заполненных рядов");
            Console.WriteLine(filledRows);

            Console.WriteLine("Количество картинок в незаполненном ряду");
            Console.WriteLine(picturesInIncompleteRow);
        }
    }
}
