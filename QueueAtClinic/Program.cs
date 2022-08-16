using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueAtClinic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int appointmentMinutesPerPerson = 10;
            int minutesInHour = 60;

            Console.WriteLine("Введите количество существ, которых Вы терпеть не можете, в очереди");
            bool isIntValue = int.TryParse(Console.ReadLine(), out int peopleInQueue);

            if (!isIntValue)
            {
                Console.WriteLine("Можно вводить только числа");
            }

            int minutesWaitingInQueue = peopleInQueue * appointmentMinutesPerPerson;
            int hoursWaitingInQueue = minutesWaitingInQueue / minutesInHour;

            Console.WriteLine("Ваше время ожидания в очереди - " + hoursWaitingInQueue.ToString() + " часов " + minutesWaitingInQueue.ToString() + " минут");
        }
    }
}
