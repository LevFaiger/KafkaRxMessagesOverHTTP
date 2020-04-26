using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ReservationWeb
{
    public class ReservationMessageRelay
    {
        public ReservationMessageRelay(IHubContext<ReservationHub> hubContext)
        {
            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    hubContext.Clients.All.SendCoreAsync("reservationticks", new object[] { DateTime.Now.Ticks }); 
                    Thread.Sleep(1000);
                }
            });
        }
    }
}
