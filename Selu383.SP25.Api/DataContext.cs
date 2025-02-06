using Microsoft.EntityFrameworkCore;
using Selu383.SP25.Api.Entities;
using System;

namespace Selu383.SP25.Api
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}
        
        public DbSet<Theater> Theaters { get; set; } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Our seeded data

            modelBuilder.Entity<Theater>().HasData(
                new Theater { Id = 1, Name = "Marcus Theater", Address = "123 Street", SeatCount = 500 },
                new Theater { Id=2, Name="AMC", Address = "Hammond", SeatCount = 200},
                new Theater { Id=3, Name = "Cineplex", Address = "Irving Mall", SeatCount = 350}
                );
        }
    }
}
