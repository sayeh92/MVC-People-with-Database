using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MVCPeopleDatabase.Models.ViewModels
{
    public class CreateCountryViewModel
    {
        [Display(Name = "Country")]
        [Required]
        public string? CountryName { get; set; }
        public List<City> Country { get; set;}
    }
}
