using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Movies.Data;
using Movies.Models;

namespace Movies.Pages.MoviePage
{
    public class CreateModel(MovieDbContext context) : PageModel
    {
        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Movie Movie {get; set;} = default!;

        public async Task<IActionResult> OnPost(){
            if (!ModelState.IsValid){
                return Page();
            }
            context.Movies.Add(Movie);
            await context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
