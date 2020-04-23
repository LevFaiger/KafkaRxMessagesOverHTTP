using System;
using System.Collections.Generic;

namespace Reservation.Streaming.Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            var reservationConsumer = new ReservationConsumer();
            var actions = GetHandlers();
            reservationConsumer.Listen(actions);
        }

        private static Dictionary<string, Action<string>> GetHandlers()
        {
            Dictionary<string, Action<string>> methodsToRun = new Dictionary<string, Action<string>>();
            Action<string> a1, a2, a3;
            a1 = PrintA1;
            a2 = PrintA2;
            a3 = PrintA3;
            static void PrintA1(string p)
            {
                Console.WriteLine($"function PrintA1 {p}");
            }

            static void PrintA2(string p)
            {
                Console.WriteLine($"function PrintA2 {p}");
            }

            static void PrintA3(string p)
            {
                Console.WriteLine($"function PrintA1 {p}");
            }

            methodsToRun.Add("1", a1);
            methodsToRun.Add("2", a2);
            methodsToRun.Add("3", a3);

            return methodsToRun;
        }
    }
}
