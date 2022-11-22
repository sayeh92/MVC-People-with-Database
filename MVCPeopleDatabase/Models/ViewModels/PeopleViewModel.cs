namespace MVCPeopleDatabase.Models.ViewModels
{
    public class PeopleViewModel
    {
        public List<Person> ListOfPeopletView { get; set;}
        public string FilterString { get; set;}

        public PeopleViewModel() 
        {
            ListOfPeopletView = new List<Person>();
        }
    }
}
