using MVC_People.Models.Data;

namespace MVC_People.Models.Repo
{
    public class DataBasePeopleRepo : IPeopleRepo
    {
        readonly PeopleDbContext _peopleDbContext;

        public DataBasePeopleRepo (PeopleDbContext peopleDbContext)
        {
            _peopleDbContext = peopleDbContext;
        }

        public Person Add(string name, string phonenumber, string cityname)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Person person)
        {
            throw new NotImplementedException();
        }

        public List<Person> GetByCity(string cityname)
        {
            throw new NotImplementedException();
        }

        public List<Person> Read()
        {
            return _peopleDbContext.People.ToList();
        }

        public Person Read(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Person person)
        {
            throw new NotImplementedException();
        }
    }
}
