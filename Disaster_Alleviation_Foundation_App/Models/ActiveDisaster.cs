namespace Disaster_Alleviation_Foundation_App.Models
{
    public class ActiveDisaster
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
    }
}
