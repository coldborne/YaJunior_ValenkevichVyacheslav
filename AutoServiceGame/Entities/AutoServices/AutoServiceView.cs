using AutoServiceGame.Entities.Cars;
using AutoServiceGame.Entities.Parts;

namespace AutoServiceGame.Entities.AutoServices;

public class AutoServiceView
{
    private const int BorderWidth = 44;

    private void DisplayHeader(string title)
    {
        Console.Clear();
        string border = new string('=', BorderWidth);
        Console.WriteLine(border);

        if (title.Length >= BorderWidth)
        {
            Console.WriteLine(title);
        }
        else
        {
            int padding = (BorderWidth - title.Length) / 2;
            string paddedTitle = title.PadLeft(padding + title.Length);
            Console.WriteLine(paddedTitle);
        }

        Console.WriteLine(border);
    }

    public void DisplayFooter()
    {
        Console.WriteLine("============================================\n");
        Console.WriteLine("Нажмите любую клавишу, чтобы продолжить...");
        Console.ReadKey();
    }

    public void DisplayMessage(string message)
    {
        Console.WriteLine($"{message}");
    }

    public void ShowStartWindow()
    {
        DisplayHeader("Добро пожаловать в Автосервис!");
        Console.WriteLine("\nНажмите любую клавишу, чтобы начать...");
        Console.ReadKey();
    }

    public void DisplayMainMenu()
    {
        DisplayHeader("Меню Автосервиса");
        Console.WriteLine("1. Начать ремонт машины");
        Console.WriteLine("2. Посмотреть баланс");
        Console.WriteLine("3. Посмотреть склад деталей");
        Console.WriteLine("0. Выход\n");
        Console.Write("Выберите действие: ");
    }

    public void DisplayInventory(List<Part> parts)
    {
        DisplayHeader("Склад деталей");

        foreach (Part part in parts)
        {
            Console.WriteLine($"- {part.Name}, Цена: {part.Price:C}, Сломана: {part.IsBroken}");
        }

        DisplayFooter();
    }

    public void DisplayBalance(decimal balance)
    {
        DisplayHeader("Баланс");
        Console.WriteLine($"Баланс автосервиса: {balance:C}");
        DisplayFooter();
    }

    public void DisplayCarArrival(Car car)
    {
        DisplayHeader("Новая машина в ремонте");
        DisplayMessage($"Модель: {car.Model}");
        DisplayFooter();
    }

    public void DisplayParts(List<Part> unbrokenParts, List<Part> brokenParts)
    {
        DisplayHeader("Детали машины");

        Console.WriteLine("Целые детали машины:");

        foreach (Part part in unbrokenParts)
        {
            Console.WriteLine($"- {part.Name} (Цена: {part.Price:C})");
        }

        Console.WriteLine();
        Console.WriteLine("Поломанные детали машины:");

        foreach (Part part in brokenParts)
        {
            Console.WriteLine($"- {part.Name} (Цена: {part.Price:C})");
        }

        DisplayFooter();
    }

    public void DisplayRepairStartOption()
    {
        DisplayHeader("Вы хотите начать ремонт?");
        Console.WriteLine($"{RepairCommands.StartRepair}. Да");
        Console.WriteLine($"{RepairCommands.RefuseRepair}. Нет");
        Console.Write("Ваш выбор: ");
    }

    public void DisplayPartRepairOptions(List<Part> parts)
    {
        DisplayHeader("Выберите деталь для починки:");

        for (int i = 0; i < parts.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {parts[i].Name}");
        }

        Console.WriteLine("0. Назад");
        Console.Write("Ваш выбор: ");
    }

    public void DisplayRepairOptions()
    {
        DisplayHeader("Выберите действие:");
        Console.WriteLine("1. Починить деталь");
        Console.WriteLine("2. Отказаться от ремонта");
        Console.Write("Ваш выбор: ");
    }

    public void DisplayChangeSuccess(string partName)
    {
        DisplayHeader($"Деталь {partName} успешно заменена");
        DisplayMessage("За замену целой детали ничего не получено.");
        DisplayFooter();
    }

    public void DisplayChangeFailure(string partName)
    {
        DisplayHeader($"Не получилось заменить: {partName}.");
        DisplayFooter();
    }

    public void DisplayRepairSuccess(string partName, decimal payment)
    {
        DisplayHeader($"Деталь {partName} успешно починена.");
        DisplayMessage($"Получено {payment:C}.");
        DisplayFooter();
    }

    public void DisplayPenalty(decimal penalty)
    {
        DisplayHeader("Вы отказались от ремонта");
        DisplayMessage($"Штраф составил {penalty:C}.");
        DisplayFooter();
    }

    public void DisplayStartRepairing()
    {
        DisplayHeader("Вы согласились на ремонт.");
        DisplayFooter();
    }

    public void DisplayRepairCompleted()
    {
        DisplayHeader("Ремонт завершен!");
        DisplayMessage("Все детали исправны.");
        DisplayFooter();
    }
}