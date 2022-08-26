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

            for (int i = 0; i < studentGrades.Length; i++)
            {
                studentGrades[i] = random.Next(0, maximumValue + 1);
            }

            Console.WriteLine("Ваш массив:");

            for (int i = 0; i < studentGrades.Length; i++)
            {
                Console.Write(studentGrades[i] + " ");
            }

            Console.WriteLine("\nВсе локальные максимумы:");

            if (studentGrades[0] >= studentGrades[1])
            {
                Console.Write(studentGrades[0] + " ");
            }

            for (int i = 1; i < studentGrades.Length - 1; i++)
            {
                if (studentGrades[i] >= studentGrades[i - 1] && studentGrades[i] >= studentGrades[i + 1])
                {
                    Console.Write(studentGrades[i] + " ");
                }
            }

            if (studentGrades[studentGrades.Length - 1] >= studentGrades[studentGrades.Length - 2])
            {
                Console.Write(studentGrades[studentGrades.Length - 1]);
            }

            Console.WriteLine();
        }
    }
}
