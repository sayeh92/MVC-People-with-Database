using MVCPeopleDatabase.Models.ViewModels;
namespace MVCPeopleDatabase.Models.Services
{
    public interface IpeopleService
    {

        Person Add(CreatePersonViewModel addPerson);

        List<Person> All();
      
        List<Person> FindByCity(string cityname);

        List<Person> Search(string search);

        Person FindById(int id);

        bool Edit(int id, CreatePersonViewModel editPerson);

        bool Remove(int id);

    }
}
