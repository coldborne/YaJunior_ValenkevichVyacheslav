namespace DelayDefinition;

public class Program
{
    public static void Main(string[] args)
    {
        StewCreator stewCreator = new StewCreator();
        StewFactory stewFactory = new StewFactory(stewCreator);
        
        Game game = new Game(stewFactory);
        game.Play();
    }
}