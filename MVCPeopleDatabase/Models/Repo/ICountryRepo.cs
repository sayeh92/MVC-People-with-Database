namespace MVCPeopleDatabase.Models.Repo
{
    public interface ICountryRepo
    {
        public Country Create(Country country);
        public List<Country> ReadAll();
        public Country FindById(int id);
        public bool Update(Country country);
        public bool Delete(Country country);
    }
}
