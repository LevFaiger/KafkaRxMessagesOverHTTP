using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationWeb.Models
{
    public class ReservationModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }


    }
}
