using Bill.Management.Abstractions;
using BillManagement.Imlementations.Data;
using Microsoft.EntityFrameworkCore;

namespace Bill.Management.Implementations.Data.Users.Repositories.Contexts
{
    internal sealed class BillDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Invoice> Invoices { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseNpgsql("Host=192.168.1.72;Database=LevelUp;Username=postgres;Password=qwe123;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<User>();
            modelBuilder
                .Entity<Invoice>();
        }
    }
}