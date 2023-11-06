using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Disaster_Alleviation_Foundation_App.Models
{
    public class AidType
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<DisasterAidType> DisasterAidTypes { get; set; }
    }
}
