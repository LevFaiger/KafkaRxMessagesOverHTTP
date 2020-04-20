using System;
using System.Collections.Generic;
using System.Text;
using Confluent.Kafka;


namespace Reservation.Streaming.Consumer
{
    public class ReservationConsumer : IReservationConsumer
    {
        public void Listen(Action<string> message)
        {
            var config = new ConsumerConfig
            {
                BootstrapServers = "localhost:9092",
                GroupId="reservation_consumer",
                AutoOffsetReset= AutoOffsetReset.Earliest
            };
            using (var consumer = new ConsumerBuilder<Ignore, string>(config).Build())
            {
                consumer.Subscribe("timemanagement_booking");
                while (true)
                {
                    var consumed = consumer.Consume();
                    
                    var consumeResult = consumed.Message.Value; 

                    if (!string.IsNullOrEmpty(consumeResult))
                    {
                        message($"consumeResult:  {consumeResult} offset:{consumed.Offset}  Partition:{consumed.Partition} Partitiona + Offset: {consumed.TopicPartitionOffset}");
                    }
                }

                
            }
        }
    }
}
