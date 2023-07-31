global using System.ComponentModel.DataAnnotations; //putting this here as hit is repeated in both User.cs and UserRole.cs 

using Microsoft.EntityFrameworkCore;
using WebApplication3.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("myconnection")));

//using Dependency injection 
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

//to build sessions
builder.Services.AddSession();

var app = builder.Build();

//app.MapGet("/", () => "Hello World!");
app.UseStaticFiles(); //used for all the functionalities present in wwwroot folder
app.UseSession(); //for sessions
app.UseRouting();
app.MapControllerRoute(name: "default", pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();

//the above commands run step by step 
