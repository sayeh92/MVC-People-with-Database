using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MVCPeopleDatabase.Models.ViewModels
{
    public class CreateCityViewModel
    {
        [Required]
        [StringLength(80, MinimumLength = 2)]
        [Display(Name = "City Name")]
        public string? CityName { get; set; }
        public List<Person>? PeopleList { get; set; }
        public int CountryId { get; set; }
        public List<Country>? Countries { get; set; }

        public CreateCityViewModel() { Countries = new List<Country>(); }


    }
}
