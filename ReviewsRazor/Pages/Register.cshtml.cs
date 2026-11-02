using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ReviewsRazor.Models;
using ReviewsRazor.Repository;
using ReviewsRazor.Services;
using System.Security.Cryptography;

namespace ReviewsRazor.Pages;

public class RegisterModel(IRepositoryUser re, PasswordHasher passwordHasher) : PageModel
{
    [BindProperty]
    public ReviewsRazor.Models.RegisterModel reg { get; set; } = new ReviewsRazor.Models.RegisterModel();

    public IActionResult OnGet()
    {
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();

        if (await re.UserExistsAsync(reg.Login))
        {
            ModelState.AddModelError(string.Empty, "Користувач з таким логіном вже існує!");
            return Page();
        }


        byte[] saltBytes = RandomNumberGenerator.GetBytes(16);
        string salt = Convert.ToHexString(saltBytes);

        string hash = passwordHasher.HashPassword(reg.Password, salt);


        var user = new Users
        {
            FirstName = reg.FirstName,
            LastName = reg.LastName,
            Login = reg.Login,
            Salt = salt,
            Password = hash
        };

        await re.CreateAsync(user);
        await re.SaveAsync();

        return RedirectToPage("./Login");
    }
}