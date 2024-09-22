using AutoServiceGame.Entities.AutoServices;
using AutoServiceGame.Entities.Cars;
using AutoServiceGame.Entities.Creators;

namespace AutoServiceGame.Entities;

public class Game
{
    private AutoService _autoService;
    private CarCreator _carCreator;

    public Game(AutoService autoService)
    {
        _autoService = autoService;
        _carCreator = new CarCreator();
    }

    public void Run()
    {
        const string RepairNewCarCommand = "1";
        const string DisplayBalanceCommand = "2";
        const string DisplayWarehousePartsCommand = "3";
        const string ExitCommand = "0";
        _autoService.DisplayStartWindow();
        bool isExit = false;

        while (isExit == false)
        {
            _autoService.DisplayMainMenu();
            string choice = Console.ReadLine();

            switch (choice)
            {
                case RepairNewCarCommand:
                    RepairNewCar(_carCreator.CreateCar());
                    break;

                case DisplayBalanceCommand:
                    _autoService.DisplayBalance();
                    break;

                case DisplayWarehousePartsCommand:
                    _autoService.DisplayWarehouseParts();
                    break;

                case ExitCommand:
                    isExit = true;
                    break;

                default:
                    Console.WriteLine("Некорректный выбор. Нажмите любую клавишу, чтобы продолжить...");
                    Console.ReadKey();
                    break;
            }
        }

        Console.WriteLine("Спасибо за использование Автосервиса!");
    }

    private void RepairNewCar(Car car)
    {
        _autoService.RepairNewCar(car);
    }
}