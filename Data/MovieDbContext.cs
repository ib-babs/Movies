using Microsoft.EntityFrameworkCore;
using Movies.Models;
namespace Movies.Data;

public class MovieDbContext(DbContextOptions<MovieDbContext> options): DbContext(options){
    public DbSet<Movie> Movies => Set<Movie>();
}