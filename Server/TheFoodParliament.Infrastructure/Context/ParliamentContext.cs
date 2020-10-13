using System;
using Microsoft.EntityFrameworkCore;
using TheFoodParliament.Entities.Models;

namespace TheFoodParliament.Infrastructure.Context
{
    public class ParliamentContext : DbContext
    {
        public ParliamentContext(DbContextOptions<ParliamentContext> options) : base(options)
        { }

        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Vote> Votes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Election> Elections { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Election>().HasOne(b => b.Restaurant);
            modelBuilder.Entity<User>().HasData(
                    new User { Id = 1, CreationDate = DateTime.Now, Name = "João" },
                    new User { Id = 2, CreationDate = DateTime.Now, Name = "Maria" },
                    new User { Id = 3, CreationDate = DateTime.Now, Name = "Pedro" },
                    new User { Id = 4, CreationDate = DateTime.Now, Name = "Paula" });
        }
    }
}