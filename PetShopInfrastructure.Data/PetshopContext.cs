using Microsoft.EntityFrameworkCore;
using PetShop.Core.Entities;

namespace PetShop.Infrastructure.Data
{
    public class PetshopContext : DbContext
    {
        public PetshopContext(DbContextOptions<PetshopContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Customer)
                .WithMany(c => c.Orders)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Pet>()
                .HasOne(ow => ow.Owner)
                .WithMany(p => p.OwnedPets)
                .OnDelete(DeleteBehavior.SetNull);
        }

       
    }
}