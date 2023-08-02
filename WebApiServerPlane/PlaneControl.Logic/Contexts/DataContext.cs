
using FlightControl.Models.Models;
using Microsoft.EntityFrameworkCore;
using PlaneControl.Logic.Logic;

namespace PlaneControl.Logic.Contexts;
public partial class DataContext : DbContext
{
    public DataContext()
    {

    }
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }
    public virtual DbSet<Flight> Flights { get; set; }

    public virtual DbSet<Logger> Loggers { get; set; }

    public virtual DbSet<Terminal> Terminals { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=flightproj;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Flight>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.Flights");

            entity.HasOne(d => d.Terminal).WithMany(p => p.Flights).HasConstraintName("FK_dbo.Flights_dbo.Terminals_Terminal_Id");
        });

        modelBuilder.Entity<Logger>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.Loggers");

            entity.HasOne(d => d.Terminal).WithMany(p => p.Loggers).HasConstraintName("FK_dbo.Loggers_dbo.Terminals_Terminal_Id");
        });

        modelBuilder.Entity<Terminal>()
            .HasDiscriminator<int>("Discriminator")
            .HasValue<Terminal_1>(1)
            .HasValue<Terminal_2>(2)
            .HasValue<Terminal_3>(3)
            .HasValue<Terminal_4>(4)
            .HasValue<Terminal_5>(5)
            .HasValue<Terminal_6>(6)
            .HasValue<Terminal_7>(7)
            .HasValue<Terminal_8>(8);

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
