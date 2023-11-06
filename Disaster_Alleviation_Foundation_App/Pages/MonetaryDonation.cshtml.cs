using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Disaster_Alleviation_Foundation_App.Pages
{
    public class MonetaryDonationModel : PageModel
    {
        [BindProperty]
        public MonetaryDonationInputModel MonetaryDonation { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Process the donation and save it to the database
            // You can access MonetaryDonation.Date and MonetaryDonation.Amount here

            // Redirect to a thank-you page or another appropriate action
            return RedirectToPage("ThankYou");
        }
    }

    public class MonetaryDonationInputModel
    {
        [Required(ErrorMessage = "Please enter a date.")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Please enter an amount.")]
        [DataType(DataType.Currency)]
        public decimal Amount { get; set; }
    }
}
