namespace TopServerPlayers
{
    public class Program
    {
        public static void Main(string[] args)
        {
            PLayerCreator creator = new PLayerCreator();

            int playerCount = 30;
            List<Player> players = creator.CreateRandomPlayers(playerCount);

            Console.WriteLine("Список игроков:");

            foreach (Player player in players)
            {
                Console.WriteLine(player);
            }

            Console.WriteLine();

            int topLevelPlayersCount = 3;
            int topStrengthPlayersCount = 3;

            List<Player> topLevelPlayers =
                players.OrderByDescending(player => player.Level).Take(topLevelPlayersCount).ToList();
            List<Player> topStrengthPlayers = players.OrderByDescending(player => player.Strength)
                .Take(topStrengthPlayersCount).ToList();

            Console.WriteLine("Топ игроков по уровню:");

            foreach (Player player in topLevelPlayers)
            {
                Console.WriteLine(player);
            }

            Console.WriteLine();

            Console.WriteLine("Топ игроков по силе:");

            foreach (Player player in topStrengthPlayers)
            {
                Console.WriteLine(player);
            }
        }
    }
}