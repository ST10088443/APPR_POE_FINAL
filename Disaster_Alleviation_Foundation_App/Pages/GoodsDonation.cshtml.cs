using Disaster_Alleviation_Foundation_App.Data;
using Disaster_Alleviation_Foundation_App.NewFolder;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

namespace Disaster_Alleviation_Foundation_App.Pages
{
    public class GoodsDonationModel : PageModel
    {
        private readonly DAFContext _context;

        public GoodsDonationModel(DAFContext context)
        {
            _context = context;
        }

        [BindProperty]
        public GoodsDonations GoodsDonation { get; set; }

        public void OnGet()
        {
            // This method handles the initial page load, if needed.
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page(); // Return to the form with validation errors.
            }

            // Save the donation to the database using Entity Framework.
            _context.GoodsDonation.Add(GoodsDonation);
            _context.SaveChanges();

            return RedirectToPage("ThankYouPage"); // Redirect to a thank-you page or another page.
        }
    }
}
