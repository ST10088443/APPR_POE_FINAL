using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Disaster_Alleviation_Foundation_App.Data;
using Disaster_Alleviation_Foundation_App.NewFolder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace Disaster_Alleviation_Foundation_App.Pages 
{
    public class AllocateMoneyModel : PageModel
    {
        private readonly DAFContext _context;
        public string AdditionalInformation { get; set; }
        public decimal AmountAllocated { get; set; }
        public int DisasterId { get; set; }
        public AllocateMoneyModel(DAFContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Allocation Allocation { get; set; }

        public List<SelectListItem> Disasters { get; set; }

        public void OnGet()
        {
            // Retrieve a list of active disasters from your database context
            var activeDisasters = _context.Disaster.Where(d => d.IsActive).ToList();

            // Create a list of SelectListItem for the <select> element
            Disasters = activeDisasters.Select(disaster => new SelectListItem
            {
                Value = disaster.Id.ToString(),
                Text = disaster.Name
            }).ToList();

        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                // Handle allocation and save to the database
                // You can use the Allocation object here

                return RedirectToPage("ThankYou");
            }

            // If the model is not valid, redisplay the form with validation errors
            OnGet(); // Reload the list of active disasters
            return Page();
        }
    }
}


