using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Movies.Models;
using Movies.Data;
namespace Movies.Pages.MoviePage
{
    public class DeleteModel(MovieDbContext context) : PageModel
    {
        [BindProperty]
        public Movie Movie { get; set; } = default!;
        [BindProperty]
        public int Id { get; set; }
        public async Task<IActionResult> OnGet(int id)
        {
            Movie = await context.Movies.FindAsync(id);
            Id = Movie.Id;
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            Movie.Id = Id;
            context.Movies.Remove(Movie);
            await context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }


    }
}
