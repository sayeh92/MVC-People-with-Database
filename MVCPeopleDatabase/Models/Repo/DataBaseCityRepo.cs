using MVCPeopleDatabase.Models.Data;

namespace MVCPeopleDatabase.Models.Repo
{
    public class DataBaseCityRepo : ICityRepo
    {

        readonly PeopleDbContext _peopleDbContext;
        public DataBaseCityRepo(PeopleDbContext peopleDbContext)
        {
            _peopleDbContext = peopleDbContext;
        }
        public City Create(City city)
        {
           _peopleDbContext.Cities.Add(city);
            _peopleDbContext.SaveChanges();
            return city;
        }

        public bool Delete(City city)
        {
           _peopleDbContext.Cities.Remove(city);
            _peopleDbContext.SaveChanges();
            return true;
        }

        public City ReadCity(int id)
        {
            return _peopleDbContext.Cities.SingleOrDefault(city => city.Id == id);
        }

     
        public List<City> ReadAllCity()
        {
            return _peopleDbContext.Cities.ToList();
        }

        public bool Update(City city)
        {
            _peopleDbContext.Update(city);
            _peopleDbContext.SaveChanges();
            return true;
        }

      }

     

      

        
    
}
