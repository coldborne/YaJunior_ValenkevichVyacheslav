using System;
using System.Collections.Generic;
using System.Text;
using PassengerTrainConfigurator;

namespace Passenger_Train_Configurator
{
    public class TrainPlan
    {
        private Train _train;
        private List<Ticket> _tickets;

        public TrainPlan(Train train)
        {
            _train = train;
            _tickets = new List<Ticket>();
            IsCompleted = false;
        }

        public bool IsCompleted;

        public void SellTickets(List<Passenger> passengers)
        {
            int passengersCount = passengers.Count;
            int seatsWithOutPassengersCount = _train.GetFreeSeatsCount();

            if (passengersCount > seatsWithOutPassengersCount)
            {
                throw new ArgumentException(
                    $"В план передано больше пассажиров, чем есть свободных мест в позде - {_train.Number}. Передано {passengersCount}, свободных мест в поезде {seatsWithOutPassengersCount}");
            }

            List<Seat> freeSeats = _train.GetFreeSeats();

            foreach (Passenger passenger in passengers)
            {
                int seatPosition = RandomProvider.Next(freeSeats.Count - 1);
                Seat seat = freeSeats[seatPosition];

                Ticket ticket = new Ticket(seat);
                ticket.Book(passenger);

                _tickets.Add(ticket);
                freeSeats.Remove(seat);
            }
        }

        public string GetSoldTickectsInfo()
        {
            StringBuilder stringBuilder = new StringBuilder();

            if (_tickets.Count != 0)
            {
                for (int i = 0; i < _tickets.Count; i++)
                {
                    Ticket ticket = _tickets[i];

                    if (ticket.IsBooked)
                    {
                        stringBuilder.AppendLine($"Билет {i + 1}: {ticket}");
                    }
                }
            }
            else
            {
                stringBuilder.AppendLine($"\t\tБилетов на направление {_train.Direction} нет");
            }

            return stringBuilder.ToString();
        }

        public void Depart()
        {
            IsCompleted = true;
        }

        public override string ToString()
        {
            string trainPlanInfo = string.Empty;

            string trainInfo = $"{_train}\n";
            string soldTicketsCountInfo = $"Продано билетов - {_tickets.Count}, ";
            string completingInfo = $"поезд уехал - {IsCompleted}";

            trainPlanInfo += trainInfo;
            trainPlanInfo += soldTicketsCountInfo;
            trainPlanInfo += completingInfo;

            return trainPlanInfo;
        }
    }
}