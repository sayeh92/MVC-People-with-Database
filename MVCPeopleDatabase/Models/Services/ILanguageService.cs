using MVCPeopleDatabase.Models.ViewModels;

namespace MVCPeopleDatabase.Models.Services
{
    public interface ILanguageService
    {
        Language Add(CreateLanguageViewModel addLanguage);
        List<Language> AllLanguage();

        Language FindById(int id);

        bool UpdateById(int id, CreateLanguageViewModel editLanguage);
        bool DeleteById(int id);
       
    }
}

