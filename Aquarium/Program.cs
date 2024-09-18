namespace Aquarium
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Aquarium aquarium = new Aquarium();
            aquarium.Fill();

            Game game = new Game(aquarium);
            game.Play();
        }
    }
}