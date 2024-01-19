using System;
using System.Collections.Generic;
using System.Linq;

namespace BookStorage
{
    public class Library
    {
        private StorageBook _storageBook;
        private BookFactory _bookFactory;

        public Library()
        {
            _storageBook = new StorageBook();
            _bookFactory = new BookFactory();
        }

        public void Start()
        {
            Console.WriteLine("Добро пожаловать в наше хранилище игр");
            Console.WriteLine("Выберите одно из возможных действий:");

            bool isStorageOpen = true;

            while (isStorageOpen)
            {
                Console.WriteLine(
                    "1 - добавить книгу, 2 - убрать книгу, 3 - показать все книги, " +
                    "4 - показать книги по конкретному параметру, 5 - Выход");

                int selectedCommand = UserUtils.ReadIntNumber();

                switch (selectedCommand)
                {
                    case (int)LibraryOperation.AddBook:
                        AddBook();
                        break;

                    case (int)LibraryOperation.DeleteBook:
                        DeleteBook();
                        break;

                    case (int)LibraryOperation.ShowAllBooks:
                        ShowAllBooks();
                        break;

                    case (int)LibraryOperation.ShowBooksByParameter:
                        ShowBooksByOption();
                        break;

                    case (int)LibraryOperation.Exit:
                        isStorageOpen = false;
                        break;

                    default:
                        ConsoleColorizer.WriteLineColored("Введена недопустимая команда", ConsoleColor.Red);
                        break;
                }
            }
        }

        private void AddBook()
        {
            Book book = _bookFactory.CreateBook();

            if (_storageBook.TryAddBook(book))
            {
                ConsoleColorizer.WriteLineColored(
                    $"Книга: {book.Name} {book.Author} {book.ReleaseYear} успешно добавлена в хранилище",
                    ConsoleColor.Green);
            }
            else
            {
                ConsoleColorizer.WritePartiallyColored(
                    $"Книга: {book.Name} {book.Author} {book.ReleaseYear} НЕ добавлена",
                    "НЕ",
                    ConsoleColor.Red);
                ConsoleColorizer.WriteLineColored("Данная книга уже существует в хранилище", ConsoleColor.DarkRed);
            }
        }

        private void DeleteBook()
        {
            if (_storageBook.BookCount > 0)
            {
                Book book = _bookFactory.CreateBook();

                if (_storageBook.TryRemoveBook(book))
                {
                    ConsoleColorizer.WriteLineColored(
                        $"Книга: {book.Name} {book.Author} {book.ReleaseYear} успешно удалена из хранилища",
                        ConsoleColor.Green);
                }
                else
                {
                    ConsoleColorizer.WritePartiallyColored(
                        $"Книга: {book.Name} {book.Author} {book.ReleaseYear} НЕ найдена в хранилище",
                        "НЕ",
                        ConsoleColor.Red);
                }
            }
            else
            {
                ConsoleColorizer.WriteLineColored("В хранилище нет книг", ConsoleColor.DarkRed);
            }
        }

        private void ShowAllBooks()
        {
            if (_storageBook.BookCount > 0)
            {
                List<Book> books = _storageBook.GetAllBooks();

                foreach (Book book in books)
                {
                    book.ShowInfo();
                }
            }
            else
            {
                ConsoleColorizer.WriteLineColored("В хранилище нет книг", ConsoleColor.DarkRed);
            }
        }

        private void ShowBooksByOption()
        {
            bool isCommandRight = false;

            Console.WriteLine("Выберите один из возможных параметров:");
            Console.WriteLine("1 - Название, 2 - Автор, 3 - Год издания");

            List<Book> books = new List<Book>();

            while (isCommandRight == false)
            {
                int selectedCommand = UserUtils.ReadIntNumber();

                switch (selectedCommand)
                {
                    case (int)BookSearchOption.FindBookByName:
                        books = FindBookByName();
                        break;

                    case (int)BookSearchOption.FindBookByAuthor:
                        books = FindBookByAuthor();
                        break;

                    case (int)BookSearchOption.FindBookByReleaseYear:
                        books = FindBookByReleaseYear();
                        break;

                    default:
                        ConsoleColorizer.WriteLineColored("Введена недопустимая команда", ConsoleColor.Red);
                        break;
                }

                if (selectedCommand >= (int)BookSearchOption.FindBookByName &&
                    selectedCommand <= (int)BookSearchOption.FindBookByReleaseYear)
                {
                    isCommandRight = true;
                }
            }

            if (books.Any())
            {
                foreach (Book book in books)
                {
                    book.ShowInfo();
                }
            }
            else
            {
                ConsoleColorizer.WriteLineColored("В хранилище нет таких книг", ConsoleColor.Red);
            }
        }

        private List<Book> FindBookByName()
        {
            Console.WriteLine("Введите название книги");

            return _storageBook.TryGetBooksByName(UserUtils.ReadString(), out List<Book> books)
                ? books
                : new List<Book>();
        }

        private List<Book> FindBookByAuthor()
        {
            Console.WriteLine("Введите автора книги");

            return _storageBook.TryGetBooksByAuthor(UserUtils.ReadString(), out List<Book> books)
                ? books
                : new List<Book>();
        }

        private List<Book> FindBookByReleaseYear()
        {
            Console.WriteLine("Введите год издания книги");

            return _storageBook.TryGetBooksByReleaseYear(UserUtils.ReadReleaseYear(), out List<Book> books)
                ? books
                : new List<Book>();
        }
    }
}