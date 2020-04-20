using System;
using System.Collections.Generic;
using System.Text;

namespace Reservation.Streaming.Producer
{
    public interface IReservationProducer
    {
        void Produce(string message);
    }
}
