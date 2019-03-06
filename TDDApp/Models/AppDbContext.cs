using System.Data.Entity;

namespace TDDApp.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
    }
}