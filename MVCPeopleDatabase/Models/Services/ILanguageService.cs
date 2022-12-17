namespace MVCPeopleDatabase.Models.Services
{
    public interface ILanguageService
    {
        Country Add(CreateLanguageViewModel AddLanguage);
        List<Language> AllLanguage();

        Country FindLanguage(int id);

        bool EditLanguage(int id, CreateLanguageViewModel editLanguage);
        bool RemoveLanguage(int id);
    }
}

