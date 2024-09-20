using AutoServiceGame.Entities.Cars;
using AutoServiceGame.Entities.Parts;

namespace AutoServiceGame.Entities.AutoServices;

public class AutoServiceView
{
    public void ShowStartWindow()
    {
        Console.Clear();
        Console.WriteLine("********************************************");
        Console.WriteLine("*                                          *");
        Console.WriteLine("*      Добро пожаловать в Автосервис!      *");
        Console.WriteLine("*                                          *");
        Console.WriteLine("********************************************");
        Console.WriteLine("\nНажмите любую клавишу, чтобы начать...");
        Console.ReadKey();
    }

    public void DisplayMainMenu()
    {
        Console.Clear();
        Console.WriteLine("============================================");
        Console.WriteLine("              Меню Автосервиса              ");
        Console.WriteLine("============================================");
        Console.WriteLine("1. Начать ремонт машины");
        Console.WriteLine("2. Посмотреть баланс");
        Console.WriteLine("3. Посмотреть склад деталей");
        Console.WriteLine("0. Выход");
        Console.WriteLine("============================================\n");
        Console.Write("Выберите действие: ");
    }

    public void DisplayInventory(Dictionary<string, int> parts)
    {
        Console.Clear();
        Console.WriteLine("============================================");
        Console.WriteLine("                 Склад деталей              ");
        Console.WriteLine("============================================");

        foreach (KeyValuePair<string, int> part in parts)
        {
            Console.WriteLine($"{part.Key}: {part.Value} шт.");
        }

        Console.WriteLine("============================================\n");
        Console.WriteLine("Нажмите любую клавишу, чтобы вернуться в меню.");
        Console.ReadKey();
    }

    public void DisplayBalance(decimal balance)
    {
        Console.Clear();
        Console.WriteLine("============================================");
        Console.WriteLine("                  Баланс                    ");
        Console.WriteLine("============================================");
        Console.WriteLine($"Баланс автосервиса: {balance:C}");
        Console.WriteLine("============================================\n");
        Console.WriteLine("Нажмите любую клавишу, чтобы вернуться в меню.");
        Console.ReadKey();
    }

    public void DisplayCarArrival(Car car)
    {
        Console.Clear();
        Console.WriteLine("============================================");
        Console.WriteLine("              Новая машина в ремонте        ");
        Console.WriteLine("============================================");
        Console.WriteLine($"Модель: {car.Model}");
        Console.WriteLine("============================================\n");
        Console.WriteLine("Нажмите любую клавишу, чтобы продолжить...");
        Console.ReadKey();
    }

    public void DisplayBrokenParts(List<Part> brokenParts)
    {
        Console.Clear();
        Console.WriteLine("============================================");
        Console.WriteLine("            Поломанные детали машины        ");
        Console.WriteLine("============================================");

        foreach (Part part in brokenParts)
        {
            Console.WriteLine($"- {part.Name} (Цена: {part.Price:Currency})");
        }

        Console.WriteLine("============================================\n");
    }

    public void DisplayRepairOptions()
    {
        Console.WriteLine("Выберите действие:");
        Console.WriteLine("1. Починить деталь");
        Console.WriteLine("2. Отказаться от ремонта");
        Console.Write("Ваш выбор: ");
    }

    public void DisplayPartRepairOptions(List<Part> brokenParts)
    {
        Console.WriteLine("Выберите деталь для починки:");

        for (int i = 0; i < brokenParts.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {brokenParts[i].Name}");
        }

        Console.WriteLine("0. Назад");
        Console.Write("Ваш выбор: ");
    }

    public void DisplayRepairSuccess(string partName, decimal payment)
    {
        Console.WriteLine($"Деталь {partName} успешно починена. Получено {payment:C}.");
        Console.WriteLine("Нажмите любую клавишу, чтобы продолжить...");
        Console.ReadKey();
    }

    public void DisplayRepairFailure(string partName)
    {
        Console.WriteLine($"На складе нет детали {partName} для замены.");
        Console.WriteLine("Нажмите любую клавишу, чтобы продолжить...");
        Console.ReadKey();
    }

    public void DisplayPenalty(decimal penalty)
    {
        Console.WriteLine($"Вы отказались от ремонта. Штраф составил {penalty:Currency}.");
        Console.WriteLine("Нажмите любую клавишу, чтобы вернуться в меню.");
        Console.ReadKey();
    }

    public void DisplayRepairCompleted()
    {
        Console.WriteLine("Ремонт завершен! Все детали исправны.");
        Console.WriteLine("Нажмите любую клавишу, чтобы вернуться в меню.");
        Console.ReadKey();
    }
}