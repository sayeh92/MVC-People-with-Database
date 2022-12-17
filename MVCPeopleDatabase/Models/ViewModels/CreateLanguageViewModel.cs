using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MVCPeopleDatabase.Models.ViewModels
{
    public class CreateLanguageViewModel
    {
        [Display(Name = "LanguageName")]
        [Required]
        public string? LanguageName { get; set; }
       
        public int LanguageId { get; set; }
    }
}
