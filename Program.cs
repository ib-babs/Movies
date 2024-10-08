using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

using Movies.Data;

var builder = WebApplication.CreateBuilder(args);
var HOST = Environment.GetEnvironmentVariable("DBHOST");
var DBNAME = Environment.GetEnvironmentVariable("DBNAME");
var USERNAME = Environment.GetEnvironmentVariable("DBUSER");
var PASSWORD = Environment.GetEnvironmentVariable("DBPASS");
Console.WriteLine("\n\n");
Console.WriteLine(DBNAME);
Console.WriteLine(HOST);
Console.WriteLine(USERNAME);
Console.WriteLine(PASSWORD);
Console.WriteLine("\n\n");
string connectionString = $"Server={HOST};PORT=21712;Database={DBNAME};Uid={USERNAME};Pwd={PASSWORD};SslMode=Required";
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<MovieDbContext>(opts => opts.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

//builder.Services.AddDbContext<MovieDbContext>(opts => opts.UseSqlServer(builder.Configuration.GetConnectionString("MoviesDbConnection") ?? throw new InvalidOperationException("MoviesDbConnection is not exist!")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
