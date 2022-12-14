namespace MVCPeopleDatabase.Models
{
    public class PeopleLanguage
    {
        public int PersonId { get; set; }
        public Person Person { get; set; }
        public Language Language { get; set; }
        public int LanguageId { get; set;}
    }
}