
using FlightControl.Models.Models;
namespace PlaneControl.Logic.Logic
{

    public class Terminal_4 : Terminal
    {
        public static Terminal_4 Init { get; set; }
        public override bool NextTerminal(Flight currentFlight)
        {
            if (currentFlight.IsDeparture)
            {
                currentFlight.Terminal!.Loggers.Where(t => t.Terminal!.Number == 4 && t.FlightNumber == currentFlight.Number).ToList()[1].Out = DateTime.Now; ;
                currentFlight.Terminal.IsFree = true;
                currentFlight.Terminal = null;
                currentFlight.TerminalId = null;
                return true;
            }
            else
            {
                var ter = Terminal_5.Init;
                if (ter.IsFree)
                {
                    currentFlight.Terminal!.Loggers.First(t => t.FlightNumber == currentFlight.Number).Out = DateTime.Now;
                    currentFlight.Terminal!.IsFree = true;
                    ter.IsFree = false;
                    currentFlight.Terminal = ter;
                    currentFlight.Terminal!.Loggers.Add(new Logger { Enter = DateTime.Now, FlightNumber = currentFlight.Number, Terminal = currentFlight.Terminal, Out = null });
                    return true;
                }
            }
            return false;
        }
    }
}
