using Microsoft.EntityFrameworkCore;
using ARS.Models;

namespace ARS.Models
{
    public class ContextCS : DbContext
    {
        public ContextCS(DbContextOptions<ContextCS> options)
            : base(options)
        {

        }



        public DbSet<Flight> Flights { get; set; }
        public DbSet<AdminPanel> AdminPanels { get; set; }
        public DbSet<UserAccount> UserLogins { get; set; }
        public DbSet<AeroPlaneInfo> AeroPlaneInfo { get; set; }
        public DbSet<FlightBooking> FlightBooking { get; set; }
        public DbSet<ARS.Models.TicketReserve_tbl> TicketReserve_tbl { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ✅ Define Foreign Key Relationship
            modelBuilder.Entity<FlightBooking>()
                .HasOne(fb => fb.TicketReserve_tbls)
                .WithMany(t => t.FlightBookings) // If TicketReserve_tbl has a List<FlightBooking>, use .WithMany(t => t.FlightBookings)
                .HasForeignKey(fb => fb.ResId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<FlightBooking>()
                .HasOne(fb => fb.PlaneInfo)
                .WithMany()
                .HasForeignKey(fb => fb.Planeid)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
