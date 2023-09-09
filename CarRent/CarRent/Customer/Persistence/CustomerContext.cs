using CarRent.Car.Domain;
using Microsoft.EntityFrameworkCore;

namespace CarRent.Customer.Persistence
{
    public class CustomerContext : DbContext
    {
        public DbSet<Domain.Customer> Customers { get; set; }

        public CustomerContext(DbContextOptions<CustomerContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var customer = modelBuilder.Entity<Domain.Customer>();
            customer.HasKey(x => x.Id);
            customer.Property(x => x.FirstName);
            customer.Property(x => x.LastName);
            customer.Property(x => x.Street);
            customer.Property(x => x.City);

            base.OnModelCreating(modelBuilder);
        }
    }
}
