namespace TopServerPlayers
{
    public class Program
    {
        public static void Main(string[] args)
        {
            PLayerCreator creator = new PLayerCreator();

            int playerCount = 30;
            List<Player> players = creator.CreateRandomPlayers(playerCount);

            Game game = new Game(players);
            game.Work();
        }
    }
}