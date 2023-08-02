﻿
using FlightControl.Models.Models;

namespace PlaneControl.Logic.Logic
{
    public class Terminal_2 : Terminal
    {
        public static Terminal_2 Init { get; set; } 

        public override bool NextTerminal(Flight currentFlight)
        {
            var ter = Terminal_3.Init;
            if (ter.IsFree)
            {
                currentFlight.Terminal!.Loggers.First(t => t.FlightNumber == currentFlight.Number).Out = DateTime.Now;
                currentFlight.Terminal!.IsFree = true;
                ter.IsFree = false;
                currentFlight.Terminal = ter;
                currentFlight.Terminal!.Loggers.Add(new Logger { Enter = DateTime.Now, FlightNumber = currentFlight.Number, Terminal = currentFlight.Terminal, Out = null });
                return true;
            }
            return false;

        }

    }
}
