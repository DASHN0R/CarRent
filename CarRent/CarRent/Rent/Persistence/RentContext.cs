using CarRent.Car.Domain;
using CarRent.Rent.Domain;
using Microsoft.EntityFrameworkCore;

namespace CarRent.Rent.Persistence
{
    public class RentContext : DbContext
    {
        public DbSet<Reservation> Reservations { get; set; }

        public RentContext(DbContextOptions<RentContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var reservation = modelBuilder.Entity<Reservation>();
            reservation.HasKey(x => x.Id);
            reservation.Property(x => x.DurationInDays);
            reservation.HasOne(x => x.DesiredCarClass);
            reservation.HasOne(x => x.Customer);
            reservation.Property(x => x.StartDate);
            reservation.HasOne(x => x.Contract);

            var contract = modelBuilder.Entity<Contract>();
            contract.HasKey(x => x.Id);
            contract.Property(x => x.PickUpDate);
            contract.HasOne(x => x.Car);

            reservation.Navigation(x => x.Contract).AutoInclude();
            contract.Navigation(x => x.Car).AutoInclude();

            base.OnModelCreating(modelBuilder);
        }
    }
}
