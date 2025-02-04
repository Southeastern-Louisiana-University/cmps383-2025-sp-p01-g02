using Microsoft.EntityFrameworkCore;
using Selu383.SP25.Api.Dtos;
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
                new Theater { Id = 1, Name = "Marcus Theater", Address = "123 Street", SeatCount = 500 }
                );
        }
    }
}
