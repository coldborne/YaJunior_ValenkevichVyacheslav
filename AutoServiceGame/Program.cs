using AutoServiceGame.Entities;
using AutoServiceGame.Entities.AutoServices;
using AutoServiceGame.Entities.Parts;

namespace AutoServiceGame;

class Program
{
    static void Main(string[] args)
    {
        List<Item> parts = new List<Item>()
        {
            new Item(new Part("Двигатель", 2), 5),
            new Item(new Part("Колесо", 4), 3),
            new Item(new Part("Тормоза", 3), 2),
        };
        
        Inventory inventory = new Inventory(parts);
        
        AutoServiceModel autoServiceModel = new AutoServiceModel(inventory, 5000);
        AutoServiceView autoServiceView = new AutoServiceView();

        AutoService autoService = new AutoService(autoServiceModel, autoServiceView);
        Game game = new Game(autoService);

        game.Run();

        
    }
}