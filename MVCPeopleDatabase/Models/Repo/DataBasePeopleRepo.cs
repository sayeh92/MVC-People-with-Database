using Microsoft.EntityFrameworkCore;
using MVCPeopleDatabase.Models.Data;

namespace MVCPeopleDatabase.Models.Repo
{
    public class DataBasePeopleRepo : IPeopleRepo
    {
        readonly PeopleDbContext _peopleDbContext;
        public DataBasePeopleRepo(PeopleDbContext peopleDbContext)
        {
            _peopleDbContext = peopleDbContext;
        }

        public Person Add(/*string name, string phonenumber, string cityname*/ Person person)
        {
            _peopleDbContext.People.Add(person);
            _peopleDbContext.SaveChanges();
            return person;
        }

       

        //public List<Person> GetByCity(string cityname)
        //{
        //    return _peopleDbContext.People.Where(person => person.CityName.Contains(cityname)).ToList();
        //}

        public List<Person> ReadAll()
        {
            //return _peopleDbContext.People.ToList();
            return _peopleDbContext.People.Include(person => person.City).ThenInclude(person => person.Country).ToList();
            //return _peopleDbContext.People.Include(person => person.City).ToList();
        }

        public Person Read(int id)
        {
            return _peopleDbContext.People.SingleOrDefault(person => person.Id == id);
        }

        public bool Update(Person person)
        {
            _peopleDbContext.People.Update(person);
            _peopleDbContext.SaveChanges();
            return true;
        }

        public bool Delete(Person person)
        {
           _peopleDbContext.People.Remove(person);
            _peopleDbContext.SaveChanges();
            return true;
        }
    }
}
