using MVCPeopleDatabase.Models.Repo;

namespace MVCPeopleDatabase.Models.Services
{
    public class LanguageService : ILanguageService
  
    {

        private ILanguageRepo _languageRepo;
        public LanguageService (ILanguageRepo languageRepo) 
        {
            _languageRepo = languageRepo;


        }


         public Country Add(CreateLanguageViewModel AddLanguage)
        {
            throw new NotImplementedException();
        }

        public List<Language> AllLanguage()
        {
            return _cityRepo.ReadAllCity();
        }

        public bool EditLanguage(int id, CreateLanguageViewModel editLanguage)
        {
            Language OriginalLanguage = FindLanguage(id);
            if (OriginalLanguage != null)
            {
                OriginalLanguage.Name = editLanguage.Name;
                
                OriginalLanguage.PhoneNumber = editLanguage.PhoneNumber;
            }
            return _peopleRepo.Update(OriginalLanguage);
        }

        public Country FindLanguage(int id)
        {
            return _peopleRepo.Read(id);
        }

        public bool RemoveLanguage(int id)
        {
            Person DeletePerson = _peopleRepo.Read(id);
            bool Done = _peopleRepo.Delete(DeletePerson);
            return Done;
        }
    }
}
