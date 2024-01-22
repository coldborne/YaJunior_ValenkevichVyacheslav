using System.Collections.Generic;

namespace BookStorage
{
    public static class ListExtensions
    {
        public static List<Book> Clone(this List<Book> books)
        {
            List<Book> cloneBooks = new List<Book>();

            foreach (Book book in books)
            {
                cloneBooks.Add(book.Clone());
            }

            return cloneBooks;
        }
    }
}