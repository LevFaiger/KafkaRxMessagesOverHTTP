using System;

namespace Reservation.Streaming.Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            var reservationConsumer = new ReservationConsumer();
            reservationConsumer.Listen(Console.WriteLine);
        }
    }
}
