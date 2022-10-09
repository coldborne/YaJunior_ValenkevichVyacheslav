using System;
using System.Collections.Generic;
using System.Linq;

namespace BookStorage
{
    public class StorageBook
    {
        private List<Book> _books;

        public StorageBook()
        {
            _books = new List<Book>();
        }

        public void AddBook()
        {
            Book book = CreateBook();

            _books.Add(book);
        }

        public void TryRemoveBook()
        {
            if (_books.Count > 0)
            {
                Book book = TryToFindBook();

                if (book != null)
                {
                    _books.Remove(book);

                    Console.WriteLine("Была успешно удалена одна книга");
                }
                else
                {
                    Console.WriteLine("Книга не была найдена");
                }
            }
            else
            {
                Console.WriteLine("В хранилище нет книг");
            }
        }

        public void ShowAllBooks()
        {
            if (_books.Count > 0)
            {
                foreach (Book book in _books)
                {
                    book.ShowInfo();
                }
            }
            else
            {
                Console.WriteLine("В хранилище нет книг");
            }
        }

        public void ShowBooksByOption()
        {
            if (_books.Count > 0)
            {
                ChooseOption();
            }
            else
            {
                Console.WriteLine("В хранилище нет книг");
            }
        }

        private Book CreateBook()
        {
            Console.WriteLine("Введите название книги");
            string name = UserUtils.ReadString();

            Console.WriteLine("Введите автора книги");
            string author = UserUtils.ReadString();

            Console.WriteLine("Введите год выпуска книги");
            int releaseYear = UserUtils.ReadInt();

            return new Book(name, author, releaseYear);
        }

        private Book TryToFindBook()
        {
            Console.WriteLine("Введите название книги");
            string name = UserUtils.ReadString();

            Console.WriteLine("Введите автора книги");
            string author = UserUtils.ReadString();

            Console.WriteLine("Введите год выпуска книги");
            int releaseYear = UserUtils.ReadInt();

            return _books.Find(book => 
                book.Name == name && book.Author == author && book.ReleaseYear == releaseYear);
        }

        private void ChooseOption()
        {
            bool isCommandRight = false;

            Console.WriteLine("Выберите один из возможных параметров:");
            Console.WriteLine("1 - Название, 2 - Автор, 3 - Год издания");

            while (isCommandRight == false)
            {
                int selectedCommand = UserUtils.ReadInt();

                switch (selectedCommand)
                {
                    case (int)Commands.First:
                        ShowBookByName();
                        break;
                    case (int)Commands.Second:
                        ShowBookByAuthor();
                        break;
                    case (int)Commands.Third:
                        ShowBookByReleaseYear();
                        break;
                    default:
                        Console.WriteLine("Недопустимая команда");
                        break;
                }

                if (selectedCommand >= (int)Commands.First && selectedCommand <= (int)Commands.Third)
                {
                    isCommandRight = true;
                }
            }
        }

        private void ShowBookByName()
        {
            Console.WriteLine("Введите название книги");
            string name = UserUtils.ReadString();

            foreach (var book in _books.Where(book => book.Name == name))
            {
                book.ShowInfo();
            }
        }

        private void ShowBookByAuthor()
        {
            Console.WriteLine("Введите автора книги");
            string author = UserUtils.ReadString();

            foreach (var book in _books.Where(book => book.Author == author))
            {
                book.ShowInfo();
            }
        }

        private void ShowBookByReleaseYear()
        {
            Console.WriteLine("Введите год издания книги");
            int releaseYear = UserUtils.ReadInt();

            foreach (var book in _books.Where(book => book.ReleaseYear == releaseYear))
            {
                book.ShowInfo();
            }
        }
    }
}