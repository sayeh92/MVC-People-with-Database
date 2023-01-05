using System.ComponentModel.DataAnnotations;

namespace MVCPeopleDatabase.Models
{
    public class Country
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public List<City> Cities { get; set;}
        public Country() { }
        public Country(string countryName) { Name = countryName; }
    }
}
