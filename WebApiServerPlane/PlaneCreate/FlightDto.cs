using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightControl.Simulator
{
    internal class FlightDto
    {
        public int Number { get; set; }
        static int number;
        public FlightDto() => Number = ++number;
    }
}
