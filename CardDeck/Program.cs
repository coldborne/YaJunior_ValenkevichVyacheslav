namespace CardDeck
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int CardsCount = 54;
            
            Game game = new Game(CardsCount);

            game.Work();
        }
    }
}