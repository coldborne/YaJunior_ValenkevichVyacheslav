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

    public static class UserUtils
    {
        private static readonly int CurrentYear = DateTime.Now.Year;

        public static string ReadString()
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

        public static int ReadIntNumber()
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

        public static int ReadReleaseYear()
        {
            int releaseYear = 0;
            bool isInputRight = false;

            while (isInputRight == false)
            {
                string userInput = Console.ReadLine();

                isInputRight = int.TryParse(userInput, out releaseYear);

                if (isInputRight == false)
                {
                    Console.WriteLine("Можно вводить только целые числа");
                }
                else
                {
                    if (releaseYear > CurrentYear)
                    {
                        Console.WriteLine(
                            $"Текущий год - {CurrentYear}, год выпуска не может быть больше текущего года");
                        Console.WriteLine("Попробуйте ещё раз");

                        isInputRight = false;
                    }
                }
            }

            return releaseYear;
        }
    }
}