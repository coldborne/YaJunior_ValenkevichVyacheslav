using System;
using System.Collections.Generic;
using System.Linq;

namespace MergingIntoOneCollection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] classAGrades = { "3", "2", "4", "2", "5", "1", "6", "1" };
            string[] classBGrades = { "1", "4", "3", "2", "5", "1" };

            string[] unionOfGrades = classAGrades.Concat(classBGrades).ToArray();

            HashSet<string> uniqueGrades = new HashSet<string>(unionOfGrades);
            unionOfGrades = uniqueGrades.ToArray();

            Array.Sort(unionOfGrades);
            
            foreach(string grade in unionOfGrades)
            {
                Console.WriteLine(grade);
            }
        }
    }
}
