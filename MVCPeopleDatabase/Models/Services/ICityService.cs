using MVCPeopleDatabase.Models.ViewModels;

namespace MVCPeopleDatabase.Models.Services
{
    public interface ICityService
    {
        City CreateCity(CreateCityViewModel CreateCity);
        List<City> AllCity();

        City FindCityById(int id);

        //City FindByCityName(string cityName);
        bool EditCity(int id, CreateCityViewModel editCity);

        bool RemoveCity(int id);

      
    }
}
