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
        }
    }
}