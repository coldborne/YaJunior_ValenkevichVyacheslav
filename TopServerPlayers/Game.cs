namespace TopServerPlayers;

public class Game
{
    private List<Player> _players;

    public Game(List<Player> players)
    {
        _players = players;
    }

    public void Work()
    {
        ShowPlayers(_players, "Список игроков:");
        Console.WriteLine();

        int topLevelPlayersCount = 3;
        int topStrengthPlayersCount = 3;

        List<Player> topLevelPlayers =
            _players.OrderByDescending(player => player.Level).Take(topLevelPlayersCount).ToList();

        List<Player> topStrengthPlayers = _players.OrderByDescending(player => player.Strength)
            .Take(topStrengthPlayersCount).ToList();

        ShowPlayers(topLevelPlayers, "Топ игроков по уровню:");
        Console.WriteLine();

        ShowPlayers(topStrengthPlayers, "Топ игроков по силе:");
    }

    private void ShowPlayers(List<Player> players, string message)
    {
        Console.WriteLine(message);

        foreach (Player player in players)
        {
            Console.WriteLine(player);
        }
    }
}