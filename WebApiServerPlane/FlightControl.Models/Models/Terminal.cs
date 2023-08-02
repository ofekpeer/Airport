using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightControl.Models.Models;
    public abstract partial class Terminal
{
    [Key]
    public int Id { get; set; }

    public bool IsFree { get; set; }
    public int Number { get; set; }
    public int WaitTime { get; set; }

    [InverseProperty("Terminal")]
    public virtual ICollection<Flight> Flights { get; set; } = new List<Flight>();

    [InverseProperty("Terminal")]
    public virtual ICollection<Logger> Loggers { get; } = new List<Logger>();
    public abstract bool NextTerminal(Flight currentFlight);
}
