using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MVCPeopleDatabase.Models.ViewModels
{
    public class CreateCityViewModel
    {
        [StringLength(80, MinimumLength = 1)]
        [Display(Name = "City")]
        [Required]
        public string? CityName { get; set; }
      
    }
}
