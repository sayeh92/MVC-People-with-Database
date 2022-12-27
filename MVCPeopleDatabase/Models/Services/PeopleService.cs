
using MVCPeopleDatabase.Models.Repo;
using MVCPeopleDatabase.Models.ViewModels;
namespace MVCPeopleDatabase.Models.Services
{
    public class PeopleService : IpeopleService
    {

        private readonly IPeopleRepo _peopleRepo;
        public PeopleService(IPeopleRepo peopleRepo)
        {
            _peopleRepo = peopleRepo;
        }
      

        public Person Add(CreatePersonViewModel addperson)
        {
            //Person person = _peopleRepo.Add(addperson.Name, addperson.PhoneNumber, addperson.CityName); 
            if (string.IsNullOrWhiteSpace(addperson.Name) ||
                //string.IsNullOrWhiteSpace(addperson.CityName) ||
                string.IsNullOrWhiteSpace(addperson.PhoneNumber))
            { throw new ArgumentException("Name, CityName, PhoneNumber Not allowed WhiteSpace"); }
            Person person = new Person();
            {

                person.Name = addperson.Name;
                person.PhoneNumber = addperson.PhoneNumber;
               // person.CityName = addperson.CityName;

            }
            person = _peopleRepo.Add(person);
            return person;
        }

        public bool Edit(int id, CreatePersonViewModel editPerson)
        {
            Person OriginalPerson = FindById(id);
            if (OriginalPerson != null)
            {
                OriginalPerson.Name = editPerson.Name;
               // OriginalPerson.CityName = editPerson.CityName;
                OriginalPerson.PhoneNumber = editPerson.PhoneNumber;
            }
            return _peopleRepo.Update(OriginalPerson);
        }



        public Person FindById(int id)
        {
            return _peopleRepo.Read(id);
        }

        public List<Person> FindAllPeople()
        {
            return _peopleRepo.Read();
        }

        //public List<Person> FindByCity(string cityname)
        //{
        //    return _peopleRepo.GetByCity(cityname);
        //}

        public bool Remove(int id)
        {
            Person DeletePerson = _peopleRepo.Read(id);
            bool Done = _peopleRepo.Delete(DeletePerson);
            return Done;
        }


        //public List<Person> Search(string search)
        //{
        //    return _peopleRepo.GetByCity(search);


        //    //foreach (Person item in _peopleRepo.Read())
        //    //{
        //    //    if (item.Name.Contains(search, StringComparison.OrdinalIgnoreCase) ||
        //    //        item.CityName.Contains(search, StringComparison.OrdinalIgnoreCase))
        //    //    {

        //    //        SearchPerson = SearchPerson.Where(p => p.Name.ToUpper().Contains(search.ToUpper()) ||
        //    //        p.CityName.Contains(search.ToUpper())).ToList();
        //    //        SearchPerson.Add(item);
        //    //    }
        //    //}

        //    //if (SearchPerson.Count == 0)
        //    //{
        //    //    throw new ArgumentException("Not here");
        //    //}
        //    //return SearchPerson;
        //}


    }
}
