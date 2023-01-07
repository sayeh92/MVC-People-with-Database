using System.ComponentModel.DataAnnotations;

namespace MVCPeopleDatabase.Models
{
    public class Language
    {
        [Key]
        public int Id { get; set; }
        public string LanguageName { get; set; }
        public string People { get; set; }
        //public List<PeopleLanguage> PeopleLanguages { get; set; }
        public Language() { }
        public Language(string languageName) { LanguageName = languageName; }
       
    }
}
