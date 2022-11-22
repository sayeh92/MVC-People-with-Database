namespace MVCPeopleDatabase.Models.Repo
{
    public interface IPeopleRepo
    {
        //CREATE
        public Person Add(String name, string phonenumber, string cityname);
        //READ
        public List<Person> Read();

        public List<Person> GetByCity(string cityname);

        public Person Read(int id);

      
        //UPDATE
        public bool Update (Person person);

        //DELETE
        public bool Delete(Person  person);
      
    }
}
