using Microsoft.EntityFrameworkCore;
using PactiaPerson.Shared.Entities;

namespace PactiaPerson.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Person>().HasIndex(x => x.Cedula).IsUnique();
        }
    }
}
