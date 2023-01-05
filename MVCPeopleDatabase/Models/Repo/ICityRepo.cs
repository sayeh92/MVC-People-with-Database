using System.Runtime.InteropServices;

namespace MVCPeopleDatabase.Models.Repo
{
    public interface ICityRepo
    {
        public City CreateCity(City city);
        public List<City> ReadAllCity();
        //select * from city where id = {id}
        public City ReadCity(int id);
        public bool Update(City city);
        public bool Delete(City city);
       // public City GetCityByCityName(string cityName);
    }
}
