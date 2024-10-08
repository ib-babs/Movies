using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Movies.Data;
using Movies.Models;

namespace Movies.Pages.MoviePage;

public class IndexModel(MovieDbContext context): PageModel{
    [BindProperty]
    public  List<Movie> Movies {get; set;} 

    public IActionResult OnGet(){
        Movies =  context.Movies.OrderBy(m => m.Id).ToList();
        return Page();
    }
}