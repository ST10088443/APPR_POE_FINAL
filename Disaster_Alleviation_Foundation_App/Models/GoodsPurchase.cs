using Disaster_Alleviation_Foundation_App.NewFolder;
using System.ComponentModel.DataAnnotations;

namespace Disaster_Alleviation_Foundation_App.Models
{
    public class GoodsPurchase
    {
        [Required(ErrorMessage = "Amount spent is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Amount spent must be greater than 0.")]
        public decimal AmountSpent { get; set; }

        [Required(ErrorMessage = "Goods category is required.")]
        public int GoodsCategoryId { get; set; }

        [Required(ErrorMessage = "Quantity purchased is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than 0.")]
        public int QuantityPurchased { get; set; }

        [StringLength(200, ErrorMessage = "Description should not exceed 200 characters.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Select a disaster.")]
        public int DisasterId { get; set; }
    }

}
