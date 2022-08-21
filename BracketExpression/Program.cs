using System;

namespace BracketExpression
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int expressionValidityScore = 0;
            int depth = 0;
            char closingBracket = ')';
            char openingBracket = '(';
            string stringOfBrackets = ")(";

            foreach (var symbol in stringOfBrackets)
            {
                if (symbol == openingBracket)
                {
                    expressionValidityScore++;

                    if (expressionValidityScore > depth)
                    {
                        depth = expressionValidityScore;
                    }
                }
                else if (symbol == closingBracket)
                {
                    expressionValidityScore--;
                }

                if (expressionValidityScore < 0)
                {
                    break;
                }
            }

            Console.WriteLine(stringOfBrackets);

            if (expressionValidityScore == 0)
            {
                Console.WriteLine("Строка верная, глубина = " + depth);
            }
            else
            {
                Console.WriteLine("Строка неверная");
            }
        }
    }
}
