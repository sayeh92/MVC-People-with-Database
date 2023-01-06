using MVCPeopleDatabase.Models.ViewModels;
namespace MVCPeopleDatabase.Models.Services
{
    public interface IpeopleService
    {

        Person Add(CreatePersonViewModel addPerson);

        List<Person> FindAllPeople();
      
       // List<Person> FindByCity(string cityname);

        //List<Person> Search(string search);

        Person FindById(int id);

        bool Edit(int id, CreatePersonViewModel editPerson);

        bool Remove(int id);

        //List <Person> FindByCity(City foundCity);
    }
}
