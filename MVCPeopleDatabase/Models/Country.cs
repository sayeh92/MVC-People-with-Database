namespace MVCPeopleDatabase.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string CountryName { get; set; }

        public List<City> Cities { get; set;}
        public Country() { }
        public Country(string countryName) { CountryName = countryName; }
    }
}
