using System;
using System.Collections.Generic;
using System.Reactive.Subjects;
using System.Text;
using Confluent.Kafka;


namespace Reservation.Streaming.Consumer
{
    public class ReservationConsumer : IReservationConsumer
    {
        public void Listen(Dictionary<string, Action<string>> messages)
        {
            var subject = new Subject<string>();
            foreach(var item in messages)
            {
                subject.Subscribe(item.Value);
            }


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
                        subject.OnNext(consumeResult);
                       // subject.Dispose();
                        //message($"consumeResult:  {consumeResult} offset:{consumed.Offset}  Partition:{consumed.Partition} Partitiona + Offset: {consumed.TopicPartitionOffset}");
                    }
                }

                
            }
        }
    }
}
