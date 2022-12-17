namespace MVCPeopleDatabase.Models.ViewModels;
using System.ComponentModel.DataAnnotations;

public class CountryViewModel
{
    public List<Country> ListOfCountryView { get; set; }
    public string CountryString { get; set; }

    public CountryViewModel()
    {
        ListOfCountryView = new List<Country>();
    }
}
