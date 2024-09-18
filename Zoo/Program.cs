using Zoo.Entities;

namespace Zoo
{
    internal class Program
    {
        
        public static void Main(string[] args)
        {
            Entities.Zoo zoo = Entities.Zoo.Instance;
            ZooView zooView = new ZooView();

            Game game = new Game(zoo, zooView);
            game.Play();
        }
    }
}