using MVCPeopleDatabase.Models.ViewModels;

namespace MVCPeopleDatabase.Models.Services
{
    public interface ICountryService
    {
        Country CreateCountry(CreateCountryViewModel CreateCity);
        List<Country> FindAllCountry();
       

        Country FindCountryById(int id);

        bool UpdateCountry(int id, CreateCountryViewModel editCountry);
        bool RemoveCountryById (int id);
    }
}
