using System;

namespace PersonnelAccountingPRO
{
    public enum Commands: byte
    {
        First = 1,
        Second,
        Third,
        Fourth
    }
    
    public class UserUtils
    {
        public static int ReadIntValue()
        {
            int value = 0;
            bool isIntValue = false;

            while (isIntValue == false)
            {
                string userInput = Console.ReadLine();
                isIntValue = int.TryParse(userInput, out value);

                if (isIntValue == false)
                {
                    Console.WriteLine("Можно вводить только числа");
                }
            }

            return value;
        }
    }
}