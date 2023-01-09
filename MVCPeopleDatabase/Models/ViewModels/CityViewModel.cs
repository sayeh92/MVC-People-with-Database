namespace MVCPeopleDatabase.Models.ViewModels
{
    public class CityViewModel
    {
        public List<City> cities { get; set; }
        public string FilterString { get; set; }

        public CityViewModel()
        {
            cities = new List<City>();
        }
    }
}
