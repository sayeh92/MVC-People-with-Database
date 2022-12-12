using MVCPeopleDatabase.Models;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System.Diagnostics.Metrics;
using System.Linq;

namespace MVCPeopleDatabase.Models.Data
{
    public class PeopleDbContext:DbContext
    {
        public PeopleDbContext(DbContextOptions<PeopleDbContext> options) : base(options)
        { }
        public DbSet<Person> People { get; set; } = default!;
        public DbSet<City> Cities { get; set; } = default!;

        //public DbSet<Country> Countries { get; set; } = default!;
        //public DbSet<Language> Languages { get; set; } = default!;


    }
}
