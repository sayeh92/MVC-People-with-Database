using System.Runtime.InteropServices;

namespace MVCPeopleDatabase.Models.Repo
{
    public interface ICityRepo
    {
        public City Create(City city);
        public List<City> ReadAllCity();
        public City ReadCity(int id);
        public bool Update(City city);
        public bool Delete(City city);
    }
}
