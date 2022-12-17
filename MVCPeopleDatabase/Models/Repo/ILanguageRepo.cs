namespace MVCPeopleDatabase.Models.Repo
{
    public interface ILanguageRepo
    {
        public Language CreateLanguage(Language language);
        public List<Language> ReadAllLanguage();
        public Language ReadLanguage(int id);
        public bool UpdateLanguage(Language language);
        public bool DeleteLanguage(Language language);
    }
}
