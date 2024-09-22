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
        const string StartRepairCommand = "1";
        const string RefusalRepairCommand = "2";

        _view.DisplayCarArrival(car);

        List<Part> parts = car.GetParts();
        List<Part> brokenParts = new List<Part>();
        List<Part> unbrokenParts = new List<Part>();

        foreach (Part part in parts)
        {
            if (part.IsBroken)
            {
                brokenParts.Add(part);
            }
            else
            {
                unbrokenParts.Add(part);
            }
        }

        unbrokenParts.Sort();
        brokenParts.Sort();

        _view.DisplayParts(unbrokenParts, brokenParts);

        _view.DisplayRepairStartOption();
        string userChoice = Console.ReadLine();

        if (userChoice == StartRepairCommand)
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
                    parts = car.GetParts();
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
                else if (repairChoice == EndRepairCommand)
                {
                    decimal penalty = CalculatePenalty(brokenParts.Count);
                    _model.TryTopUpBalance(penalty);
                    _view.DisplayPenalty(penalty);
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
        else if (userChoice == RefusalRepairCommand)
        {
            decimal penalty = _model.FixedPenalty;
            _model.TryTopUpBalance(penalty);
            _view.DisplayPenalty(penalty);
        }
        else
        {
            Console.WriteLine("Неверный выбор. Возвращение в главное меню.");
            Console.WriteLine("Нажмите любую клавишу, чтобы продолжить...");
            Console.ReadKey();
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