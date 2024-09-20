using AutoServiceGame.Entities.AutoServices;

namespace AutoServiceGame.Entities;

public class Game
{
    private AutoService _autoService;

    public Game(AutoService autoService)
    {
        _autoService = autoService;
    }

    public void Run()
    {
        _autoService.ShowStartWindow();
        bool isExit = false;

        while (isExit == false)
        {
            _autoService.DisplayMainMenu();
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    //StartRepairProcess();
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

    /*private void StartRepairProcess()
    {
        // Создаем новую машину для ремонта
        var carParts = new List<PartModel>
        {
            new PartModel("Двигатель", 500m, isBroken: true),
            new PartModel("Колесо", 100m, isBroken: true),
            new PartModel("Тормоза", 150m, isBroken: false)
        };

        var car = new CarModel("Toyota", carParts);
        var carViewModel = new CarViewModel(car);

        AutoServiceView.DisplayCarArrival(car);

        StartRepair(carViewModel);
    }

    public void StartRepair(CarViewModel carViewModel)
    {
        while (!carViewModel.IsRepaired())
        {
            var brokenParts = carViewModel.Car.GetBrokenParts();
            _autoServiceView.DisplayBrokenParts(brokenParts);
            _autoServiceView.DisplayRepairOptions();

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                _autoServiceView.DisplayPartRepairOptions(brokenParts);
                if (int.TryParse(Console.ReadLine(), out int partChoice) && partChoice > 0 &&
                    partChoice <= brokenParts.Count)
                {
                    var partToRepair = brokenParts[partChoice - 1];
                    var partViewModel = new PartViewModel(partToRepair);

                    if (partViewModel.Repair(_autoServiceModel))
                    {
                        decimal payment = partToRepair.Price + _autoServiceModel.RepairPrice;
                        _autoServiceView.DisplayRepairSuccess(partToRepair, payment);
                    }
                    else
                    {
                        _autoServiceView.DisplayRepairFailure(partToRepair.Name);
                    }
                }
                else if (partChoice == 0)
                {
                    continue;
                }
                else
                {
                    Console.WriteLine("Некорректный выбор. Нажмите любую клавишу, чтобы продолжить...");
                    Console.ReadKey();
                }
            }
            else if (choice == "2")
            {
                HandleRefusal(carViewModel);
                return;
            }
            else
            {
                Console.WriteLine("Некорректный выбор. Нажмите любую клавишу, чтобы продолжить...");
                Console.ReadKey();
            }
        }

        _autoServiceView.DisplayRepairCompleted();
    }

    public void ShowBrokenParts(Car car)
    {
        var brokenParts = car.GetBrokenParts();

        if (brokenParts.Any())
        {
            Console.WriteLine("Список поломанных деталей:");
            foreach (var part in brokenParts)
            {
                Console.WriteLine($"- {part.Name} (Цена: {part.Price:C})");
            }
        }
        else
        {
            Console.WriteLine("Все детали исправны.");
        }
    }

    private void HandleRefusal(CarViewModel carViewModel)
    {
        var brokenParts = carViewModel.Car.GetBrokenParts();
        decimal penalty = brokenParts.Any()
            ? _autoServiceModel.PenaltyPerBrokenPart * brokenParts.Count
            : _autoServiceModel.FixedPenalty;

        _autoServiceModel.TryWithdrawBalance(penalty);
        _autoServiceView.DisplayPenalty(penalty);
    }*/
}