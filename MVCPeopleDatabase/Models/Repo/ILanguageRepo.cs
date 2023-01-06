namespace MVCPeopleDatabase.Models.Repo
{
    public interface ILanguageRepo
    {
        public Language Create(Language language);
        public List<Language> ReadAll();
        public Language Read(int id);
        public bool Update(Language language);
        public bool Delete(Language language);
    }
}
