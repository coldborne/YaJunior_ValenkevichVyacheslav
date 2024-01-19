using System;

namespace BookStorage
{
    public class BookCreator
    {
        private UserUtils _userUtils;

        public BookCreator()
        {
            _userUtils = new UserUtils();
        }

        public Book CreateBook()
        {
            Console.WriteLine("Введите название книги");
            string name = _userUtils.ReadString();

            Console.WriteLine("Введите автора книги");
            string author = _userUtils.ReadString();

            Console.WriteLine("Введите год выпуска книги");
            int releaseYear = _userUtils.ReadReleaseYear();

            return new Book(name, author, releaseYear);
        }
    }
}