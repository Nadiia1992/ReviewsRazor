using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ReviewsRazor.Models;
using ReviewsRazor.Repository;

namespace ReviewsRazor.Pages;

public class CreateModel(IRepositoryMessage repo, IRepositoryUser re, IWebHostEnvironment appEnvironment) : PageModel
{
    [BindProperty]
    public Message Message { get; set; } = new();

    public async Task<IActionResult> OnPostAsync(IFormFile? posterFile)
    {
        var login = HttpContext.Session.GetString("Login");

        if (string.IsNullOrEmpty(login))
        {
            return RedirectToPage("Login");
        }

        var user = await re.GetUserByLoginAsync(login);

        if (user == null)
        {
            return RedirectToPage("Login");
        }

        Message.UserId = user.Id;

        Message.MessageDate = DateTime.Now;

        if (!ModelState.IsValid)
        {
            return Page();
        } 
            

        if (posterFile is not null && posterFile.Length > 0)
        {
            var fileName = Path.GetFileName(posterFile.FileName);
            var relativePath = $"/picture/{fileName}";
            var absolutePath = Path.Combine(appEnvironment.WebRootPath, "picture", fileName);

            await using (var fileStream = new FileStream(absolutePath, FileMode.Create))
            {
                await posterFile.CopyToAsync(fileStream);
            }
            Message.Foto = relativePath;
        }
        await repo.CreateAsync(Message);
        await repo.SaveAsync();
        return RedirectToPage("./Clients");
    }
}