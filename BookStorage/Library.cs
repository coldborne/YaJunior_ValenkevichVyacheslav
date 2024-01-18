using System;
using System.Collections.Generic;

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

        private void ChooseOption()
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
                    case (int)LibraryOperation.AddBook:
                        Console.WriteLine("Введите название книги");
                        _storageBook.TryGetBooksByName(UserUtils.ReadString(), out books);
                        break;

                    case (int)LibraryOperation.DeleteBook:
                        Console.WriteLine("Введите автора книги");
                        _storageBook.TryGetBooksByAuthor(UserUtils.ReadString(), out books);
                        break;

                    case (int)LibraryOperation.ShowAllBooks:
                        Console.WriteLine("Введите год издания книги");
                        _storageBook.TryGetBooksByReleaseYear(UserUtils.ReadIntNumber(), out books);
                        break;

                    default:
                        Console.WriteLine("Недопустимая команда");
                        break;
                }

                if (selectedCommand >= (int)LibraryOperation.AddBook && selectedCommand <= (int)LibraryOperation.ShowAllBooks)
                {
                    isCommandRight = true;
                }
            }
        }
    }
}