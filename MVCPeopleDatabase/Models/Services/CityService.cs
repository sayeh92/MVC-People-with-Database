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
       
        public City CreateCity(CreateCityViewModel createCity)
        {
            if (string.IsNullOrWhiteSpace(createCity.CityName))
             
            {
                throw new ArgumentException("Not allowed WhiteSpace");
            }
            City city = new City();
            {

                city.CityName = createCity.CityName;
                foreach (Country country in _peopleDbContext.Countries.ToList())
                {
                    if (createCity.CountryName == country.Name)
                    {
                        city.Country = country;
                    }
                }



            }
            city = _cityRepo.Create(city);
            return city;
        }

        public List<City> AllCity()
        {
            return _cityRepo.ReadAll();
        }

        public City FindCityById(int id)
        {
            return _cityRepo.Read(id);
        }

        public bool EditCity(int id, CreateCityViewModel editCity)
        {
            City OriginalCity = FindCityById(id);
            if (OriginalCity != null)
            {
                OriginalCity.CityName = editCity.CityName;
                
            }
            return _cityRepo.Update(
                OriginalCity);
        }

      
        public bool RemoveCity(int id)
        {
            City DeleteCity = _cityRepo.Read(id);
            bool DoneCity = _cityRepo.Delete(DeleteCity);
            return DoneCity;
        }

        //public City FindByCityName(string cityName)
        //{
        //    return  _cityRepo.ReadCity(cityName);
            
        //}
    }
}
