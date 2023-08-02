
using FlightControl.Models.Models;

namespace PlaneControl.Logic.Logic
{
    public class Terminal_5 : Terminal
    {
        public static Terminal_5 Init { get; set; }
        public override bool NextTerminal(Flight currentFlight)
        {
            var ter6 = Terminal_6.Init;
            var ter7 = Terminal_7.Init;
            if (ter6.IsFree)
            {
                currentFlight.Terminal!.Loggers.First(t => t.FlightNumber == currentFlight.Number).Out = DateTime.Now;
                currentFlight.Terminal!.IsFree = true;
                ter6.IsFree = false;
                currentFlight.Terminal = ter6;
                currentFlight.Terminal!.Loggers.Add(new Logger { Enter = DateTime.Now, FlightNumber = currentFlight.Number, Terminal = currentFlight.Terminal, Out = null });
                return true;

            }
            else if (ter7.IsFree)
            {
                currentFlight.Terminal!.Loggers.First(t => t.FlightNumber == currentFlight.Number).Out = DateTime.Now;
                currentFlight.Terminal!.IsFree = true;
                ter7.IsFree = false;
                currentFlight.Terminal = ter7;
                currentFlight.Terminal!.Loggers.Add(new Logger { Enter = DateTime.Now, FlightNumber = currentFlight.Number, Terminal = currentFlight.Terminal, Out = null });
                return true;

            }
            return false;
        }
    }
}
