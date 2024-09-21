using AutoServiceGame.Entities;
using AutoServiceGame.Entities.AutoServices;
using AutoServiceGame.Entities.Creators;

namespace AutoServiceGame;

class Program
{
    static void Main(string[] args)
    {
        InventoryCreator inventoryCreator = new InventoryCreator();

        Inventory inventory = inventoryCreator.CreateInventory();
        
        AutoServiceModel autoServiceModel = new AutoServiceModel(inventory, 5000);
        AutoServiceView autoServiceView = new AutoServiceView();

        AutoService autoService = new AutoService(autoServiceModel, autoServiceView);
        Game game = new Game(autoService);

        game.Run();
    }
}