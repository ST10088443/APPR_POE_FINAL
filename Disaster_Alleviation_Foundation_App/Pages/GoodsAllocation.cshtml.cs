using Disaster_Alleviation_Foundation_App.Data;
using Disaster_Alleviation_Foundation_App.NewFolder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Disaster_Alleviation_Foundation_App.Pages
{
    public class GoodsAllocationModel : PageModel
    {
        private readonly DAFContext _context; // Inject your database context here

        [BindProperty]
        public GoodsDonations GoodsAllocation { get; set; }

        public List<SelectListItem> ActiveDisasters { get; set; }

        public GoodsAllocationModel(DAFContext context)
        {
            _context = context;

            // Populate the ActiveDisasters list with active disasters
            ActiveDisasters = _context.Disaster
                .Where(d => IsDisasterActive(d))
                .Select(d => new SelectListItem
                {
                    Value = d.Id.ToString(),
                    Text = d.Description // You can use any disaster property you want to display
                })
                .ToList();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                // Handle the goods allocation submission
                // Set the DisasterId in GoodsAllocation and save to the database
                GoodsAllocation.DisasterId = int.Parse(Request.Form["GoodsAllocation.DisasterId"]);
                _context.GoodsDonation.Add(GoodsAllocation);
                _context.SaveChanges();

                // Redirect to a thank you page or other appropriate page
                return RedirectToPage("ThankYou");
            }

            // If ModelState is not valid, return to the allocation form
            return Page();
        }

        private bool IsDisasterActive(Disaster disaster)
        {
            // Implement your logic to determine if a disaster is active
            // Return true if the disaster is active, false otherwise
            // You might check the start and end dates, for example
            return DateTime.Now >= disaster.StartDate && DateTime.Now <= disaster.EndDate;
        }
    }

}
