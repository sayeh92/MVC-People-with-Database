using System.ComponentModel.DataAnnotations;

namespace MVC_People.Models.ViewModels
{
    public class CreatePersonViewModel
    {

        [Display(Name = "Person")]
        [Required]
        public string? Name { get; set; }
        [Display(Name = "PhoneNumber")]
        [Required]
        public string? PhoneNumber { get; set; }
        [Display(Name = "CityName")]
        [Required]
        [StringLength(80, MinimumLength = 1)]
        public string? CityName { get; set; }
        public List<string> CityNameList
        {
            get
            {
                return new List<string> { "Mars", "Venus", "Earth", "Moon", "Sun", "Jupiter", "Saturn", "Uranus", "Neptune" }; 

            }
        }
  
    }
           
}
