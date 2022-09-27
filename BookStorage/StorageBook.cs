using System;
using System.Collections.Generic;
using System.Reflection;

namespace BookStorage
{
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
                book.ShowInfo();
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

        public Book CreateBook()
        {
            Console.WriteLine("Введите название книги");
            string bookName = ReadString();

            Console.WriteLine("Введите автора книги");
            string bookAuthor = ReadString();

            Console.WriteLine("Введите год выпуска книги");
            int bookReleaseYear = Program.ReadInt();

            return new Book(bookName, bookAuthor, bookReleaseYear);
        }

        public void ShowBook()
        {
            Console.WriteLine("Выберите один из возможных параметров:");

            Type bookType = typeof(Book);
            PropertyInfo[] bookFields = bookType.GetProperties();

            for (int i = 0; i < bookFields.Length; i++)
            {
                Console.Write($"{i + 1} - {bookFields[i].Name} ");
            }

            int selectedCommand = Program.ReadInt();

            switch (selectedCommand)
            {
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                default:
                    Console.WriteLine("Введена недопустимая команда");
                    break;
            }
        }

        public string ReadString()
        {
            string userInput = null;
            bool isInputRight = false;

            while (isInputRight == false)
            {
                userInput = Console.ReadLine();

                if (userInput.Trim() == "")
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
    }
}