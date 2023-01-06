using MVCPeopleDatabase.Models.Data;

namespace MVCPeopleDatabase.Models.Repo
{
    public class DataBaseLanguageRepo : ILanguageRepo
    {
        readonly PeopleDbContext _peopleDbContext;
        public DataBaseLanguageRepo(PeopleDbContext peopleDbContext)
        {
            _peopleDbContext = peopleDbContext;
        }
        public Language Create(Language language)
        {
            _peopleDbContext.Languages.Add(language);
            _peopleDbContext.SaveChanges();
            return language;
        }

        public bool Delete(Language language)
        {
            _peopleDbContext.Languages.Remove(language);
            _peopleDbContext.SaveChanges();
            return true;
        }

        public List<Language> ReadAll()
        {
            return _peopleDbContext.Languages.ToList();
        }

        public Language Read(int id)
        {
            return _peopleDbContext.Languages.SingleOrDefault(language => language.Id == id);
        }

        public bool Update(Language language)
        {
            _peopleDbContext.Update(language);
            _peopleDbContext.SaveChanges();
            return true;
        }
    }
}
    
