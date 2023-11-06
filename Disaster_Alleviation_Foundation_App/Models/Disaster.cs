using Disaster_Alleviation_Foundation_App.Models;
using System.ComponentModel.DataAnnotations;
namespace Disaster_Alleviation_Foundation_App.NewFolder
{
    public class Disaster
    {
        [Key]
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }

        // Define a many-to-many relationship with AidType
        public List<DisasterAidType> DisasterAidTypes { get; set; }
        public List<int> SelectedAidTypes { get; set; }
        public bool IsActive { get; set; }

    }
}
