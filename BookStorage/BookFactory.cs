using System;

namespace BookStorage
{
    public class BookFactory
    {
        public Book CreateBook()
        {
            Console.WriteLine("Введите название книги");
            string name = UserUtils.ReadString();

            Console.WriteLine("Введите автора книги");
            string author = UserUtils.ReadString();

            Console.WriteLine("Введите год выпуска книги");
            int releaseYear = UserUtils.ReadReleaseYear();

            return new Book(name, author, releaseYear);
        }
    }
}