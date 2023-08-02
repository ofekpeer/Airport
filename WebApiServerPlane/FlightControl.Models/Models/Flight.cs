using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightControl.Models.Models;
    public partial class Flight
{
    public int Id { get; set; }

    public bool IsDeparture { get; set; }

    [Column("Terminal_Id")]
    public int? TerminalId { get; set; }

    public int Number { get; set; }

    [ForeignKey("TerminalId")]
    [InverseProperty("Flights")]
    public virtual Terminal? Terminal { get; set; }

    public bool NextTerminal()
    {
       return Terminal.NextTerminal(this);
    }

    [NotMapped]
    public System.Timers.Timer FlyTimer = new System.Timers.Timer();
}
