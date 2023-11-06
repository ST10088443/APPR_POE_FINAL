using System.ComponentModel.DataAnnotations;
namespace Disaster_Alleviation_Foundation_App.NewFolder
{
    public class GoodsCategory
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
