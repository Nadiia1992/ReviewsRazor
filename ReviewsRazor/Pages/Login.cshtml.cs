using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ReviewsRazor.Models;
using ReviewsRazor.Repository;
using ReviewsRazor.Services;
using System.Security.Cryptography;

namespace ReviewsRazor.Pages;

public class LoginModel(IRepositoryUser re, PasswordHasher passwordHasher) : PageModel
{
    public IActionResult OnGet() => Page();

    [BindProperty]
    public ReviewsRazor.Models.LoginModel logon { get; set; } = new ReviewsRazor.Models.LoginModel();


    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();


        var user = await re.GetUserByLoginAsync(logon.Login);

        if (user == null)
        {
            ModelState.AddModelError(string.Empty, "Невірний логін або пароль!");
            return Page();
        }

        if (!passwordHasher.VerifyPassword(logon.Password, user.Salt, user.Password))

        {
            ModelState.AddModelError(string.Empty, "Невірний логін або пароль!");
            return Page();
        }

        HttpContext.Session.SetString("Login", user.Login!);
        HttpContext.Session.SetString("FirstName", user.FirstName!);
        HttpContext.Session.SetString("LastName", user.LastName!);

        return RedirectToPage("/Clients");
    }
}