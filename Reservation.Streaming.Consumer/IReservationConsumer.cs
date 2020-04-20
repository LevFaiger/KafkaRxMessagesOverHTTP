using System;
using System.Collections.Generic;
using System.Text;

namespace Reservation.Streaming.Consumer
{
    public interface IReservationConsumer
    {
        void Listen(Action<string> message);
    }
}
