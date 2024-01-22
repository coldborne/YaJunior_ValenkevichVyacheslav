using System.Collections.Generic;
using System.Linq;

namespace BookStorage
{
    public class StorageBook
    {
        private HashSet<Book> _books;

        public StorageBook()
        {
            _books = new HashSet<Book>();
        }

        public StorageBook(HashSet<Book> books)
        {
            _books = books;
        }

        public bool HasAnyBook => _books.Count != 0;

        public bool TryAddBook(Book book)
        {
            return _books.Add(book);
        }

        public bool TryRemoveBook(Book book)
        {
            return _books.Remove(book);
        }

        public List<Book> GetAllBooks()
        {
            return _books.ToList().Clone();
        }

        public bool TryGetBooksByName(string name, out List<Book> books)
        {
            books = _books.Where(book => book.Name == name).ToList().Clone();

            return books != null;
        }

        public bool TryGetBooksByAuthor(string author, out List<Book> books)
        {
            books = _books.Where(book => book.Author == author).ToList().Clone();

            return books != null;
        }

        public bool TryGetBooksByReleaseYear(int releaseYear, out List<Book> books)
        {
            books = _books.Where(book => book.ReleaseYear == releaseYear).ToList().Clone();

            return books.Any();
        }
    }
}