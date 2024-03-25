using System;

namespace PassengerTrainConfigurator
{
    public class Ticket
    {
        private readonly Guid _id;
        private Seat _seat;
        private Passenger _passenger;

        public Ticket(Seat seat)
        {
            _id = Guid.NewGuid();

            _seat = seat ??
                    throw new ArgumentNullException($"В билет - {_id} попытались поместить пустое сидение");
        }

        public void Book(Passenger passenger)
        {
            _passenger = passenger ??
                         throw new ArgumentNullException($"Билет - {_id} попытались забронировать пустым пассажиром");
            _seat.Book();
        }

        public void Release()
        {
            _passenger = null;
            _seat.Release();
        }

        public override string ToString()
        {
            string ticketInfo = $"Билет - {_id}, ";

            string seatInfo = $"сидение - \"{_seat}\", ";
            string passengerInfo = _passenger != null ? $"куплен пассажиром: {_passenger}." : "не куплен.";

            ticketInfo += seatInfo;
            ticketInfo += passengerInfo;

            return ticketInfo;
        }
    }
}