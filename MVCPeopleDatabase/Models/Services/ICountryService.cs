namespace MVCPeopleDatabase.Models.Services
{
    public interface ICountryService
    {
        Country Add(CreateCountryViewModel AddCountry);
        List<Country> All();
       

        Country FindById(int id);

        bool Edit(int id, CreateCountryViewModel editCountry);
        bool Remove (int id);
    }
}
