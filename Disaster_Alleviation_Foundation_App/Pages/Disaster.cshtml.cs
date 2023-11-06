using Disaster_Alleviation_Foundation_App.Data;
using Disaster_Alleviation_Foundation_App.Models;
using Disaster_Alleviation_Foundation_App.NewFolder;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

namespace Disaster_Alleviation_Foundation_App.Pages
{
    public class DisasterModel : PageModel
    {
        private readonly DAFContext _context;

        [BindProperty]
        public Disaster Disaster { get; set; } 
        // Add a property for selected aid types
        [BindProperty]
        public List<int> SelectedAidTypes { get; set; }

        public List<AidType> AidTypes { get; set; }

        public DisasterModel(DAFContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            // Load available aid types for display in the form
            AidTypes = _context.AidType.ToList();

        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Handle many-to-many relationship with aid types
            if (SelectedAidTypes != null)
            {
                foreach (var aidTypeId in SelectedAidTypes)
                {
                    var disasterAidType = new DisasterAidType
                    {
                        Disaster = Disaster, // Use the renamed property
                        AidType = _context.AidType.Find(aidTypeId)
                    };
                    _context.DisasterAidType.Add(disasterAidType);
                }
            }

            _context.Disaster.Add(Disaster); // Use the renamed property
            await _context.SaveChangesAsync();

            return RedirectToPage("ThankYouPage"); // Redirect to a thank-you page or another appropriate page.
        }
    }
}
