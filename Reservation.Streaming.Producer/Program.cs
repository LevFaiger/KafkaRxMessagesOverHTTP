using System;

namespace Reservation.Streaming.Producer
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            Console.WriteLine("Enter your message. Enter q for quitting");
            var message = default(string);
            while ((message = Console.ReadLine()) != "q")
            {
                var producer = new ReservationProducer();
                await producer.Produce(message);
            }
        }
    }
}
