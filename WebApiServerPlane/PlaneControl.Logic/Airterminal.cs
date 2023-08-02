using FlightControl.Models.Models;
using PlaneControl.Logic.Contexts;
using PlaneControl.Logic.Logic;

namespace PlaneControl.Logic
{
    public class Airterminal
    {
        private readonly DataContext data = new();
        private readonly object identity = new();
        private readonly object identity2 = new();


        public void TeminalsLogic(Flight flight)
        {
            lock (identity)
            {
                flight = data.Flights.First(i => i.Id == flight.Id);
                SetTerminals();
                if (flight != null)
                    if (flight.Terminal == null && flight.IsDeparture == false)
                        FromAirToTerminal1(flight);
            }
        }

        private void SetTerminals()
        {
            Terminal_2.Init = (Terminal_2)data.Terminals.First(i => i.Number == 2);
            Terminal_3.Init = (Terminal_3)data.Terminals.First(i => i.Number == 3);
            Terminal_4.Init = (Terminal_4)data.Terminals.First(i => i.Number == 4);
            Terminal_5.Init = (Terminal_5)data.Terminals.First(i => i.Number == 5);
            Terminal_6.Init = (Terminal_6)data.Terminals.First(i => i.Number == 6);
            Terminal_7.Init = (Terminal_7)data.Terminals.First(i => i.Number == 7);
            Terminal_8.Init = (Terminal_8)data.Terminals.First(i => i.Number == 8);
        }

        private void FromAirToTerminal1(Flight flight)
        {
            flight.Terminal = data.Terminals.First(i => i.Number == 1);
            flight.FlyTimer.Interval = flight.Terminal.WaitTime * 1000;
            flight.FlyTimer.Elapsed += (s, e) => GoNextTerminal(flight);
            flight.FlyTimer.Start();
            data.Loggers.Add(new Logger { Enter = DateTime.Now, FlightNumber = flight.Number, Terminal = data.Terminals.First(i => i.Number == 1), Out = null });
            data.SaveChangesAsync();
        }

        private void GoNextTerminal(Flight flight)
        {
            bool successToMove = false;
            lock (identity2)
            {
                if (flight.Terminal != null)
                    successToMove = flight.NextTerminal();
                if (flight.Terminal != null && successToMove)
                    flight.FlyTimer.Interval = flight.Terminal.WaitTime * 1000;
                else if (flight.IsDeparture && flight.Terminal == null)
                {
                    Terminal_4.Init.IsFree = true;
                    flight.FlyTimer.Stop();
                }
                data.SaveChanges();
            }
        }

    }
}
