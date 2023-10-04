using Microsoft.EntityFrameworkCore;
using PactiaPerson.Shared.Entities;

namespace PactiaPerson.API.Data
{
    public class DataContext : DbContext
    {
        //entity framework core
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        //mapeo tablas
        public DbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //validación de cedula unica
            modelBuilder.Entity<Person>().HasIndex(x => x.cedula).IsUnique();
        }
    }
}
