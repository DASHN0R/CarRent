using CarRent.Car.Domain;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;

namespace CarRent.Car.Persistence
{
    public class CarContext : DbContext
    {
        public DbSet<Domain.Car> Cars { get; set; }

        public CarContext(DbContextOptions<CarContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var car = modelBuilder.Entity<Domain.Car>();
            car.HasKey(x => x.Id);
            car.Property(x => x.CarNumber);
            car.HasOne(x => x.Brand);
            car.HasOne(x => x.Type);
            car.HasOne(x => x.CarClass);

            var brand = modelBuilder.Entity<Brand>();
            brand.HasKey(x => x.Id);
            brand.Property(x => x.Name);

            var type = modelBuilder.Entity<Domain.Type>();
            type.HasKey(x => x.Id);
            type.Property(x => x.Name);

            var carClass = modelBuilder.Entity<CarClass>();
            carClass.HasKey(x => x.Id);
            carClass.Property(x => x.Name);

            car.Navigation(x => x.Brand).AutoInclude();
            car.Navigation(x => x.Type).AutoInclude();
            car.Navigation(x => x.CarClass).AutoInclude();

            base.OnModelCreating(modelBuilder);
        }
    }
}
