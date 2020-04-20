using Confluent.Kafka;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reservation.Streaming.Producer
{
    public class ReservationProducer : IReservationProducer
    {
        public void Produce(string message)
        {
            var config = new ProducerConfig
            {
                     BootstrapServers= "localhost:9092"

            };


            using (var producer = new ProducerBuilder<Null, string>(config).Build())
            {
                var t = producer.ProduceAsync("timemanagement_booking", new Message<Null, string> { Value = message });
                t.ContinueWith(task => {
                    if (task.IsFaulted)
                    {
                        Console.WriteLine($"Task is faulted: {message}");
                    }
                    else
                    {
                     var pushedMessage = task.Result;
                     Console.WriteLine($"Wrote to offset in partian: {pushedMessage.Offset}");
                     Console.WriteLine($"pushedMessage.Partition.Value: {pushedMessage.Partition.Value}");
                     Console.WriteLine($"pushedMessage.Partition.ToString(): {pushedMessage.Partition.ToString()}");
                     Console.WriteLine($"Topic: {pushedMessage.Topic.ToString()}");
                    }
                });
            }
        }
    }
}
