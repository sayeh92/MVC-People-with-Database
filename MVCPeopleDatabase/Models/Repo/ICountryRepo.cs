﻿namespace MVCPeopleDatabase.Models.Repo
{
    public interface ICountryRepo
    {
        public Country CreateCountry(Country country);
        public List<Country> ReadAllCountry();
        public Country FindById(int id);
        public bool UpdateCountry(Country country);
        public bool DeleteCountry(Country country);
    }
}
