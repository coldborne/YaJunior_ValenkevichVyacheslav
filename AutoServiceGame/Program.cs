using AutoServiceGame.Entities;
using AutoServiceGame.Entities.AutoServices;
using AutoServiceGame.Entities.Creators;

namespace AutoServiceGame;

class Program
{
    static void Main(string[] args)
    {
        AutoServiceCreator autoServiceCreator = new AutoServiceCreator();

        AutoService autoService = autoServiceCreator.CreateAutoService(5000);
        
        Game game = new Game(autoService);

        game.Run();
    }
}