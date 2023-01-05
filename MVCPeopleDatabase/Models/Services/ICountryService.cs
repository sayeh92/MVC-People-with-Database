using MVCPeopleDatabase.Models.ViewModels;

namespace MVCPeopleDatabase.Models.Services
{
    public interface ICountryService
    {
        Country CreateCity(CreateCountryViewModel CreateCity);
        List<Country> FindAll();
       

        Country FindCityById(int id);

        bool UpdateCity(int id, CreateCountryViewModel editCountry);
        bool RemoveCityById (int id);
    }
}
