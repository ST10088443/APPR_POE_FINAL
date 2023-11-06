using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Disaster_Alleviation_Foundation_App.NewFolder
{
    public class MonetaryDonation
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public bool IsAnonymous { get; set; }

        // Foreign key to link donation to user
        [ForeignKey("UserID")]
        public ApplicationUser User { get; set; }
    }
}
