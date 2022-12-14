using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace MVCPeopleDatabase.Models
{
    public class Person


    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? PhoneNumber { get; set; }

     
        public Person(){ }  

        public Person(string? name/*, string? phonenumber*//*, string? cityname*/)
        {
            Name = name;
            //phonenumber = phonenumber;
            //cityname = cityname;
        }


        [ForeignKey(nameof(City))]
        public int CityId { get; set; } 
        public City? City { get; set; }
        
        //public List<PeopleLanguage> PeopleLanguages { get; set; }
       
    }
}
