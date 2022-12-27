using Microsoft.Extensions.Logging.Abstractions;
using MVCPeopleDatabase.Models.Repo;

namespace MVCPeopleDatabase.Models.Services
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepo _countryRepo;
        public CountryService(ICountryRepo countryRepo)
        {
            _countryRepo = countryRepo;
        }

        public Country Add(CreateCountryViewModel AddCountry)
        {
           if (string.IsNullOrWhiteSpace(AddCountry.CountryName)) 
            {
                return null;
            }

           return _countryRepo.Add(new Country(AddCountry.CountryName));
        }

        public List<Country> FindAll()
        {
            return _countryRepo.ReadAllCountry();
        }
               
        public Country FindById(int id)
        {
            return _countryRepo.FindById(id);
           
        }
        public bool EditCountry(int id, CreateCountryViewModel editCountry)
        {
            Country OriginalCountry = FindById(id);
            if (OriginalCountry == null)
            {
                return false;
            }
            OriginalCountry.Name = editCountry.CountryName;
            return _countryRepo.Edit(OriginalCountry);
        }

        public bool RemoveById(int id)
        {
            Country DeletedCountry = _countryRepo.FindById(id);
            bool CountryDone = _countryRepo.Delete(DeletedCountry);
            return CountryDone;
        }
    }
}
