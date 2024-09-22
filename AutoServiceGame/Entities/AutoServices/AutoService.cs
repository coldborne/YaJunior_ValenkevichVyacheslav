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

        List<Part> brokenParts = car.GetBrokenParts();
        List<Part> unbrokenParts = car.GetUnbrokenParts();
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
                    List<Part> allParts = new List<Part>();
                    unbrokenParts = car.GetUnbrokenParts();
                    brokenParts = car.GetBrokenParts();

                    allParts.AddRange(unbrokenParts);
                    allParts.AddRange(brokenParts);

                    _view.DisplayPartRepairOptions(allParts);

                    string partChoice = Console.ReadLine();

                    if (int.TryParse(partChoice, out int partNumber) && partNumber > 0 &&
                        partNumber <= allParts.Count)
                    {
                        Part selectedPart = allParts[partNumber - 1];

                        bool isSuccess = TryPerformRepair(car, selectedPart);

                        if (isSuccess)
                        {
                            _view.DisplayRepairSuccess(selectedPart.Name, selectedPart.Price);
                        }
                        else
                        {
                            _view.DisplayRepairFailure(selectedPart.Name);
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

    public void DisplayInventory()
    {
        _view.DisplayInventory(_model.GetAllParts());
    }

    private bool TryPerformRepair(Car car, Part brokenPart)
    {
        bool isPartAvailable = _model.TryGetPart(brokenPart.Name, out Part unbrokenPart);

        if (partAvailable)
        {
            Part newPart = new Part(brokenPart.Name, brokenPart.Price, isBroken: false);

            bool repairSuccess = car.TryRepair(newPart);

            if (repairSuccess)
            {
                decimal repairPrice = _model.GetRepairPrice(brokenPart);
                decimal payment = brokenPart.Price + repairPrice;
                _model.TryTopUpBalance(payment);

                return true;
            }

            _model.TryAddPart(brokenPart, 1);
            
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