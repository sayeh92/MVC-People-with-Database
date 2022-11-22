using MVC_People.Models;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace MVC_People.Models.Data
{
    public class PeopleDbContext:DbContext
    {
        public PeopleDbContext(DbContextOptions<PeopleDbContext> options) : base(options)
        { }
        public DbSet<Person>? People { get; set; }

    }
}
