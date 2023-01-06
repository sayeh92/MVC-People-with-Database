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
            if (string.IsNullOrWhiteSpace(createCity.Name) ||
                //string.IsNullOrWhiteSpace(addperson.CityName) ||
                string.IsNullOrWhiteSpace(createCity.PhoneNumber))
            { throw new ArgumentException("Name, CityName, PhoneNumber Not allowed WhiteSpace"); }
            Person person = new Person();
            {

                person.Name = createCity.Name;
                person.PhoneNumber = createCity.PhoneNumber;
                // person.CityName = addperson.CityName;

            }
            person = _peopleRepo.Add(person);
            return person;
        }

        public List<City> AllCity()
        {
            return _cityRepo.ReadAllCity();
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

        //public City FindByCityName(string cityName)
        //{
        //    return  _cityRepo.ReadCity(cityName);
            
        //}
    }
}
