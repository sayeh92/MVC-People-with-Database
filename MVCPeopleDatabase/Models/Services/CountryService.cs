﻿using Microsoft.Extensions.Logging.Abstractions;

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

        public List<Country> All()
        {
            return _countryRepo.GetAll();
        }

       

        public bool Edit(int id, CreateCountryViewModel editCountry)
        {
            Country OriginalCountry = FindById(id);
            if (OriginalCountry == null) 
            {
                return false;
            }
            OriginalCountry.CountryName = editCountry.CountryName;
            return _countryRepo.Edit(OriginalCountry);
        }

        public Country FindById(int id)
        {
          Country FoundCountry = _countryRepo.FindById(id);
            return FoundCountry;
        }

        public bool Remove(int id)
        {
            Country DeletedCountry = _countryRepo.FindById(id);
            bool CountryDone = _countryRepo.Delete(DeletedCountry);
            return CountryDone;
        }
    }
}
