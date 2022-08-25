using System;

namespace LocalMaxima
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int StudentGradesSize = 30;
            int[] studentGrades = new int[StudentGradesSize];

            Random random = new Random();
            int maximumValue = 100;

            for (int i = 0; i < StudentGradesSize; i++)
            {
                studentGrades[i] = random.Next(0, maximumValue + 1);
            }

            Console.WriteLine("Ваш массив:");

            for (int i = 0; i < StudentGradesSize; i++)
            {
                Console.Write(studentGrades[i] + " ");
            }

            Console.WriteLine("\nВсе локальные максимумы:");

            for (int i = 0; i < StudentGradesSize; i++)
            {
                if (i > 0 && i < (StudentGradesSize - 1))
                {
                    if (studentGrades[i] > studentGrades[i - 1] && studentGrades[i] > studentGrades[i + 1])
                    {
                        Console.Write(studentGrades[i] + " ");
                        i++;
                    }
                }
                else if (i == 0)
                {
                    if (studentGrades[i] > studentGrades[i + 1])
                    {
                        Console.Write(studentGrades[i] + " ");
                        i++;
                    }
                }
                else if (i == StudentGradesSize - 1)
                {
                    if (studentGrades[i] > studentGrades[i - 1])
                    {
                        Console.Write(studentGrades[i]);
                    }

                    Console.WriteLine();
                }
            }
        }
    }
}
