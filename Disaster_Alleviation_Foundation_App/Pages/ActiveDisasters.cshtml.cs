using Disaster_Alleviation_Foundation_App.Data;
using Disaster_Alleviation_Foundation_App.Models;
using Disaster_Alleviation_Foundation_App.NewFolder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Disaster_Alleviation_Foundation_App.Pages
{
    public class ActiveDisastersModel : PageModel
    {
        private readonly DAFContext _context;

        public ActiveDisastersModel(DAFContext context)
        {
            _context = context;
        }

        public List<ActiveDisaster> ActiveDisasters { get; set; }

        public IActionResult OnGet()
        {
            // Retrieve a list of active disasters from your database
            var activeDisasters = _context.Disaster.Where(d => IsDisasterActive(d)).ToList();

            // Map the active disasters to the view model
            ActiveDisasters = activeDisasters.Select(d => new ActiveDisaster
            {
                Id = d.Id,
                StartDate = d.StartDate,
                EndDate = d.EndDate,
                Location = d.Location,
                Description = d.Description,
                // Map other properties as needed...
            }).ToList();

            return Page();
        }

        private bool IsDisasterActive(Disaster disaster)
        {
            // Define your logic to determine if a disaster is active based on your criteria.
            // For example, you might consider the current date and compare it to the start and end dates of the disaster.

            DateTime currentDate = DateTime.Now;
            return currentDate >= disaster.StartDate && currentDate <= disaster.EndDate;
        }
    }
}
