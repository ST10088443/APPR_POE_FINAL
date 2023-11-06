using Disaster_Alleviation_Foundation_App.NewFolder;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Disaster_Alleviation_Foundation_App.Models
{
    public class DisasterAidType
    {
        [Key]
        public int Id { get; set; }

        // Foreign key to link to the Disaster entity
        [ForeignKey("DisasterId")]
        public int DisasterId { get; set; }
        public Disaster Disaster { get; set; }

        // Foreign key to link to the AidType entity
        [ForeignKey("AidTypeId")]
        public int AidTypeId { get; set; }
        public AidType AidType { get; set; }
    }
}
