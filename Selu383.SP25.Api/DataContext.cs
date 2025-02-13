using Microsoft.EntityFrameworkCore;
using Selu383.SP25.Api.Entities;
using System.Data;
using System.Reflection;

namespace Selu383.SP25.Api
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        // Define each entity below

        public DbSet<Theater> Theaters { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).GetTypeInfo().Assembly);
        }
    }
}