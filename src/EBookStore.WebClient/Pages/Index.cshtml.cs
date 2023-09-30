using EBookStore.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json.Linq;

namespace EBookStore.WebClient.Pages;
public class IndexModel : PageModel
{

    [BindProperty]
    public User User { get; set; } = default!;

    private readonly string Url = "https://localhost:7089/odata/Users";
    private readonly HttpClient httpClient;
    public IndexModel()
    {
        httpClient = new HttpClient();
    }

    public IActionResult OnGet()
    {

        return Page();

    }

    public async Task<IActionResult> OnPostAsync()
    {
        var response = await httpClient.GetAsync($"{Url}?$filter={nameof(User.EmailAddress)} eq '{User.EmailAddress}' and {nameof(User.Password)} eq '{User.Password}' ");
        if (!response.IsSuccessStatusCode)
        {
            ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
            return Page();
        }
        var data = await response.Content.ReadAsStringAsync();
        dynamic temp = JObject.Parse(data);
        var Users = temp.value?.ToObject<IList<User>>() ?? Array.Empty<User>();
        if (Users.Count == 0)
        {
            ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
            return Page();
        }

        return RedirectToPage("/Books/Index");
    }
}
