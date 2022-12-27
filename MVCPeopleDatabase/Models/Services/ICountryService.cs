using MVCPeopleDatabase.Models.ViewModels;

namespace MVCPeopleDatabase.Models.Services
{
    public interface ICountryService
    {
        Country Add(CreateCountryViewModel AddCountry);
        List<Country> FindAll();
       

        Country FindById(int id);

        bool Update(int id, CreateCountryViewModel editCountry);
        bool RemoveById (int id);
    }
}
