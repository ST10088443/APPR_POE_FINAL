using Disaster_Alleviation_Foundation_App.NewFolder;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Disaster_Alleviation_Foundation_App.NewFolder
{
    public class Allocation
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Amount Allocated")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal AmountAllocated { get; set; }

        [Required]
        [Display(Name = "Disaster ID")]
        public int DisasterId { get; set; }

        // Navigation property to link Allocation to a Disaster
        public Disaster Disasters { get; set; }

        // Additional information about the allocation, if needed
        public string AdditionalInformation { get; set; }

        [Display(Name = "Allocation Date")]
        public DateTime AllocationDate { get; set; }

        public class AllocationViewModel
        {
            public Allocation Allocation { get; set; }
            public List<SelectListItem> Disasters { get; set; }
        }

    }
}

