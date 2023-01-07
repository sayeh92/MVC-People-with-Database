using Microsoft.EntityFrameworkCore;
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

        public City Read(int id)
        {
            return _peopleDbContext.Cities.SingleOrDefault(city => city.Id == id);
        }

     
        public List<City> ReadAll()
        {
            return _peopleDbContext.Cities.Include(city => city.Id == id).ToList();
        }

        public bool Update(City city)
        {
            _peopleDbContext.Update(city);
            _peopleDbContext.SaveChanges();
            return true;
        }

      }

     

      

        
    
}
