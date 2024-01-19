using System;
using System.Collections.Generic;
using System.Linq;

namespace BookStorage
{
    public class Library
    {
        private StorageBook _storageBook;
        private BookCreator _bookCreator;
        private UserUtils _userUtils;

        public Library()
        {
            _storageBook = new StorageBook();
            _bookCreator = new BookCreator();
            _userUtils = new UserUtils();
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

                int selectedCommand = _userUtils.ReadIntNumber();

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
            Book book = _bookCreator.CreateBook();

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
            if (_storageBook.HasAnyBook)
            {
                Book book = _bookCreator.CreateBook();

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
            if (_storageBook.HasAnyBook)
            {
                List<Book> books = _storageBook.GetAllBooks();

                WriteLine(books);
            }
            else
            {
                ConsoleColorizer.WriteLineColored("В хранилище нет книг", ConsoleColor.DarkRed);
            }
        }

        private void ShowBooksByOption()
        {
            if (_storageBook.HasAnyBook)
            {
                bool isCommandRight = false;

                Console.WriteLine("Выберите один из возможных параметров:");
                Console.WriteLine("1 - Название, 2 - Автор, 3 - Год издания");

                List<Book> books = new List<Book>();

                while (isCommandRight == false)
                {
                    int selectedCommand = _userUtils.ReadIntNumber();

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
                    WriteLine(books);
                }
                else
                {
                    ConsoleColorizer.WriteLineColored("В хранилище нет таких книг", ConsoleColor.Red);
                }
            }
            else
            {
                ConsoleColorizer.WriteLineColored("В хранилище нет книг", ConsoleColor.DarkRed);
            }
        }

        private void WriteLine(List<Book> books)
        {
            foreach (Book book in books)
            {
                ConsoleColorizer.WriteLineColored(book.GetInfo(), ConsoleColor.Yellow);
            }
        }

        private List<Book> FindBookByName()
        {
            Console.WriteLine("Введите название книги");

            return _storageBook.TryGetBooksByName(_userUtils.ReadString(), out List<Book> books)
                ? books
                : new List<Book>();
        }

        private List<Book> FindBookByAuthor()
        {
            Console.WriteLine("Введите автора книги");

            return _storageBook.TryGetBooksByAuthor(_userUtils.ReadString(), out List<Book> books)
                ? books
                : new List<Book>();
        }

        private List<Book> FindBookByReleaseYear()
        {
            Console.WriteLine("Введите год издания книги");

            return _storageBook.TryGetBooksByReleaseYear(_userUtils.ReadReleaseYear(), out List<Book> books)
                ? books
                : new List<Book>();
        }
    }
}