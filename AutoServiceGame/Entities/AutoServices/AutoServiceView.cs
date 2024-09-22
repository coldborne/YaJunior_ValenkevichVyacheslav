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

    public void DisplayInventory(List<Part> parts)
    {
        Console.Clear();
        Console.WriteLine("============================================");
        Console.WriteLine("                 Склад деталей              ");
        Console.WriteLine("============================================");

        foreach (Part part in parts)
        {
            Console.WriteLine($"- {part.Name}, Цена: {part.Price:C}, Сломана: {part.IsBroken}");
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
        Console.WriteLine("           Новая машина в ремонте           ");
        Console.WriteLine("============================================");
        Console.WriteLine($"Модель: {car.Model}");
        Console.WriteLine("============================================\n");
        Console.WriteLine("Нажмите любую клавишу, чтобы продолжить...");
        Console.ReadKey();
    }

    public void DisplayParts(List<Part> unbrokenParts, List<Part> brokenParts)
    {
        Console.Clear();
        Console.WriteLine("============================================");
        Console.WriteLine("            Целые детали машины             ");
        Console.WriteLine("============================================");

        foreach (Part part in unbrokenParts)
        {
            Console.WriteLine($"- {part.Name} (Цена: {part.Price:C})");
        }

        Console.WriteLine("============================================\n");
        Console.WriteLine();

        Console.WriteLine("============================================");
        Console.WriteLine("            Поломанные детали машины        ");
        Console.WriteLine("============================================");

        foreach (Part part in brokenParts)
        {
            Console.WriteLine($"- {part.Name} (Цена: {part.Price:C})");
        }

        Console.WriteLine("============================================\n");
    }

    public void DisplayRepairStartOption()
    {
        Console.WriteLine("Вы хотите начать ремонт?");
        Console.WriteLine("1. Да");
        Console.WriteLine("2. Нет");
        Console.Write("Ваш выбор: ");
    }

    public void DisplayPartRepairOptions(List<Part> parts)
    {
        Console.WriteLine("Выберите деталь для починки:");

        for (int i = 0; i < parts.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {parts[i].Name}");
        }

        Console.WriteLine("0. Назад");
        Console.Write("Ваш выбор: ");
    }

    public void DisplayRepairOptions()
    {
        Console.WriteLine("Выберите действие:");
        Console.WriteLine("1. Починить деталь");
        Console.WriteLine("2. Отказаться от ремонта");
        Console.Write("Ваш выбор: ");
    }

    public void DisplayChangeSuccess(string partName)
    {
        Console.WriteLine($"Деталь {partName} успешно заменена. За замену целой детали ничего не получено.");
        Console.WriteLine("Нажмите любую клавишу, чтобы продолжить...");
        Console.ReadKey();
    }

    public void DisplayChangeFailure(string partName)
    {
        Console.WriteLine($"Не получилось заменить: {partName}.");
        Console.WriteLine("Нажмите любую клавишу, чтобы продолжить...");
        Console.ReadKey();
    }

    public void DisplayRepairSuccess(string partName, decimal payment)
    {
        Console.WriteLine($"Деталь {partName} успешно починена. Получено {payment:C}.");
        Console.WriteLine("Нажмите любую клавишу, чтобы продолжить...");
        Console.ReadKey();
    }

    public void DisplayPenalty(decimal penalty)
    {
        Console.WriteLine($"Вы отказались от ремонта. Штраф составил {penalty:C}.");
        Console.WriteLine("Нажмите любую клавишу, чтобы вернуться в меню.");
        Console.ReadKey();
    }

    public void DisplayStartRepairing()
    {
        Console.WriteLine("Вы согласились на ремонт.");
    }

    public void DisplayRepairCompleted()
    {
        Console.WriteLine("Ремонт завершен! Все детали исправны.");
        Console.WriteLine("Нажмите любую клавишу, чтобы вернуться в меню.");
        Console.ReadKey();
    }
}