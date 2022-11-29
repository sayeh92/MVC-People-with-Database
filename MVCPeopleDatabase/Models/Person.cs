using Microsoft.AspNetCore.Identity;
using System.Xml.Linq;

namespace MVCPeopleDatabase.Models
{
    public class Person


    {
        public Person()
        { }

        //public Person(string? name, string? phonenumber, string? cityname)
        //{
        //    Name = name;
        //    PhoneNumber = phonenumber;
        //    CityName = cityname;
        //}


        public int Id { get; set; }
        public string? Name { get; set; }
        public string? PhoneNumber { get; set; }
        public string? CityName { get; set; }
    }
}
