using System;
using System.Collections.Generic;
using PassengerTrainConfigurator;

namespace Passenger_Train_Configurator
{
    public class RailwayStation
    {
        private Stack<TrainPlan> _trainPlans;

        private TrainCreator _trainCreator;
        private PassengerCreator _passengerCreator;

        public RailwayStation()
        {
            _trainPlans = new Stack<TrainPlan>();
            _trainCreator = new TrainCreator();
            _passengerCreator = new PassengerCreator();
        }

        public void Work()
        {
            Console.WriteLine("Добро пожаловать в наш конфигуратор пассажирских поездов!");
            Console.WriteLine("Мы поможем вам сформировать и отправить поезд по нужному направлению");

            Console.WriteLine("Сколько поездов вы хотите сформировать?");
            bool isTrainAmountValid = false;
            int trainAmount = 0;

            while (isTrainAmountValid == false)
            {
                string userInput = Console.ReadLine();

                if (int.TryParse(userInput, out trainAmount))
                {
                    if (trainAmount > 0)
                    {
                        isTrainAmountValid = true;
                    }
                    else
                    {
                        Console.WriteLine("Количество поездов должно быть положительным");
                    }
                }
                else
                {
                    Console.WriteLine("Количество поездов должно быть целым числом");
                }
            }

            for (int i = 1; i <= trainAmount; i++)
            {
                ShowColoredText($"Поезд - {i}: ", ConsoleColor.Cyan);
                SendTrain();
                Console.WriteLine("Чтобы продолжить, нажмите любую клавишу клавиатуры");
                Console.ReadKey();
                Console.Clear();
            }

            Console.WriteLine("Вы отправили все поезда");
        }

        private void SendTrain()
        {
            Console.WriteLine("Шаг первый:");
            Console.WriteLine("Сформировать направление");
            Direction direction = FormDirection();

            Console.WriteLine("Шаг второй:");
            Console.WriteLine("Сформировать поезд, движущийся по указанному направлению");
            Train train = FormTrain(direction);

            Console.WriteLine("Шаг третий:");
            Console.WriteLine("Составить план поездки, учитывая поезд и план поездки");
            TrainPlan trainPlan = FormTrainPlan(train);

            Console.WriteLine("Шаг четвертый:");
            Console.WriteLine("Продажа билетов на поезд");
            SellTickets(trainPlan, train);

            Console.WriteLine("Шаг пятый:");
            Console.WriteLine("Отправить поезд в путь");
            DepartTrain(trainPlan);
            _trainPlans.Push(trainPlan);

            Console.WriteLine("Спрашиваем \"отправлен ли поезд?\"");
            Console.WriteLine($"Ответ - {trainPlan.IsCompleted}");

            Console.WriteLine();
        }

        private Direction FormDirection()
        {
            Console.Write("Введите город отправления - ");
            string departureCity = GetCity();
            Console.Write("Введите город прибытия - ");
            string arrivalCity = GetCity();

            Direction direction = new Direction(departureCity, arrivalCity);

            ShowColoredText("Направление сформировано: ", ConsoleColor.Yellow);
            ShowColoredText(direction.ToString(), ConsoleColor.Green);

            return direction;
        }

        private Train FormTrain(Direction direction)
        {
            string trainNumber = _trainCreator.GenerateTrainNumber();
            int minimumWagonAmount = 1;
            int maximumWagonAmount = 15;

            int wagonAmount = RandomProvider.Next(minimumWagonAmount, maximumWagonAmount + 1);

            Train train = _trainCreator.Create(trainNumber, direction, wagonAmount);

            ShowColoredText("Поезд сформирован: ", ConsoleColor.Yellow);
            ShowColoredText(train.ToString(), ConsoleColor.White);

            return train;
        }

        private TrainPlan FormTrainPlan(Train train)
        {
            TrainPlan trainPlan = new TrainPlan(train);
            ShowColoredText("План сформирован: ", ConsoleColor.Yellow);
            ShowColoredText(trainPlan.ToString(), ConsoleColor.Magenta);

            return trainPlan;
        }

        private void SellTickets(TrainPlan trainPlan, Train train)
        {
            int minPassengerCount = 0;
            int maxPassengerCount = train.GetCapacity();

            int passengerCount = RandomProvider.Next(minPassengerCount, maxPassengerCount);

            List<Passenger> passengers = new List<Passenger>();

            for (int j = 1; j <= passengerCount; j++)
            {
                Passenger passenger = _passengerCreator.CreatePassenger();
                passengers.Add(passenger);
            }

            trainPlan.SellTickets(passengers);
            string soldTickectsInfo = trainPlan.GetSoldTickectsInfo();

            ShowColoredText("Проданные билеты: ", ConsoleColor.Yellow);
            ShowColoredText(soldTickectsInfo, ConsoleColor.DarkCyan);
        }

        private void DepartTrain(TrainPlan trainPlan)
        {
            trainPlan.Depart();
        }

        private string GetCity()
        {
            bool isValid = false;
            string city = String.Empty;

            while (isValid == false)
            {
                city = Console.ReadLine().Trim();

                if (city != String.Empty && city != null)
                {
                    isValid = true;
                }
                else
                {
                    ShowColoredText("Некорректный ввод", ConsoleColor.Red);
                }
            }

            return city;
        }

        private void ShowColoredText(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }
    }
}