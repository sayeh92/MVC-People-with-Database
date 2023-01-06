using MVCPeopleDatabase.Models.Data;

namespace MVCPeopleDatabase.Models.Repo
{
    public class DataBaseCountryRepo : ICountryRepo
    {
        readonly PeopleDbContext _peopleDbContext;
        public DataBaseCountryRepo(PeopleDbContext peopleDbContext)
        {
            _peopleDbContext = peopleDbContext;
        }
        public Country Create(Country country)
        {
            _peopleDbContext.Countries.Add(country);
            _peopleDbContext.SaveChanges();
            return country;
        }

        public bool Delete(Country country)
        {
            _peopleDbContext.Countries.Remove(country);
            _peopleDbContext.SaveChanges();
            return true;
        }

        public List<Country> ReadAll()
        {
            return _peopleDbContext.Countries.ToList();
        }

        public Country FindById(int id)
        {
      return _peopleDbContext.Countries.SingleOrDefault(country => country.Id == id);
        }

        public bool Update(Country country)
        {
            _peopleDbContext.Update(country);
            _peopleDbContext.SaveChanges();
            return true;
        }
    }
}
