namespace MVCPeopleDatabase.Models.Repo
{
    public interface IPeopleRepo
    {
        //CREATE
        public Person Add(/*String name, string phonenumber, string cityname*/ Person person);
        //READ
        public List<Person> ReadAll();

        //public List<Person> GetByCity(string cityname);

        public Person Read(int id);

      
        //UPDATE
        public bool Update (Person person);

        //DELETE
        public bool Delete(Person  person);
        //List<Person> GetPersonByCity(City foundCity);
    }
}
