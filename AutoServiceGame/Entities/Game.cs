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
        _autoService.DisplayStartWindow();
        bool isExit = false;

        while (isExit == false)
        {
            _autoService.DisplayMainMenu();
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    RepairNewCar(_carCreator.CreateCar());
                    break;

                case "2":
                    _autoService.DisplayBalance();
                    break;

                case "3":
                    _autoService.DisplayInventory();
                    break;

                case "0":
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