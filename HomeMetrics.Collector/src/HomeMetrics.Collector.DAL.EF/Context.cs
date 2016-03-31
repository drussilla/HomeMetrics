using HomeMetrics.Collector.DAL.Models;
using Microsoft.Data.Entity;

namespace HomeMetrics.Collector.DAL.EF
{
    public class Context : DbContext
    {
        public DbSet<Sensor> Sensors { get; set; } 
        public DbSet<Reading> Readings { get; set; } 

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=data.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Sensor>()
                .HasKey(x => x.Id);

            modelBuilder
                .Entity<Reading>()
                .HasKey(x => x.Id);

            modelBuilder
                .Entity<Reading>()
                .HasOne(x => x.Sensor)
                .WithMany()
                .HasForeignKey(x => x.SensorId);
        }
    }
}