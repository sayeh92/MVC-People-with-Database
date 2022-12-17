namespace MVCPeopleDatabase.Models.ViewModels
{
    public class LanguageViewModel
    {
        public List<Language> ListOfLanguageView { get; set; }
        public string CountryString { get; set; }

        public LanguageViewModel()
        {
            ListOfLanguageView = new List<Language>();
        }
    }
}
