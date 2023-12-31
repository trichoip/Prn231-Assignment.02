﻿using EBookStore.Application.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;

namespace EBookStore.WebClient.Pages.Authors
{
    public class EditModel : PageModel
    {
        private readonly string Url = "https://localhost:7089/odata/Authors";
        private readonly HttpClient httpClient;
        public EditModel()
        {
            httpClient = new HttpClient();
        }

        [BindProperty]
        public AuthorDto Author { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var response = await httpClient.GetAsync($"{Url}/{id}");

            if (!response.IsSuccessStatusCode)
            {
                if (response is { StatusCode: HttpStatusCode.NotFound })
                {
                    return NotFound();
                }
                else
                {
                    return BadRequest();
                }

            }
            Author = await response.Content.ReadFromJsonAsync<AuthorDto>();
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var response = await httpClient.PutAsJsonAsync($"{Url}/{Author.AuthorId}", Author);

            if (!response.IsSuccessStatusCode)
            {
                if (response is { StatusCode: HttpStatusCode.NotFound })
                {
                    return NotFound();
                }
                else
                {
                    return BadRequest();
                }

            }

            return RedirectToPage("./Index");
        }

    }
}
