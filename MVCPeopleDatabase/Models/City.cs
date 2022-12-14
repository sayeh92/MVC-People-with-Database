using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;

namespace MVCPeopleDatabase.Models
{
    public class City
    {
        [Key]
        public int Id { get; set; }// Key
        public City()
        {

        }
        public City(string CityName)
        {
            CityName = CityName;
        }

        [Required]
        [MaxLength(80)]
        public string? CityName { get; set; }
      
        public List<Person>? People { get; set; }//Navigation Property

        [ForeignKey("Country")]
        public int CountryId { get; set; }// PeopleDbContext ForeignKey
        public Country Country { get; set; }//Navigation Property
    


       
    }
}
