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
        public DbSet<Person>? People { get; set; } 
        public DbSet<City>? Cities { get; set; } 

        public DbSet<Country>? Countries { get; set; } 
        public DbSet<Language>? Languages { get; set; } 

        //public DbSet<PeopleLanguage> PeopleLanguages { get; set; }


    }
}
