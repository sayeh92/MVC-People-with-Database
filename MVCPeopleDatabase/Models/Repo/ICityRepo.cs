using System.Runtime.InteropServices;

namespace MVCPeopleDatabase.Models.Repo
{
    public interface ICityRepo
    {
        public City Create(City city);
        public List<City> ReadAll();
        //select * from city where id = {id}
        public City Read(int id);
        public bool Update(City city);
        public bool Delete(City city);
       // public City GetCityByCityName(string cityName);
    }
}
