using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Disaster_Alleviation_Foundation_App.NewFolder
{
    public class GoodsDonations
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int NumberOfItems { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public bool IsAnonymous { get; set; }

        // Foreign key to link donation to user
        [ForeignKey("UserID")]
        public ApplicationUser User { get; set; }

        // Foreign key to link goods allocation to a disaster
        [ForeignKey("DisasterId")]
        public int DisasterId { get; set; }
        public Disaster Disaster { get; set; }
    }
}
