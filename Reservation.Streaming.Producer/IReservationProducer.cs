using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Reservation.Streaming.Producer
{
    public interface IReservationProducer
    {
        Task Produce(string message);
    }
}
