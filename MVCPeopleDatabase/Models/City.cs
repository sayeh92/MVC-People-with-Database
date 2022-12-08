using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;

namespace MVCPeopleDatabase.Models
{
    public class City
    {

        public int Id { get; set; }// Key


        [Required]
        [MaxLength(80)]
        public string? CityName { get; set; }
        public List<Person>? People { get; set; }//Navigation Property

        //public int CountryId { get; set; }// PeopleDbContext ForeignKey

       // public Country? Country { get; set; }//Navigation Property
        public City()
        {

        }


       
    }
}
