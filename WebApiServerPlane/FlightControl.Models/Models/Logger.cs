using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightControl.Models.Models;
    public partial class Logger
{
    [Key]
    public int Id { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime Enter { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? Out { get; set; }

    [Column("Terminal_Id")]
    public int? TerminalId { get; set; }

    public int FlightNumber { get; set; }

    [ForeignKey("TerminalId")]
    [InverseProperty("Loggers")]
    public virtual Terminal? Terminal { get; set; }
}
