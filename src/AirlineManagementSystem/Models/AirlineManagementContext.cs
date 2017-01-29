using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AirlineManagementSystem.Models
{
    public partial class AirlineManagementContext : DbContext
    {
        public virtual DbSet<Airline> Airline { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AirlineManagement;Integrated Security=True");
        }


        public AirlineManagementContext(DbContextOptions<AirlineManagementContext> options)
        : base(options)
    { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Airline>(entity =>
            {
                entity.Property(e => e.Name).HasColumnType("varchar(50)");
            });
        }
    }
}