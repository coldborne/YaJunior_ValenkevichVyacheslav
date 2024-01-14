using System;
using System.Collections.Generic;
using System.Linq;

namespace MergingIntoOneCollection
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string[] classAGrades = { "3", "2", "4", "2", "5", "1", "6", "1" };
            string[] classBGrades = { "1", "4", "3", "2" };

            HashSet<string> uniqueGrades = new HashSet<string>();

            foreach (string grade in classAGrades)
            {
                uniqueGrades.Add(grade);
            }

            foreach (string grade in classBGrades)
            {
                uniqueGrades.Add(grade);
            }

            string[] unionOfGrades = new string[uniqueGrades.Count];
            int startPositionToCopy = 0;

            uniqueGrades.CopyTo(unionOfGrades, startPositionToCopy);

            Array.Sort(unionOfGrades);

            Console.WriteLine("Уникальные строки: ");

            foreach (string grade in unionOfGrades)
            {
                Console.WriteLine(grade);
            }
        }
    }
}