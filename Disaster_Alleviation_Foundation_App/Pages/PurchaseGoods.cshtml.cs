using Disaster_Alleviation_Foundation_App.Data;
using Disaster_Alleviation_Foundation_App.Models;
using Disaster_Alleviation_Foundation_App.NewFolder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Disaster_Alleviation_Foundation_App.Pages
{
    public class PurchaseGoodsModel : PageModel
    {
        private readonly DAFContext _context;

        public PurchaseGoodsModel(DAFContext context)
        {
            _context = context;
        }

        [BindProperty]
        public GoodsPurchase Purchase { get; set; }

        // Load goods categories and active disasters for dropdowns
        public SelectList GoodsCategories { get; set; }
        public SelectList ActiveDisasters { get; set; }

        // Define the IsDisasterActive method
        private bool IsDisasterActive(Disaster disaster)
        {
            // Implement your logic to determine if a disaster is active.
            // You might compare the current date to the start and end dates of the disaster, for example.
            return DateTime.Now >= disaster.StartDate && DateTime.Now <= disaster.EndDate;
        }

        public void OnGet()
        {
            // Populate dropdowns with data from your database or other sources
            GoodsCategories = new SelectList(_context.GoodsCategory, "Id", "Name");
            ActiveDisasters = new SelectList(_context.Disaster.Where(d => IsDisasterActive(d)), "Id", "Location");
        }

        private decimal GetAvailableMoney()
        {
            // Implement your logic to retrieve available funds
            // This depends on how you manage available funds in your application.
            return 1000.00M; // Replace with your logic to get available funds
        }

        public IActionResult OnPost()
        {
            // Additional custom validation logic
            if (ModelState.IsValid)
            {
                // Check if the associated disaster is active
                Disaster activeDisaster = _context.Disaster.FirstOrDefault(d => d.Id == Purchase.DisasterId && IsDisasterActive(d));

                if (activeDisaster == null)
                {
                    ModelState.AddModelError("Purchase.DisasterId", "Selected disaster is not active.");
                }

                // Check if there is enough available money for the purchase
                if (Purchase.AmountSpent > GetAvailableMoney())
                {
                    ModelState.AddModelError("Purchase.AmountSpent", "Insufficient funds for the purchase.");
                }

                if (ModelState.IsValid)
                {
                    // Handle the purchase submission
                    // Subtract funds, add goods to inventory, and allocate them to the disaster
                    // ...

                    // Redirect to a success page or the disaster details page.
                    return RedirectToAction("ThankYou");
                }
            }

            // If ModelState is not valid, return the purchase form with validation errors.
            // This will redisplay the page with error messages.
            // The form fields will retain the user's input.
            return Page();
        }
    }


}
