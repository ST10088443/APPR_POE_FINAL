using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Disaster_Alleviation_Foundation_App.Pages
{
    public class SignInModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;

        public SignInModel(SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }

        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(Username, Password, false, lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    // Sign-in was successful
                    return RedirectToPage("/Index"); // Redirect to the home page or a protected page
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid credentials.");
                    return Page();
                }
            }

            // Model state is not valid, return to the sign-in page
            return Page();
        }
    }
}

