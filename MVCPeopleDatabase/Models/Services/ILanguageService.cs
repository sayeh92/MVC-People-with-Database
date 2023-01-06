using MVCPeopleDatabase.Models.ViewModels;

namespace MVCPeopleDatabase.Models.Services
{
    public interface ILanguageService
    {
        Language Add(CreateLanguageViewModel addLanguage);
        List<Language> AllLanguage();

        Language FindLanguageById(int id);

        bool EditLanguageById(int id, CreateLanguageViewModel editLanguage);
        bool RemoveLanguage(int id);
       
    }
}

