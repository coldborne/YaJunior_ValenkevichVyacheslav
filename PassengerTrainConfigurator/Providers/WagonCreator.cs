using System;
using System.Collections.Generic;
using PassengerTrainConfigurator;

namespace Passenger_Train_Configurator.Providers
{
    public class WagonCreator
    {
        private static int s_availableSeatsAmountInPerWagon = 10;

        private const char BasicSeatSymbol = 'B';
        private const char FirstSeatSymbol = 'F';
        private const char ComfortSeatSymbol = 'C';

        private const double BasicSeatsPercentage = 0.5;
        private const double FirstSeatsPercentage = 0.2;
        private const double ComfortSeatsPercentage = 0.3;

        public Wagon Create(int number, int seatsAmount)
        {
            if (seatsAmount % s_availableSeatsAmountInPerWagon != 0)
            {
                throw new ArgumentException(
                    $"Количество сидений должно быть кратным {s_availableSeatsAmountInPerWagon}");
            }

            List<Seat> seats = CreateSeats(seatsAmount);

            return new Wagon(number, seats);
        }

        private List<Seat> CreateSeats(int seatsAmount)
        {
            List<Seat> seats = new List<Seat>();
            int lastSeatNumber = 1;

            int basicSeatsAmount = (int)(seatsAmount * BasicSeatsPercentage);
            int firstSeatsAmount = (int)(seatsAmount * FirstSeatsPercentage);
            int comfortSeatsAmount = (int)(seatsAmount * ComfortSeatsPercentage);

            lastSeatNumber = AddSeatsOfType(seats, SeatType.Basic, basicSeatsAmount, BasicSeatSymbol, lastSeatNumber);
            lastSeatNumber = AddSeatsOfType(seats, SeatType.First, firstSeatsAmount, FirstSeatSymbol, lastSeatNumber);

            lastSeatNumber = AddSeatsOfType(seats,
                SeatType.Comfort,
                comfortSeatsAmount,
                ComfortSeatSymbol,
                lastSeatNumber);

            return seats;
        }

        private int AddSeatsOfType(List<Seat> seats, SeatType seatType, int seatsAmount, char seatSymbol,
            int lastSeatNumber)
        {
            for (int i = 0; i < seatsAmount; i++)
            {
                seats.Add(new Seat(seatType, $"{lastSeatNumber++}{seatSymbol}"));
            }

            return lastSeatNumber;
        }
    }
}