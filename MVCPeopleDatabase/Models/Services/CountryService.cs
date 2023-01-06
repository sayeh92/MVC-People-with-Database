using Microsoft.Extensions.Logging.Abstractions;
using MVCPeopleDatabase.Models.Repo;
using MVCPeopleDatabase.Models.ViewModels;

namespace MVCPeopleDatabase.Models.Services
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepo _countryRepo;
        public CountryService(ICountryRepo countryRepo)
        {
            _countryRepo = countryRepo;
        }

        public Country CreateCountry(CreateCountryViewModel AddCountry)
        {
           if (string.IsNullOrWhiteSpace(AddCountry.Name)) 
            {
                return null;
            }

           return _countryRepo.Create(new Country(AddCountry.Name));
        }

        public List<Country> FindAllCountry()
        {
            return _countryRepo.ReadAll();
        }
               
        public Country FindCountryById(int id)
        {
            return _countryRepo.FindById(id);
           
        }
        public bool UpdateCountry(int id, CreateCountryViewModel editCountry)
        {
            Country OriginalCountry = FindCountryById(id);
            if (OriginalCountry == null)
            {
                return false;
            }
            OriginalCountry.Name = editCountry.Name;
            return _countryRepo.Update(OriginalCountry);
        }

        public bool RemoveCountryById(int id)
        {
            Country DeletedCountry = _countryRepo.FindById(id);
            bool CountryDone = _countryRepo.Delete(DeletedCountry);
            return CountryDone;
        }

       
    }
}
