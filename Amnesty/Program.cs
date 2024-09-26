using Amnesty;

namespace CriminalSearching;

public class Program
{
    public static void Main(string[] args)
    {
        CriminalCreator creator = new CriminalCreator();
        int criminalsCount = 20;
        List<Criminal> criminals = creator.CreateRandomCriminals(criminalsCount);

        Console.WriteLine("Преступники до амнистии: ");

        foreach (Criminal criminal in criminals)
        {
            Console.WriteLine(criminal);
        }

        Console.WriteLine();

        string amnestyCrime = "Антиправительственное";
        criminals = criminals.Where(criminal => criminal.Crime != amnestyCrime).ToList();

        Console.WriteLine("\nПреступники после амнистии:");

        if (criminals.Count != 0)
        {
            foreach (Criminal criminal in criminals)
            {
                Console.WriteLine(criminal);
            }
        }
        else
        {
            Console.WriteLine("Преступников не осталось");
        }
    }
}