using System;

namespace LocalMaxima
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int studentGradesSize = 30;
            int[] studentGrades = new int[studentGradesSize];

            Random random = new Random();
            int maximumValue = 100;
            int minimumValue = 0;

            for (int i = 0; i < studentGrades.Length; i++)
            {
                studentGrades[i] = random.Next(minimumValue, maximumValue + 1);
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

            int lastStudentIndex = studentGrades.Length - 1;

            if (studentGrades[studentGrades.Length - 1] >= studentGrades[lastStudentIndex - 1])
            {
                Console.Write(studentGrades[studentGrades.Length - 1]);
            }

            Console.WriteLine();
        }
    }
}
