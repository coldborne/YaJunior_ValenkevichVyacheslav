using System;

namespace BookStorage
{
    public enum LibraryOperation
    {
        AddBook = 1,
        DeleteBook,
        ShowAllBooks,
        ShowBooksByParameter,
        Exit
    }

    public enum BookSearchOption
    {
        FindBookByName = 1,
        FindBookByAuthor,
        FindBookByReleaseYear
    }

    public class UserUtils
    {
        private static readonly int _currentYear = DateTime.Now.Year;

        public string ReadString()
        {
            string userInput = null;
            bool isInputRight = false;

            while (isInputRight == false)
            {
                userInput = Console.ReadLine();

                if (userInput == null || userInput.Trim() == "")
                {
                    Console.WriteLine("Строка должна содержать хотя бы один символ, отличный от пробела");
                }
                else
                {
                    isInputRight = true;
                }
            }

            return userInput.Trim();
        }

        public int ReadIntNumber()
        {
            int userNumber = 0;
            bool isInputRight = false;

            while (isInputRight == false)
            {
                string userInput = Console.ReadLine();

                isInputRight = int.TryParse(userInput, out userNumber);

                if (isInputRight == false)
                {
                    Console.WriteLine("Можно вводить только целые числа");
                }
            }

            return userNumber;
        }

        public int ReadReleaseYear()
        {
            int releaseYear = 0;
            bool isInputRight = false;

            while (isInputRight == false)
            {
                releaseYear = ReadIntNumber();

                if (releaseYear > _currentYear)
                {
                    Console.WriteLine(
                        $"Текущий год - {_currentYear}, год выпуска не может быть больше текущего года");
                    Console.WriteLine("Попробуйте ещё раз");
                }
                else
                {
                    isInputRight = true;
                }
            }

            return releaseYear;
        }
    }
}