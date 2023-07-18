global using System.ComponentModel.DataAnnotations; //putting this here as hit is repeated in both User.cs and UserRole.cs 

using Microsoft.EntityFrameworkCore;
using WebApplication3.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("myconnection")));

var app = builder.Build();

//app.MapGet("/", () => "Hello World!");
app.UseStaticFiles(); //used for all the functionalities present in wwwroot folder
app.UseRouting();
app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
