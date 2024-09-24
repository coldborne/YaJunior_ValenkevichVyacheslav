using AutoServiceGame.Entities.Cars;
using AutoServiceGame.Entities.Parts;

namespace AutoServiceGame.Entities.AutoServices;

public class AutoService
{
    private AutoServiceModel _model;
    private AutoServiceView _view;

    public AutoService(AutoServiceModel model, AutoServiceView view)
    {
        _model = model;
        _view = view;
    }

    public void RepairNewCar(Car car)
    {
        _view.DisplayCarArrival(car);

        List<Part> brokenParts = car.GetBrokenParts();
        List<Part> unbrokenParts = car.GetUnbrokenParts();

        unbrokenParts.Sort();
        brokenParts.Sort();

        _view.DisplayParts(unbrokenParts, brokenParts);

        _view.DisplayRepairStartOption();
        string userChoice = Console.ReadLine();

        if (userChoice == RepairCommands.StartRepair)
        {
            ReplaceBrokenParts(car);
        }
        else if (userChoice == RepairCommands.RefuseRepair)
        {
            ApplyPenalty(_model.FixedPenalty);
        }
        else
        {
            DisplayInvalidChoice();
        }
    }

    public void DisplayStartWindow()
    {
        _view.ShowStartWindow();
    }

    public void DisplayMainMenu()
    {
        _view.DisplayMainMenu();
    }

    public void DisplayBalance()
    {
        _view.DisplayBalance(_model.Balance);
    }

    public void DisplayWarehouseParts()
    {
        List<Part> parts = _model.GetAllParts();
        parts.Sort();
        _view.DisplayInventory(parts);
    }

    private void ReplaceBrokenParts(Car car)
    {
        const string RepairCommand = "1";
        const string EndRepairCommand = "2";

        _view.DisplayStartRepairing();

        bool isRepairingFinished = false;

        while (isRepairingFinished == false && car.IsFullyRepaired() == false)
        {
            _view.DisplayRepairOptions();
            string repairChoice = Console.ReadLine();

            if (repairChoice == RepairCommand)
            {
                HandleRepairChoice(car);
            }
            else if (repairChoice == EndRepairCommand)
            {
                List<Part> brokenParts = car.GetBrokenParts();
                decimal penalty = CalculatePenalty(brokenParts.Count);
                ApplyPenalty(penalty);
                isRepairingFinished = true;
            }
            else
            {
                Console.WriteLine("Неверный выбор. Попробуйте снова.");
            }
        }

        if (car.IsFullyRepaired())
        {
            _view.DisplayRepairCompleted();
        }
    }

    private void HandleRepairChoice(Car car)
    {
        List<Part> parts = car.GetParts();
        parts.Sort();

        _view.DisplayPartRepairOptions(parts);

        string partChoice = Console.ReadLine();

        if (int.TryParse(partChoice, out int partNumber) && partNumber > 0 &&
            partNumber <= parts.Count)
        {
            Part selectedPart = parts[partNumber - 1];

            bool isSuccess = TryChangePart(car, selectedPart, out bool isRepaired);

            if (isSuccess)
            {
                if (isRepaired)
                {
                    _view.DisplayRepairSuccess(selectedPart.Name, selectedPart.Price);
                }
                else
                {
                    _view.DisplayChangeSuccess(selectedPart.Name);
                }
            }
            else
            {
                _view.DisplayChangeFailure(selectedPart.Name);
            }
        }
        else
        {
            Console.WriteLine("Неверный выбор. Попробуйте снова.");
        }
    }

    private void ApplyPenalty(decimal penalty)
    {
        _model.TryTopUpBalance(penalty);
        _view.DisplayPenalty(penalty);
    }

    private void DisplayInvalidChoice()
    {
        _view.DisplayMessage("Неверный выбор. Возвращение в главное меню.");
        _view.DisplayFooter();
    }

    private bool TryChangePart(Car car, Part brokenPart, out bool isCarRepaired)
    {
        isCarRepaired = false;
        bool isPartAvailable = _model.TryGetUnbrokenPart(brokenPart.Name, brokenPart.Price, out Part unbrokenPart);

        if (isPartAvailable)
        {
            bool isChangeSuccess = car.TryChangePart(unbrokenPart, out bool isRepaired);

            if (isChangeSuccess)
            {
                if (isRepaired)
                {
                    decimal repairPrice = _model.GetRepairPrice(brokenPart);
                    decimal payment = brokenPart.Price + repairPrice;
                    _model.TryTopUpBalance(payment);
                    isCarRepaired = true;
                }

                return true;
            }

            _model.TryAddPart(brokenPart);

            return false;
        }

        return false;
    }

    private decimal CalculatePenalty(int remainingBrokenParts)
    {
        decimal perPartPenalty = 200m;
        return remainingBrokenParts * perPartPenalty;
    }
}