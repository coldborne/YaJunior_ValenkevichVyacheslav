namespace CriminalSearching;

public class Program
{
    public static void Main(string[] args)
    {
        CriminalCreator creator = new CriminalCreator();
        int criminalsCount = 20;
        List<Criminal> criminals = creator.CreateRandomCriminals(criminalsCount);

        Console.WriteLine("База данных: ");

        foreach (Criminal criminal in criminals)
        {
            Console.WriteLine(criminal);
        }

        Console.WriteLine();

        Console.Write("Введите рост преступника: ");
        int height = int.Parse(Console.ReadLine());

        Console.Write("Введите вес преступника: ");
        int weight = int.Parse(Console.ReadLine());

        Console.Write("Введите национальность преступника: ");
        string nationality = Console.ReadLine();

        List<Criminal> filteredCriminals = criminals.Where(criminal =>
                criminal.Height == height && criminal.Weight == weight &&
                criminal.Nationality.Equals(nationality, StringComparison.OrdinalIgnoreCase))
            .Where(criminal => criminal.IsUnderArrest == false).ToList();

        Console.WriteLine("\nПодходящие преступники:");

        if (filteredCriminals.Count != 0)
        {
            foreach (Criminal criminal in filteredCriminals)
            {
                Console.WriteLine(criminal);
            }
        }
        else
        {
            Console.WriteLine("Подходящих преступников не найдено");
        }
    }
}