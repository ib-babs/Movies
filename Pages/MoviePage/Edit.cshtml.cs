using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Movies.Data;
using Movies.Models;

namespace Movies.Pages.MoviePage
{
    public class EditModel(MovieDbContext context) : PageModel
    {
        [BindProperty]
        public Movie Movie { get; set; }
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
            if (!ModelState.IsValid)
            {
                return Page();
            }
            context.Movies.Attach(Movie).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            catch (InvalidOperationException)
            {
                throw;
            }
        }

    }
}
