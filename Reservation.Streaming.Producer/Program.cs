using System;

namespace Reservation.Streaming.Producer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your message. Enter q for quitting");
            var message = default(string);
            while ((message = Console.ReadLine()) != "q")
            {
                var producer = new ReservationProducer();
                producer.Produce(message);
            }
        }
    }
}
