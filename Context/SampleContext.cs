using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleCore.Context
{
    public class SampleContext : DbContext
    {

        public SampleContext() { }

        public DbSet<Sample> Sample { get; set; }

        public SampleContext(DbContextOptions<SampleContext> options): base(options)
        {
           
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Sample;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Sample>(s =>
            {
                s.Property(i => i.Count).HasDefaultValue(0);
            });
        }
    }
}
