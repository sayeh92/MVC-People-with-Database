using MVCPeopleDatabase.Models.Repo;
using MVCPeopleDatabase.Models.ViewModels;

namespace MVCPeopleDatabase.Models.Services
{
    public class CityService : ICityService
    {
        private readonly ICityRepo _cityRepo;

        public CityService (ICityRepo cityRepo) 
        {
            _cityRepo= cityRepo;
        }
       
       public List<City> AllCity()
        {
           return _cityRepo.ReadAllCity();
        }

        public City CreateCity(CreateCityViewModel CreateCity)
        {
            throw new NotImplementedException();
        }

        public City FindCityById(int id)
        {
            return _cityRepo.ReadCity(id);
        }

        public bool EditCity(int id, CreateCityViewModel editCity)
        {
            City OriginalCity = FindCityById(id);
            if (OriginalCity != null)
            {
                OriginalCity.CityName = OriginalCity.CityName;
                
            }
            return _cityRepo.Update(OriginalCity);
        }

      
        public bool RemoveCity(int id)
        {
            City DeleteCity = _cityRepo.ReadCity(id);
            bool DoneCity = _cityRepo.Delete(DeleteCity);
            return DoneCity;
        }
    }
}
