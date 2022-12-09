namespace MVCPeopleDatabase.Models.ViewModels
{
    public class CityViewModel
    {
        public List<City> ListOfCityView { get; set; }
        public string FilterString { get; set; }

        public CityViewModel()
        {
            ListOfCityView = new List<City>();
        }
    }
}
