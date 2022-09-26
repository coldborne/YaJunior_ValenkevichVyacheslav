using System;
using System.Collections.Generic;
using System.Dynamic;

namespace BookStorage
{
    internal class Program
    {
        public static int CurrentYear = DateTime.Now.Year;

        static void Main(string[] args)
        {
            StorageBook storageBook = new StorageBook();
        }
    }

    public class Book
    {
        public string Name { get; private set; }
        public string Author { get; private set; }
        public int ReleaseYear { get; private set; }

        public Book(string name, string author, int releaseYear)
        {
            Name = name;
            Author = author;
            ReleaseYear = releaseYear;
        }
    }

    public class StorageBook
    {
        public List<Book> Books { get; private set; }

        public StorageBook()
        {
            Books = new List<Book>();
        }

        public void ShowAllBooks()
        {
            foreach (Book book in Books)
            {
                Console.WriteLine("Книга - " + book);
            }
        }

        public void AddBook()
        {
            Book book = CreateBook();

            Books.Add(book);
        }

        public bool TryRemoveBook()
        {
            return true;
        }

        public void ShowBook(string parametr)
        {

        }

        public Book CreateBook()
        {
            Console.WriteLine("Введите название книги");
            string bookName = ReadString();

            Console.WriteLine("Введите автора книги");
            string bookAuthor = ReadString();

            Console.WriteLine("Введите год выпуска книги");
            int bookReleaseYear = ReadInt();

            return new Book(bookName, bookAuthor, bookReleaseYear);
        }

        public string ReadString()
        {
            string userInput = null;
            bool isInputRight = false;

            while (isInputRight == false)
            {
                userInput = Console.ReadLine();

                if (userInput.Trim() == "" || userInput == null)
                {
                    Console.WriteLine("Строка должна содержать хотя бы один символ неравный пробелу");
                }
                else
                {
                    isInputRight = true;
                }
            }

            return userInput;
        }

        public int ReadInt()
        {
            int userInputInt = 0;
            bool isInputRight = false;

            while (isInputRight == false)
            {
                string userInput = Console.ReadLine();

                isInputRight = int.TryParse(userInput, out userInputInt);

                if (isInputRight == false)
                {
                    Console.WriteLine("Можно вводить только целые числа");
                }
                else
                {
                    if (userInputInt > 2022)
                    {
                        Console.WriteLine($"Текущий год - {Program.CurrentYear}, год выпуска не может быть больше текущего года");
                        isInputRight = false;
                    }
                }
            }

            return userInputInt;
        }
    }
}
