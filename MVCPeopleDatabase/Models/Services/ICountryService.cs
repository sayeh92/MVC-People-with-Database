namespace MVCPeopleDatabase.Models.Services
{
    public interface ICountryService
    {
        Country Add(CreateCountryViewModel AddCountry);
        List<Country> AllCountry();
       

        Country FindCountry(int id);

        bool EditCountry(int id, CreateCountryViewModel editCountry);
        bool RemoveCountry (int id);
    }
}
