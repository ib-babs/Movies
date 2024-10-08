using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Movies.Data;
using Movies.Models;

namespace Movies.Pages.MoviePage
{
    public class DetailModel(MovieDbContext context) : PageModel
    {
        public Movie Movie {get; set;} = default!;
        public async Task<IActionResult> OnGet(int id)
        {
            Movie = await context.Movies.FindAsync(id);
            return Page();
        }
    }
}
