using AutoServiceGame.Entities.Cars;
using AutoServiceGame.Entities.Parts;

namespace AutoServiceGame.Entities.AutoServices;

public class AutoService
{
    private AutoServiceModel _autoServiceModel;
    private AutoServiceView _autoServiceView;

    public AutoService(AutoServiceModel autoServiceModel, AutoServiceView autoServiceView)
    {
        _autoServiceModel = autoServiceModel;
        _autoServiceView = autoServiceView;
    }

    public void RepairNewCar(Car car)
    {
        _autoServiceView.DisplayCarArrival(car);

        List<Part> brokenParts = car.GetBrokenParts();
        List<Part> unbrokenParts = car.GetUnbrokenParts();
        _autoServiceView.DisplayParts(unbrokenParts, brokenParts);

        List<Part> allParts = new List<Part>();
        allParts.AddRange(unbrokenParts);
        allParts.AddRange(brokenParts);

        _autoServiceView.DisplayRepairStartOption();
        string choice = Console.ReadLine();

        if (choice == "1")
        {
            _autoServiceView.DisplayStartRepairing();

            bool isRepairingFinished = false;

            while (isRepairingFinished == false && car.IsFullyRepaired() == false)
            {
                _autoServiceView.DisplayRepairOptions();
                string repairChoice = Console.ReadLine();

                if (repairChoice == "1")
                {
                    _autoServiceView.DisplayPartRepairOptions(allParts);

                    string partChoiceInput = Console.ReadLine();
                    int partChoice;

                    if (int.TryParse(partChoiceInput, out partChoice) && partChoice > 0 &&
                        partChoice <= allParts.Count)
                    {
                        Part selectedPart = allParts[partChoice - 1];

                        bool success = PerformRepair(car, selectedPart);

                        if (success)
                        {
                            _autoServiceView.DisplayRepairSuccess(selectedPart.Name, selectedPart.Price);
                            brokenParts.Remove(selectedPart);
                        }
                        else
                        {
                            _autoServiceView.DisplayRepairFailure(selectedPart.Name);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Неверный выбор. Попробуйте снова.");
                    }
                }
                else if (repairChoice == "2")
                {
                    decimal penalty = CalculatePenalty(brokenParts.Count);
                    _autoServiceModel.TryTopUpBalance(penalty);
                    _autoServiceView.DisplayPenalty(penalty);
                    isRepairingFinished = true;
                }
                else
                {
                    Console.WriteLine("Неверный выбор. Попробуйте снова.");
                }
            }

            if (car.IsFullyRepaired())
            {
                _autoServiceView.DisplayRepairCompleted();
            }
        }
        else if (choice == "2")
        {
            decimal penalty = _autoServiceModel.FixedPenalty;
            _autoServiceModel.TryTopUpBalance(penalty);
            _autoServiceView.DisplayPenalty(penalty);
        }
        else
        {
            Console.WriteLine("Неверный выбор. Возвращение в главное меню.");
        }
    }

    public void DisplayStartWindow()
    {
        _autoServiceView.ShowStartWindow();
    }

    public void DisplayMainMenu()
    {
        _autoServiceView.DisplayMainMenu();
    }

    public void DisplayBalance()
    {
        _autoServiceView.DisplayBalance(_autoServiceModel.Balance);
    }

    public void DisplayInventory()
    {
        _autoServiceView.DisplayInventory(_autoServiceModel.GetAllParts());
    }

    private bool PerformRepair(Car car, Part brokenPart)
    {
        bool partAvailable = _autoServiceModel.TryDecreasePartQuantity(brokenPart);

        if (partAvailable)
        {
            Part newPart = new Part(brokenPart.Name, brokenPart.Price, isBroken: false);

            bool repairSuccess = car.TryRepair(newPart);

            if (repairSuccess)
            {
                decimal repairPrice = _autoServiceModel.GetRepairPrice(brokenPart);
                decimal payment = brokenPart.Price + repairPrice;
                _autoServiceModel.TryTopUpBalance(payment);

                return true;
            }

            _autoServiceModel.TryIncreasePartQuantity(brokenPart);
            return false;
        }

        return false;
    }

    private decimal CalculatePenalty(int remainingBrokenParts)
    {
        decimal penaltyPerPart = 200m; // Пример значения
        return remainingBrokenParts * penaltyPerPart;
    }
}