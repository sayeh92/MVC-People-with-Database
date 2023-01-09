using MVCPeopleDatabase.Models.Repo;
using MVCPeopleDatabase.Models.ViewModels;

namespace MVCPeopleDatabase.Models.Services
{
    public class LanguageService : ILanguageService
  
    {

        private ILanguageRepo _languageRepo;
        public LanguageService (ILanguageRepo languageRepo) 
        {
            _languageRepo = languageRepo;


        }


         public Language Add(CreateLanguageViewModel addLanguage)
        {
            if (string.IsNullOrWhiteSpace(addLanguage.LanguageName) )
            { throw new ArgumentException("Name Not allowed WhiteSpace"); }
            Language language = new Language();
            {

                language.LanguageName = addLanguage.LanguageName;
               

            }
            language = _languageRepo.Create(language);
            return language;
        }

        public List<Language> AllLanguage()
        {
            return _languageRepo.ReadAll();
        }

        public bool UpdateById(int id, CreateLanguageViewModel editLanguage)
        {
            Language OriginalLanguage = FindById(id);
            if (OriginalLanguage != null)
            {
                OriginalLanguage.LanguageName = editLanguage.LanguageName;
                
               
            }
            return _languageRepo.Update(OriginalLanguage);
        }

        public Language FindById(int id)
        {
            return _languageRepo.Read(id);
        }

        public bool DeleteById(int id)
        {
            Language DeleteLanguage = _languageRepo.Read(id);
            bool Done = _languageRepo.Delete(DeleteLanguage);
            return Done;
        }
    }
}
