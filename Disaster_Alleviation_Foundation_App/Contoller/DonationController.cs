using Microsoft.AspNetCore.Mvc;
using Disaster_Alleviation_Foundation_App.Data;
using Disaster_Alleviation_Foundation_App.NewFolder;
using Disaster_Alleviation_Foundation_App.Models;

public class DonationController : Controller
{
    private readonly DAFContext _context;

    public DonationController(DAFContext context)
    {
        _context = context;
    }

    [HttpPost]
    public IActionResult CaptureMonetaryDonation(MonetaryDonation monetaryDonation)
    {
        if (ModelState.IsValid)
        {
            // Assuming you've validated the input in the view, you can save the donation to the database.
            _context.MonetaryDonation.Add(monetaryDonation);
            _context.SaveChanges();

            // Optionally, you can redirect to a "Thank You" page or another appropriate page.
            return RedirectToAction("ThankYou");
        }

        // If ModelState is not valid, return the view with validation errors.
        return View("MonetaryDonation");
    }

    [HttpPost]
    public IActionResult CaptureGoodsDonation(GoodsDonations goodsDonation)
    {
        if (ModelState.IsValid)
        {
            // Assuming you've validated the input in the view, you can save the donation to the database.
            _context.GoodsDonation.Add(goodsDonation);
            _context.SaveChanges();

            // Optionally, you can redirect to a "Thank You" page or another appropriate page.
            return RedirectToAction("ThankYou");
        }

        // If ModelState is not valid, return the view with validation errors.
        return View("GoodsDonation");
    }

    [HttpPost]
    public IActionResult CaptureDisaster(Disaster disaster, List<int> selectedAidTypes)
    {
        if (ModelState.IsValid)
        {
            // Save the disaster to the database
            _context.Disaster.Add(disaster);
            _context.SaveChanges();

            // Create associations between the disaster and selected aid types
            foreach (var aidTypeId in selectedAidTypes)
            {
                var disasterAidType = new DisasterAidType
                {
                    DisasterId = disaster.Id, // Assuming you get the newly generated ID of the disaster
                    AidTypeId = aidTypeId
                };
                _context.DisasterAidType.Add(disasterAidType);
            }

            _context.SaveChanges();

            // Optionally, you can redirect to a "Thank You" page or another appropriate page.
            return RedirectToAction("ThankYou");
        }

        // If ModelState is not valid, return the view with validation errors.
        return View("Disaster");
    }
}
