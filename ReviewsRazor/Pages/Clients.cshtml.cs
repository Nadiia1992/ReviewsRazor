using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ReviewsRazor.Models;
using ReviewsRazor.Repository;

namespace ReviewsRazor.Pages;

public class ClientModel(IRepositoryMessage repo) : PageModel
{
    public IEnumerable<Message> Message { get; set; } = [];

    public async Task<IActionResult> OnGetAsync()
    {
        Message = await repo.GetMessageListAsync();
        return Page();
    }
}